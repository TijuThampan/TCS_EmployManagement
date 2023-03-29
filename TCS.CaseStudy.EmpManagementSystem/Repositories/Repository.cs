using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCS.CaseStudy.EmpManagementSystem.APICallHelper;
using TCS.CaseStudy.EmpManagementSystem.Components;

namespace TCS.CaseStudy.EmpManagementSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private APICall _objAPICall;
        private APIGetResultMapper<T> _apiGetResultMapper;
        private APIPostResultMapper _apiPostResultMapper;
        string _apiPath;
        string _apiStringResult;
        private const string _baseAPIaddress = "https://gorest.co.in/";
        private const string _bearerToken = "fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56";

        public enum OperationType
        {
            Add = 0,
            Update = 1,
            Delete = 2,
            Read = 3
        }

        public Repository()
        {

        }

        public List<T> GetAllData()
        {
            List<T> lstData = new List<T>();

            MapAPIPath(OperationType.Read);
            _objAPICall = new APICall(_baseAPIaddress, _apiPath, _bearerToken);
            _apiStringResult = _objAPICall.GetMethod();

            if (_apiStringResult != null)
            {
                _apiGetResultMapper = JsonConvert.DeserializeObject<APIGetResultMapper<T>>(_apiStringResult);

                if (_apiGetResultMapper != null)
                {
                    lstData = _apiGetResultMapper.Data;
                    PaginationDetail.Total = _apiGetResultMapper.Meta.pagination.total;
                }
            }

            return lstData;
        }

        public List<T> GetDatabyCondition(Hashtable hshQueryString, Hashtable hshRequestHeader)
        {
            List<T> lstData = new List<T>();

            MapAPIPath(OperationType.Read);
            _objAPICall = new APICall(_baseAPIaddress, _apiPath, _bearerToken, hshQueryString, hshRequestHeader);
            _apiStringResult = _objAPICall.GetMethod();

            if (_apiStringResult != null)
            {
                _apiGetResultMapper = JsonConvert.DeserializeObject<APIGetResultMapper<T>>(_apiStringResult);

                if (_apiGetResultMapper != null)
                {
                    lstData = _apiGetResultMapper.Data;
                    PaginationDetail.Total = _apiGetResultMapper.Meta.pagination.total;
                }
            }

            return lstData;
        }

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
    }
}
