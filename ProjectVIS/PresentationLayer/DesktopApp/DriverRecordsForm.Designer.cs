namespace ProjectVIS.PresentationLayer.DesktopApp
{
    partial class DriverRecordsForm
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.Ammount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PointsTaken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FineType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ammount,
            this.PointsTaken,
            this.DateOfEntry,
            this.ExpireDate,
            this.PaidDate,
            this.EmployeeID,
            this.EmployeeName,
            this.FineType});
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(957, 450);
            this.dataGrid.TabIndex = 3;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            // 
            // Ammount
            // 
            this.Ammount.DataPropertyName = "Ammount";
            this.Ammount.HeaderText = "Ammount";
            this.Ammount.Name = "Ammount";
            this.Ammount.ReadOnly = true;
            // 
            // PointsTaken
            // 
            this.PointsTaken.DataPropertyName = "PointsTaken";
            this.PointsTaken.HeaderText = "PointsTaken";
            this.PointsTaken.Name = "PointsTaken";
            this.PointsTaken.ReadOnly = true;
            // 
            // DateOfEntry
            // 
            this.DateOfEntry.DataPropertyName = "DateOfEntry";
            this.DateOfEntry.HeaderText = "DateOfEntry";
            this.DateOfEntry.Name = "DateOfEntry";
            this.DateOfEntry.ReadOnly = true;
            // 
            // ExpireDate
            // 
            this.ExpireDate.DataPropertyName = "ExpireDate";
            this.ExpireDate.HeaderText = "ExpireDate";
            this.ExpireDate.Name = "ExpireDate";
            this.ExpireDate.ReadOnly = true;
            // 
            // PaidDate
            // 
            this.PaidDate.DataPropertyName = "PaidDate";
            this.PaidDate.HeaderText = "PaidDate";
            this.PaidDate.Name = "PaidDate";
            this.PaidDate.ReadOnly = true;
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "EmployeeID";
            this.EmployeeID.HeaderText = "EmployeeID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.HeaderText = "EmployeeName";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // FineType
            // 
            this.FineType.DataPropertyName = "FineType";
            this.FineType.HeaderText = "FineType";
            this.FineType.Name = "FineType";
            this.FineType.ReadOnly = true;
            // 
            // DriverRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 450);
            this.Controls.Add(this.dataGrid);
            this.Name = "DriverRecordsForm";
            this.Text = "DriverRecordsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ammount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PointsTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FineType;
    }
}