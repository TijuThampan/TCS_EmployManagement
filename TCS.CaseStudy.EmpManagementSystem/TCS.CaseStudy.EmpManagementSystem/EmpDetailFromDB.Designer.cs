namespace TCS.CaseStudy.EmpManagementSystem
{
    partial class EmpDetailFromDB
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
            this.dgViewEmpDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewEmpDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgViewEmpDetails
            // 
            this.dgViewEmpDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgViewEmpDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgViewEmpDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewEmpDetails.Location = new System.Drawing.Point(42, 78);
            this.dgViewEmpDetails.Name = "dgViewEmpDetails";
            this.dgViewEmpDetails.RowHeadersWidth = 51;
            this.dgViewEmpDetails.RowTemplate.Height = 24;
            this.dgViewEmpDetails.Size = new System.Drawing.Size(716, 295);
            this.dgViewEmpDetails.TabIndex = 3;
            // 
            // EmpDetailFromDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgViewEmpDetails);
            this.Name = "EmpDetailFromDB";
            this.Text = "EmpDetailFromDB";
            this.Load += new System.EventHandler(this.EmpDetailFromDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewEmpDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewEmpDetails;
    }
}