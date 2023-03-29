using System;
#region Namespaces
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion Namespaces

namespace TCS.CaseStudy.EmpManagementSystem.Components
{
    public class EmployeeData
    {
        #region Public properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }

        #endregion Public propertiies
    }
}
