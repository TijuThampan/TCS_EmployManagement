using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCS.CaseStudy.EmpManagementSystem.APICallHelper;
using TCS.CaseStudy.EmpManagementSystem.Components;
using TCS.CaseStudy.EmpManagementSystem.Services;

namespace TCS.CaseStudy.EmpManagementSystem
{
    public partial class AddEmployee : Form
    {
        EmployeeDetails _objEmployDetail;
        public AddEmployee()
        {
            InitializeComponent();            
        }

        public AddEmployee(EmployeeDetails employeeDetails) : this()
        {
            _objEmployDetail = employeeDetails;
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            LoadDropDowns();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Email = txtEmail.Text;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter name");
            }
            else if (string.IsNullOrEmpty(Email))
            {
                MessageBox.Show("Please enter email address");
            }
            else if (!(IsValidEmail(Email)))
            {
                MessageBox.Show("Please enter valid e-mail address");
                txtEmail.Text = string.Empty;
            }
            else if (comboGender.SelectedItem == null)
            {
                MessageBox.Show("Please select gender");
            }
            else if(comboStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select status");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                this.AddEmployDetail();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            comboGender.SelectedItem = null;
            comboStatus.SelectedItem = null;
        }

        private void AddEmployDetail()
        {
            string result;

            EmployeeData objEmployData = new EmployeeData()
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Gender = comboGender.SelectedItem.ToString(),
                Status = comboStatus.SelectedItem.ToString()
            };

            result = new EmployeeService().AddEmpoyDetail(objEmployData);
            if (!string.IsNullOrEmpty(result))
            {
                if (result == "success")
                {
                    _objEmployDetail.GetEmployeeDetails();
                    MessageBox.Show("Record inserted successfully!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result);
                }               
            }
            else
            {
                MessageBox.Show("Something bad happened. Please try again later!");
            }
        }

        private void LoadDropDowns()
        {
            comboStatus.Items.Add("active");
            comboStatus.Items.Add("inactive");
            comboGender.Items.Add("male");
            comboGender.Items.Add("female");
        }
        
        private bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
