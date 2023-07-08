#region NameSpaces
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
#endregion NameSpaces

namespace TCS.CaseStudy.EmpManagementSystem
{
    public partial class frmAddEmployee : Form
    {
        #region Variables
        private EmployeeDetails _objEmployDetail;
        #endregion Variables

        #region Constructor
        public frmAddEmployee()
        {
            InitializeComponent();
        }

        public frmAddEmployee(EmployeeDetails employeeDetails) : this()
        {
            _objEmployDetail = employeeDetails;
        }
        #endregion Constructor    

        #region Events

        #region AddEmployee_Load
        /// <summary>
        /// Event to handle form load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEmployee_Load(object sender, EventArgs e)
        {
            LoadDropDowns();
        }
        #endregion AddEmployee_Load

        #region btnAdd_Click
        /// <summary>
        /// To Add an employee detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            else if (comboStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select status");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                this.AddEmployeeDetail();
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion btnAdd_Click

        #region btnCancel_Click
        /// <summary>
        /// To handle cancel button in the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            comboGender.SelectedItem = null;
            comboStatus.SelectedItem = null;
            this.Close();
        }
        #endregion btnCancel_Click

        #endregion Events

        #region Functions

        #region AddEmployeeDetail
        /// <summary>
        /// To add employee details
        /// </summary>
        private void AddEmployeeDetail()
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
        #endregion AddEmployeeDetail

        #region LoadDropDowns
        /// <summary>
        /// To Load drop down list values
        /// </summary>
        private void LoadDropDowns()
        {
            comboStatus.Items.Add("active");
            comboStatus.Items.Add("inactive");
            comboGender.Items.Add("male");
            comboGender.Items.Add("female");
        }
        #endregion LoadDropDowns

        #region IsValidEmail
        /// <summary>
        /// Function to validate email format.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Is valid or not</returns>
        private bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
        #endregion IsValidEmail

        #endregion Functions
    }
}
