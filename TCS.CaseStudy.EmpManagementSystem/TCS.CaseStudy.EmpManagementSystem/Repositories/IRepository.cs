#region Namespaces
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCS.CaseStudy.EmpManagementSystem.Components;
#endregion Namespaces

namespace TCS.CaseStudy.EmpManagementSystem.Repositories
{
    public interface IRepository<T> where T : class
    {
        #region Member Functions
        List<T> GetAllData();
        List<T> GetDatabyCondition(Hashtable hshQueryString, Hashtable hshRequestHeader);      
        string AddData(T objData);
        #endregion Member Functions
    }
}
