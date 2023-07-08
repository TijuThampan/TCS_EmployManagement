#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCS.CaseStudy.EmpManagementSystem.Components;
#endregion Namespaces

namespace TCS.CaseStudy.EmpManagementSystem.APICallHelper
{
    public class APIResultMapper<T> where T : class
    {
        #region Public properties
        public int Code { get; set; }
        public List<T> Data { get; set; }
        public dynamic Meta { get; set; }

        #endregion Public properties
    }
}
