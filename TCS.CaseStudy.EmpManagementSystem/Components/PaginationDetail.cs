#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Namespaces

namespace TCS.CaseStudy.EmpManagementSystem.Components
{
    public static class PaginationDetail
    {
        #region Public properties
        public static int Total{get; set;}
        public static int Page { get; set;}
        public static int Pages { get; set;}
        public static int Limit { get; set;}
        #endregion Public properties
    }
}
