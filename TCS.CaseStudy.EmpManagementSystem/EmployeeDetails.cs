#region Namespaces
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TCS.CaseStudy.EmpManagementSystem.APICallHelper;
using TCS.CaseStudy.EmpManagementSystem.Components;
using TCS.CaseStudy.EmpManagementSystem.Services;
#endregion Namespaces

namespace TCS.CaseStudy.EmpManagementSystem
{
    public partial class EmployeeDetails : Form
    {
        #region Variables
        private int _pageSize = 10;
        private int _currentPageNumber = 1;
        private int _totalPage = 1;
        #endregion Variables

        #region Events

        #region EmployeeDetails
        /// <summary>
        /// Constructor class
        /// </summary>
        public EmployeeDetails()
        {
            InitializeComponent();
        }
        #endregion EmployeeDetails

        #region EmployeeDetails_Load
        /// <summary>
        /// Event for loading the form with details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeDetails_Load(object sender, EventArgs e)
        {
            LoadSearchCriteria();
            GetEmployeeDetails();
        }
        #endregion EmployeeDetails_Load

        #region btnAddEmployee_Click
        /// <summary>
        /// btnAddEmployee_Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployee obj = new AddEmployee(this);
            obj.Show();
        }
        #endregion btnAddEmployee_Click

        #region btnFirst_Click
        /// <summary>
        /// btnFirst_Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this._currentPageNumber = 1;
            this.GetEmployeeDetails();
            Cursor.Current = Cursors.Default;
        }
        #endregion btnFirst_Click

        #region btnPrevious_Click
        /// <summary>
        /// btnPrevious_Click event to get the previous pages in grid as per pagination.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this._currentPageNumber > 1)
            {
                Cursor.Current = Cursors.WaitCursor;
                this._currentPageNumber--;
                this.GetEmployeeDetails();
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion btnPrevious_Click

        #region btnNext_Click
        /// <summary>
        /// btnNext_Click event to get next pages of employee data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this._currentPageNumber < this._totalPage)
            {
                Cursor.Current = Cursors.WaitCursor;
                this._currentPageNumber++;
                this.GetEmployeeDetails();
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion btnNext_Click

        #region btnLast_Click
        /// <summary>
        /// btnLast_Click for triggering event on clicking last button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this._currentPageNumber = _totalPage;
            this.GetEmployeeDetails();
            Cursor.Current = Cursors.Default;
        }
        #endregion btnLast_Click

        #region btnSearch_Click
        /// <summary>
        /// Event for Search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Hashtable hshSearchCriteria = new Hashtable();

            if ((!string.IsNullOrEmpty(txtSearch.Text)) && (comboSearchCriteria.SelectedItem != null && comboSearchCriteria.SelectedItem != string.Empty))
            {
                Cursor.Current = Cursors.WaitCursor;
                hshSearchCriteria.Add(comboSearchCriteria.SelectedItem.ToString().ToLower(), txtSearch.Text);
                GetEmployeeDetails(hshSearchCriteria);
                Cursor.Current = Cursors.Default;
            }
            else if (!string.IsNullOrEmpty(txtSearch.Text) && (comboSearchCriteria.SelectedItem == string.Empty || comboSearchCriteria.SelectedItem == null))
            {
                MessageBox.Show("Please select a search criteria!");
            }
            else if (string.IsNullOrEmpty(txtSearch.Text) && comboSearchCriteria.SelectedItem != string.Empty && comboSearchCriteria.SelectedItem != null)
            {
                MessageBox.Show("Please enter the search text!");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                _currentPageNumber= 1;
                GetEmployeeDetails();
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion btnSearch_Click

        #endregion Events

        #region Functions

        #region GetEmployeeDetails
        /// <summary>
        /// Function for getting the details of employee
        /// </summary>
        /// <param name="hshSearchFields"></param>
        public void GetEmployeeDetails(Hashtable hshSearchFields = null)
        {
            try
            {
                List<EmployeeData> lstEmployData = new List<EmployeeData>();
                
                if (hshSearchFields == null)
                {
                    hshSearchFields = new Hashtable();                   
                }
 
                hshSearchFields.Add("page", _currentPageNumber);//pagination purpose within query string.
                hshSearchFields.Add("per_page", _pageSize);
                lstEmployData = new EmployeeService().GetEmployeeDetailsByCondition(hshSearchFields, null);
                if (lstEmployData != null)
                {                    
                    this.CalculateTotalPages(PaginationDetail.Total);
                    dgViewEmpDetails.DataSource = lstEmployData;
                    dgViewEmpDetails.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    lblPageNumber.Text = "Page: " + _currentPageNumber.ToString(); // Shows page number
                }
                else
                {
                    MessageBox.Show("Something bad happened. Please try again later!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion GetEmployeeDetails

        #region CalculateTotalPages
        /// <summary>
        /// Function for getting total pages from the API response and to maintain pagination
        /// </summary>
        /// <param name="totalRecordCount"></param>
        private void CalculateTotalPages(int totalRecordCount)
        {
            _totalPage = totalRecordCount / _pageSize;

            if (totalRecordCount % _pageSize > 0)
            {
                _totalPage += 1;
            }
        }
        #endregion CalculateTotalPages

        #region LoadSearchCriteria
        /// <summary>
        /// Function for loading the search criterias
        /// </summary>
        private void LoadSearchCriteria()
        {
            comboSearchCriteria.Items.Add(string.Empty);

            foreach (PropertyInfo p in typeof(EmployeeData).GetProperties())
            {
                comboSearchCriteria.Items.Add(p.Name);
            }
        }
        #endregion LoadSearchCriteria

        #endregion Functions
    }
}
