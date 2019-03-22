namespace FunWithDataGridView
{
    partial class FunWithDataGridViewForm
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
            this.dataGridViewSchools = new System.Windows.Forms.DataGridView();
            this.gridViewTextBoxColumnSchool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnSchoolType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumnSchoolSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonShowGridData = new System.Windows.Forms.Button();
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchools)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSchools
            // 
            this.dataGridViewSchools.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSchools.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridViewTextBoxColumnSchool,
            this.dataGridViewTextBoxColumnSchoolType,
            this.dataGridViewTextBoxColumnSchoolSize});
            this.dataGridViewSchools.Location = new System.Drawing.Point(84, 12);
            this.dataGridViewSchools.Name = "dataGridViewSchools";
            this.dataGridViewSchools.Size = new System.Drawing.Size(331, 150);
            this.dataGridViewSchools.TabIndex = 0;
            // 
            // gridViewTextBoxColumnSchool
            // 
            this.gridViewTextBoxColumnSchool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.gridViewTextBoxColumnSchool.HeaderText = "School";
            this.gridViewTextBoxColumnSchool.Name = "gridViewTextBoxColumnSchool";
            this.gridViewTextBoxColumnSchool.Width = 65;
            // 
            // dataGridViewTextBoxColumnSchoolType
            // 
            this.dataGridViewTextBoxColumnSchoolType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumnSchoolType.HeaderText = "School Type";
            this.dataGridViewTextBoxColumnSchoolType.Name = "dataGridViewTextBoxColumnSchoolType";
            this.dataGridViewTextBoxColumnSchoolType.Width = 92;
            // 
            // dataGridViewTextBoxColumnSchoolSize
            // 
            this.dataGridViewTextBoxColumnSchoolSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumnSchoolSize.HeaderText = "School Size";
            this.dataGridViewTextBoxColumnSchoolSize.Name = "dataGridViewTextBoxColumnSchoolSize";
            this.dataGridViewTextBoxColumnSchoolSize.Width = 88;
            // 
            // buttonShowGridData
            // 
            this.buttonShowGridData.Location = new System.Drawing.Point(159, 183);
            this.buttonShowGridData.Name = "buttonShowGridData";
            this.buttonShowGridData.Size = new System.Drawing.Size(183, 64);
            this.buttonShowGridData.TabIndex = 1;
            this.buttonShowGridData.Text = "Show Grid Data";
            this.buttonShowGridData.UseVisualStyleBackColor = true;
            this.buttonShowGridData.Click += new System.EventHandler(this.ButtonShowGridData_Click);
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.Location = new System.Drawing.Point(123, 270);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxOutput.Size = new System.Drawing.Size(266, 95);
            this.listBoxOutput.TabIndex = 2;
            // 
            // FunWithDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 395);
            this.Controls.Add(this.listBoxOutput);
            this.Controls.Add(this.buttonShowGridData);
            this.Controls.Add(this.dataGridViewSchools);
            this.Name = "FunWithDataGridView";
            this.Text = "Fun With DataGridView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchools)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSchools;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridViewTextBoxColumnSchool;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnSchoolType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumnSchoolSize;
        private System.Windows.Forms.Button buttonShowGridData;
        private System.Windows.Forms.ListBox listBoxOutput;
    }
}

