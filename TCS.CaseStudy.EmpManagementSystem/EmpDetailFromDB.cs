using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCS.CaseStudy.EmpManagementSystem.Components;
using TCS.CaseStudy.EmpManagementSystem.Services;

namespace TCS.CaseStudy.EmpManagementSystem
{
    public partial class EmpDetailFromDB : Form
    {
        public EmpDetailFromDB()
        {
            InitializeComponent();
        }

        private void EmpDetailFromDB_Load(object sender, EventArgs e)
        {
            List<EmployeeData> lstEmployData = new List<EmployeeData>();

            lstEmployData = GetEmployeeDetailFromDB();
            dgViewEmpDetails.DataSource = lstEmployData;
            dgViewEmpDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private List<EmployeeData> GetEmployeeDetailFromDB()
        {
            List<EmployeeData> lstEmployData = new List<EmployeeData>();
            lstEmployData = new EmployeeService().GetEmployeeDetailFromDB();
            return lstEmployData;
        }
    }
}
