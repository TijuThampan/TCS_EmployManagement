using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCS.CaseStudy.EmpManagementSystem.DataAccessLayer
{
    public interface IDBFactory<T> where T : class
    {
        Hashtable Parameter { get; set; }
        Dictionary<string, SqlDbType> OutParam { get; set; }
        List<T> GetData(string sql, CommandType type);
        bool AddOrUpdOrDelData(string sql, CommandType type);
    }
}
