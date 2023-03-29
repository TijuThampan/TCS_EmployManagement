using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCS.CaseStudy.EmpManagementSystem.Components;
using TCS.CaseStudy.EmpManagementSystem.Repositories;

namespace TCS.CaseStudy.EmpManagementSystem.Services
{
    public class EmployeeService
    {
        private IRepository<EmployeeData> _objRepository;

        public EmployeeService() 
        {
            _objRepository = new Repository<EmployeeData>();
        }

        public List<EmployeeData> GetAllEmployeeDetails()
        {
            List<EmployeeData> lstEmpData= new List<EmployeeData>();

            lstEmpData = _objRepository.GetAllData();

            return lstEmpData;
        }

        public List<EmployeeData> GetEmployeeDetailsByCondition(Hashtable hshQueryString, Hashtable hshRequestHeader)
        {
            List<EmployeeData> lstEmpData = new List<EmployeeData>();

            lstEmpData = _objRepository.GetDatabyCondition(hshQueryString, hshRequestHeader);

            return lstEmpData;
        }

        public string AddEmpoyDetail(EmployeeData objEmployDetail)
        {
            string insertMessage;

            insertMessage = _objRepository.AddData(objEmployDetail);

            return insertMessage;
        }
    }
}
