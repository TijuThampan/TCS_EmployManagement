using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCS.CaseStudy.EmpManagementSystem.Components;

namespace TCS.CaseStudy.EmpManagementSystem.APICallHelper
{
    public class APIPostResultMapper
    {
        #region Public properties
        public int Code { get; set; }
        public List<APIErrorData> Data { get; set; }
        public dynamic Meta { get; set; }

        #endregion Public properties
    }
}
