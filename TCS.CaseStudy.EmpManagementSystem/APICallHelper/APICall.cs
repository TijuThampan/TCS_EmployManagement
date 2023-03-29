#region Namespaces
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
#endregion Namespaces

namespace TCS.CaseStudy.EmpManagementSystem.APICallHelper
{
    public class APICall
    {
        private string _baseAddress;
        private string _apiPath;
        private string _bearerToken;
        private Hashtable _hshQueryString;
        private Hashtable _hshRequestHeaders;
        private object _bodyContent;
        private HttpClient _objClient;
        private string _stringBodyContent;
        
        public APICall()
        {

        }

        public APICall(string baseAddress, string apiPath, string bearerToken, Hashtable hshQueryString= null, Hashtable hshRequestHeaders = null, object bodyContent = null) 
        {
            _baseAddress = baseAddress;
            _apiPath = apiPath;
            _bearerToken = bearerToken;
            _hshQueryString = hshQueryString;
            _hshRequestHeaders = hshRequestHeaders;
            _bodyContent = bodyContent;
        }

        #region GetMethod
        /// <summary>
        /// Get method for getting API response data
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="apiPath"></param>
        /// <param name="hshqueryString"></param>
        /// <param name="requestHeaders"></param>
        /// <param name="bearerToken"></param>
        /// <returns>String result from API</returns>
        public string GetMethod()
        {            
            string url = string.Empty;
            string queryString = string.Empty;
            string stringResult =string.Empty;

            InitHttpClient();
            url = _baseAddress + _apiPath;            

            if (_hshQueryString != null)
            {
                queryString = BindQueryString(_hshQueryString);
                url += queryString;
            }
        
            var response = _objClient.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                stringResult = response.Content.ReadAsStringAsync().Result;               
            }

            return stringResult;
        }
        #endregion GetMethod

        #region PostMethod
        /// <summary>
        /// Method to post data to API
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="apiPath"></param>
        /// <param name="requestHeaders"></param>
        /// <param name="bearerToken"></param>
        /// <param name="body"></param>
        /// <returns>Response from API</returns>
        public string PostMethod()
        {            
            StringContent contentData = null;
            string bodyData = string.Empty;
            string stringResult = string.Empty;

            InitHttpClient();

            if (_bodyContent != null)
            {
                RemoveIDFromContenBody();
                contentData = new StringContent(_stringBodyContent, Encoding.UTF8, "application/json");
            }

            var response = _objClient.PostAsync(_baseAddress + _apiPath, contentData).Result;

            if (response.IsSuccessStatusCode)
            {
                stringResult = response.Content.ReadAsStringAsync().Result;               
            }

            return stringResult;
        }
        #endregion PostMethod

        private void InitHttpClient()
        {
            _objClient = new HttpClient();
            _objClient.BaseAddress = new Uri(_baseAddress);

            if (_hshRequestHeaders != null)
            {
                foreach (DictionaryEntry val in _hshRequestHeaders)
                {
                    _objClient.DefaultRequestHeaders.Add(val.Key.ToString(), val.Value.ToString());
                }
            }

            if (!string.IsNullOrEmpty(_bearerToken))
            {
                _objClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);
            }

        }

        #region BindQueryString
        /// <summary>
        /// Function to convert hashtable to querystring format.
        /// </summary>
        /// <param name="hshQueryStringValues"></param>
        /// <returns>QueryString</returns>
        private string BindQueryString(Hashtable hshQueryStringValues)
        {
            StringBuilder sb = new StringBuilder();           

            if (hshQueryStringValues != null)
            {
                sb.Append("?");
                foreach (DictionaryEntry val in hshQueryStringValues)
                {
                    sb.Append(val.Key.ToString());
                    sb.Append("=");
                    sb.Append(val.Value.ToString());
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }
        #endregion BindQueryString

        private void RemoveIDFromContenBody() //We don't have to pass the ID in body content to API for Insert and Update
        {           
            var dictionary = new Dictionary<string, object>();
            var properties = _bodyContent.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var value = property.GetValue(_bodyContent);
                dictionary.Add(property.Name.ToLower(), value);
            }

            if (dictionary.ContainsKey("ID"))
            {
                dictionary.Remove("ID");
            }
            
            _stringBodyContent = JsonConvert.SerializeObject(dictionary);
        }
    }
}
