namespace TCS.CaseStudy.EmpManagementSystem
{
    partial class EmployeeDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblEmployeeManagementSystem = new System.Windows.Forms.Label();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.dgViewEmpDetails = new System.Windows.Forms.DataGridView();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.comboSearchCriteria = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchCriteria = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnGetEmployeeDetails = new System.Windows.Forms.Button();
            this.lblSearchCriteriaMessage = new System.Windows.Forms.Label();
            this.ttHoverTitle = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewEmpDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmployeeManagementSystem
            // 
            this.lblEmployeeManagementSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmployeeManagementSystem.AutoSize = true;
            this.lblEmployeeManagementSystem.BackColor = System.Drawing.SystemColors.WindowText;
            this.lblEmployeeManagementSystem.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeManagementSystem.ForeColor = System.Drawing.Color.Snow;
            this.lblEmployeeManagementSystem.Location = new System.Drawing.Point(81, 9);
            this.lblEmployeeManagementSystem.Name = "lblEmployeeManagementSystem";
            this.lblEmployeeManagementSystem.Size = new System.Drawing.Size(808, 67);
            this.lblEmployeeManagementSystem.TabIndex = 0;
            this.lblEmployeeManagementSystem.Text = "Employee Management System";
            this.lblEmployeeManagementSystem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddEmployee.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployee.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAddEmployee.Location = new System.Drawing.Point(725, 94);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(164, 31);
            this.btnAddEmployee.TabIndex = 1;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.UseVisualStyleBackColor = false;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            this.btnAddEmployee.MouseHover += new System.EventHandler(this.HandleHoverMessage);
            // 
            // dgViewEmpDetails
            // 
            this.dgViewEmpDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgViewEmpDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgViewEmpDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewEmpDetails.Location = new System.Drawing.Point(137, 210);
            this.dgViewEmpDetails.Name = "dgViewEmpDetails";
            this.dgViewEmpDetails.RowHeadersWidth = 51;
            this.dgViewEmpDetails.RowTemplate.Height = 24;
            this.dgViewEmpDetails.Size = new System.Drawing.Size(716, 295);
            this.dgViewEmpDetails.TabIndex = 2;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(137, 540);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(75, 23);
            this.btnFirst.TabIndex = 3;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(223, 540);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(310, 540);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 5;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(403, 540);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 6;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // comboSearchCriteria
            // 
            this.comboSearchCriteria.FormattingEnabled = true;
            this.comboSearchCriteria.Location = new System.Drawing.Point(137, 164);
            this.comboSearchCriteria.Name = "comboSearchCriteria";
            this.comboSearchCriteria.Size = new System.Drawing.Size(121, 24);
            this.comboSearchCriteria.TabIndex = 7;
            this.comboSearchCriteria.SelectedIndexChanged += new System.EventHandler(this.comboSearchCriteria_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(281, 165);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(142, 22);
            this.txtSearch.TabIndex = 8;
            // 
            // lblSearchCriteria
            // 
            this.lblSearchCriteria.AutoSize = true;
            this.lblSearchCriteria.Location = new System.Drawing.Point(134, 145);
            this.lblSearchCriteria.Name = "lblSearchCriteria";
            this.lblSearchCriteria.Size = new System.Drawing.Size(95, 16);
            this.lblSearchCriteria.TabIndex = 9;
            this.lblSearchCriteria.Text = "Search Criteria";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(278, 145);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(88, 16);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Search Value";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(439, 164);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseHover += new System.EventHandler(this.HandleHoverMessage);
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Location = new System.Drawing.Point(307, 508);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(0, 16);
            this.lblPageNumber.TabIndex = 12;
            // 
            // btnGetEmployeeDetails
            // 
            this.btnGetEmployeeDetails.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGetEmployeeDetails.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.btnGetEmployeeDetails.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnGetEmployeeDetails.Location = new System.Drawing.Point(580, 94);
            this.btnGetEmployeeDetails.Name = "btnGetEmployeeDetails";
            this.btnGetEmployeeDetails.Size = new System.Drawing.Size(124, 31);
            this.btnGetEmployeeDetails.TabIndex = 13;
            this.btnGetEmployeeDetails.Text = "Get Details";
            this.btnGetEmployeeDetails.UseVisualStyleBackColor = false;
            this.btnGetEmployeeDetails.Click += new System.EventHandler(this.btnGetEmployeeDetails_Click);
            this.btnGetEmployeeDetails.MouseHover += new System.EventHandler(this.HandleHoverMessage);
            // 
            // lblSearchCriteriaMessage
            // 
            this.lblSearchCriteriaMessage.AutoSize = true;
            this.lblSearchCriteriaMessage.Location = new System.Drawing.Point(520, 168);
            this.lblSearchCriteriaMessage.Name = "lblSearchCriteriaMessage";
            this.lblSearchCriteriaMessage.Size = new System.Drawing.Size(0, 16);
            this.lblSearchCriteriaMessage.TabIndex = 14;
            // 
            // EmployeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1138, 592);
            this.Controls.Add(this.lblSearchCriteriaMessage);
            this.Controls.Add(this.btnGetEmployeeDetails);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.lblSearchCriteria);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.comboSearchCriteria);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.dgViewEmpDetails);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.lblEmployeeManagementSystem);
            this.Name = "EmployeeDetails";
            this.Text = "Employee Details";
            this.Load += new System.EventHandler(this.EmployeeDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewEmpDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmployeeManagementSystem;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.DataGridView dgViewEmpDetails;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.ComboBox comboSearchCriteria;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchCriteria;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Button btnGetEmployeeDetails;
        private System.Windows.Forms.Label lblSearchCriteriaMessage;
        private System.Windows.Forms.ToolTip ttHoverTitle;
    }
}

