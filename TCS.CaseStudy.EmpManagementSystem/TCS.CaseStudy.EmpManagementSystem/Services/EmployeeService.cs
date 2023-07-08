#region Namespaces
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCS.CaseStudy.EmpManagementSystem.Components;
using TCS.CaseStudy.EmpManagementSystem.DataAccessLayer;
using TCS.CaseStudy.EmpManagementSystem.Repositories;
#endregion Namespaces

namespace TCS.CaseStudy.EmpManagementSystem.Services
{
    public class EmployeeService
    {
        #region Private variables
        private IRepository<EmployeeData> _objRepository;
        private IDBFactory<EmployeeData> _objDBFactory;
        #endregion Private variables

        #region EmployeeService
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeService() 
        {
            _objRepository = new Repository<EmployeeData>();
            _objDBFactory = new DBFactory<EmployeeData>();
        }
        #endregion EmployeeService

        #region GetAllEmployeeDetails
        /// <summary>
        /// To get employee details in list
        /// </summary>
        /// <returns>List of employee details</returns>
        public List<EmployeeData> GetAllEmployeeDetails()
        {
            List<EmployeeData> lstEmpData= new List<EmployeeData>();

            lstEmpData = _objRepository.GetAllData();

            return lstEmpData;
        }
        #endregion GetAllEmployeeDetails

        #region GetEmployeeDetailsByCondition
        /// <summary>
        /// To get employee details using condition
        /// </summary>
        /// <param name="hshQueryString"></param>
        /// <param name="hshRequestHeader"></param>
        /// <returns>list of employee details</returns>
        public List<EmployeeData> GetEmployeeDetailsByCondition(Hashtable hshQueryString, Hashtable hshRequestHeader)
        {
            List<EmployeeData> lstEmpData = new List<EmployeeData>();

            lstEmpData = _objRepository.GetDatabyCondition(hshQueryString, hshRequestHeader);

            return lstEmpData;
        }
        #endregion GetEmployeeDetailsByCondition

        #region AddEmpoyDetail
        /// <summary>
        /// To add new employee details
        /// </summary>
        /// <param name="objEmployDetail"></param>
        /// <returns>Return message from API</returns>
        public string AddEmpoyDetail(EmployeeData objEmployDetail)
        {
            string insertMessage;

            insertMessage = _objRepository.AddData(objEmployDetail);

            return insertMessage;
        }
        #endregion AddEmpoyDetail

        #region GetEmployeeDetailFromDB
        /// <summary>
        /// To get employee details in list
        /// </summary>
        /// <returns>List of employee details</returns>
        public List<EmployeeData> GetEmployeeDetailFromDB()
        {
            List<EmployeeData> lstEmpData = new List<EmployeeData>();
            string sql = "Select * from EmployeeData where ID = @id or Name = @name" ; // Add stored procedure or query here 

            _objDBFactory.Parameter = new Hashtable(); // To add Input parameter if have any.
            _objDBFactory.Parameter.Add("@id", 1); // Add Input parameter like this 
            _objDBFactory.Parameter.Add("@name", "Test 2");
            _objDBFactory.OutParam = new Dictionary<string, System.Data.SqlDbType>(); // To add Output parameter if have any.
            //_objDBFactory.OutParam.Add("", System.Data.SqlDbType.VarChar); //Add ouput parameter like this

            lstEmpData = _objDBFactory.GetData(sql, System.Data.CommandType.Text); // if sotred procedure then, give CommandType.StroredProcedure 

            return lstEmpData;
        }
        #endregion GetAllEmployeeDetails
    }
}
