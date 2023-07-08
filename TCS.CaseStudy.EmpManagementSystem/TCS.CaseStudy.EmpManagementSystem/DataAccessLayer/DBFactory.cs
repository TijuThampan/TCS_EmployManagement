using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TCS.CaseStudy.EmpManagementSystem.APICallHelper;
using TCS.CaseStudy.EmpManagementSystem.Components;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using TCS.CaseStudy.EmpManagementSystem.Extension_Methods;

namespace TCS.CaseStudy.EmpManagementSystem.DataAccessLayer
{
    public class DBFactory<T> : IDBFactory<T> where T : class
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public Hashtable Parameter { get; set; }

        public Dictionary<string, SqlDbType> OutParam { get; set; }

        #region GetData        
        public List<T> GetData(string sql, CommandType type)
        {
            DataTable dt;

            List<T> lstData = new List<T>();
            DataSet data = new DataSet();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand objCommand = new SqlCommand(sql, conn);
                objCommand.CommandType = type;

                if (Parameter != null)
                {
                    foreach (DictionaryEntry val in Parameter)
                    {
                        objCommand.Parameters.AddWithValue(val.Key.ToString(), val.Value.ToString());
                    }
                }

                if (OutParam != null)
                {
                    foreach (KeyValuePair<string, SqlDbType> val in OutParam)
                    {
                        SqlParameter objOutputParam = new SqlParameter();
                        objOutputParam.ParameterName = val.Key.ToString();
                        objOutputParam.Direction = ParameterDirection.Output;
                        objOutputParam.SqlDbType = val.Value;
                        objCommand.Parameters.Add(objOutputParam);
                    }
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(objCommand);

                try
                {
                    dataAdapter.Fill(data);
                    dt = data.Tables[0];
                    lstData = dt.ToList<T>();
                }
                catch (Exception)
                {
                    lstData = null;
                    conn.Close();
                }
            }

            return lstData;
        }
        #endregion GetAllData

        #region AddOrUpdOrDelData        
        public bool AddOrUpdOrDelData(string sql, CommandType type)
        {
            bool isDone = false;
            int numberOfRowsAffected = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand objCommand = new SqlCommand(sql, conn);
                objCommand.CommandType = type;

                if (Parameter != null)
                {
                    foreach (DictionaryEntry val in Parameter)
                    {
                        objCommand.Parameters.AddWithValue(val.Key.ToString(), val.Value.ToString());
                    }
                }

                if (OutParam != null)
                {
                    foreach (KeyValuePair<string, SqlDbType> val in OutParam)
                    {
                        SqlParameter objOutputParam = new SqlParameter();
                        objOutputParam.ParameterName = val.Key.ToString();
                        objOutputParam.Direction = ParameterDirection.Output;
                        objOutputParam.SqlDbType = val.Value;
                        objCommand.Parameters.Add(objOutputParam);
                    }
                }

                try
                {
                    numberOfRowsAffected = objCommand.ExecuteNonQuery();

                    if (numberOfRowsAffected > 0)
                        isDone = true;
                    else
                        isDone = false;
                }
                catch (Exception)
                {
                    isDone = false;
                    conn.Close();
                }
            }

            return isDone;
        }
        #endregion GetAllData

    }
}