#region Namespaces
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCS.CaseStudy.EmpManagementSystem.APICallHelper;
using TCS.CaseStudy.EmpManagementSystem.Components;
#endregion Namespaces

namespace TCS.CaseStudy.EmpManagementSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region Variables
        private APICall _objAPICall;
        private APIResultMapper<T> _apiGetResultMapper;
        private APIPostResultMapper _apiPostResultMapper;
        string _apiPath;
        string _apiStringResult;
        private const string _baseAPIaddress = "https://gorest.co.in/";
        private string _bearerToken = ConfigurationManager.AppSettings["APIBearerToken"].ToString();
        #endregion Variables

        #region OperationType
        /// <summary>
        /// Function to identify the type of CRUD operation.
        /// </summary>
        public enum OperationType
        {
            Add = 0,
            Update = 1,
            Delete = 2,
            Read = 3
        }
        #endregion OperationType

        #region Repository
        /// <summary>
        /// Constructor
        /// </summary>
        public Repository()
        {

        }
        #endregion Repository

        #region GetAllData
        /// <summary>
        /// To get employee details
        /// </summary>
        /// <returns>Employee list data</returns>
        public List<T> GetAllData()
        {
            List<T> lstData = new List<T>();

            MapAPIPath(OperationType.Read);
            _objAPICall = new APICall(_baseAPIaddress, _apiPath, _bearerToken);
            _apiStringResult = _objAPICall.GetMethod();

            if (_apiStringResult != null)
            {
                _apiGetResultMapper = JsonConvert.DeserializeObject<APIResultMapper<T>>(_apiStringResult);

                if (_apiGetResultMapper != null)
                {
                    lstData = _apiGetResultMapper.Data;
                    PaginationDetail.Total = _apiGetResultMapper.Meta.pagination.total;
                }
            }

            return lstData;
        }
        #endregion GetAllData

        #region GetDatabyCondition
        /// <summary>
        /// To get data using condition
        /// </summary>
        /// <param name="hshQueryString"></param>
        /// <param name="hshRequestHeader"></param>
        /// <returns>Employee list data</returns>
        public List<T> GetDatabyCondition(Hashtable hshQueryString, Hashtable hshRequestHeader)
        {
            List<T> lstData = new List<T>();

            MapAPIPath(OperationType.Read);
            _objAPICall = new APICall(_baseAPIaddress, _apiPath, _bearerToken, hshQueryString, hshRequestHeader);
            _apiStringResult = _objAPICall.GetMethod();

            if (_apiStringResult != null)
            {
                _apiGetResultMapper = JsonConvert.DeserializeObject<APIResultMapper<T>>(_apiStringResult);

                if (_apiGetResultMapper != null)
                {
                    lstData = _apiGetResultMapper.Data;
                    PaginationDetail.Total = _apiGetResultMapper.Meta.pagination.total;
                }
            }

            return lstData;
        }
        #endregion GetDatabyCondition

        #region AddData
        /// <summary>
        /// To add data into API
        /// </summary>
        /// <param name="objData"></param>
        /// <returns>result message</returns>
        public string AddData(T objData)
        {
            string resultMessage = string.Empty;

            MapAPIPath(OperationType.Add);
            _objAPICall = new APICall(_baseAPIaddress, _apiPath, _bearerToken, null, null, objData);
            _apiStringResult = _objAPICall.PostMethod();

            if (_apiStringResult != null)
            {
                dynamic apiResult = JsonConvert.DeserializeObject<object>(_apiStringResult);

                if (apiResult != null)
                {
                    if (apiResult.code == 201)
                    {
                        resultMessage = "success";
                    }
                    else if (apiResult.code == 422)
                    {
                        _apiPostResultMapper = JsonConvert.DeserializeObject<APIPostResultMapper>(_apiStringResult);

                        if (_apiPostResultMapper != null)
                        {
                            foreach (APIErrorData err in _apiPostResultMapper.Data)
                            {
                                resultMessage += err.Field + " " + err.Message + Environment.NewLine;
                            }
                        }
                    }
                }
            }

            return resultMessage;
        }
        #endregion AddData

        #region MapAPIPath
        /// <summary>
        /// To map the path of API
        /// </summary>
        /// <param name="operationType"></param>
        private void MapAPIPath(OperationType operationType)
        {
            // As of now All operation have same API path. But we may need this when each domain or operation have different API path
            switch (typeof(T).Name)
            {
                case "EmployeeData":
                    if (operationType == OperationType.Read || operationType == OperationType.Add)
                    {
                        _apiPath = "public-api/users";
                    }
                    break;
            }
        }
        #endregion MapAPIPath
    }
}
