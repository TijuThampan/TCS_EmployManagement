using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCS.CaseStudy.EmpManagementSystem.Extension_Methods
{
    public static class ExtensionMethod
    {
        public static List<T> ToList<T>(this DataTable dt)
        {
            Type objType = typeof(T);

            PropertyInfo[] type = objType.GetProperties();

            List<T> lst = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                // Create the object of T
                var ob = Activator.CreateInstance<T>();

                foreach (var fieldInfo in type)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        // Matching the columns with fields
                        if (fieldInfo.Name == dc.ColumnName)
                        {
                            // Get the value from the datatable cell
                            object value = dr[dc.ColumnName];

                            // Set the value into the object
                            fieldInfo.SetValue(ob, value);
                            break;
                        }
                    }
                }

                lst.Add(ob);
            };


            return lst;
        }
    }
}
