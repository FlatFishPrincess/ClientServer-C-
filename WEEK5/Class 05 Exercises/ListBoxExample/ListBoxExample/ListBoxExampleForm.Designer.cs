namespace ListBoxExample
{
    partial class ListBoxExampleForm
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
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listBoxStudentNames = new System.Windows.Forms.ListBox();
            this.checkBoxMaxAge = new System.Windows.Forms.CheckBox();
            this.textBoxMaxAge = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelNumberOfStudents = new System.Windows.Forms.Label();
            this.labelDisplayNumberOfStudents = new System.Windows.Forms.Label();
            this.labelAverageAge = new System.Windows.Forms.Label();
            this.labelDisplayAverageAge = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.StudentName,
            this.StudentAge});
            this.dataGridViewStudents.Location = new System.Drawing.Point(80, 24);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.RowHeadersVisible = false;
            this.dataGridViewStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudents.Size = new System.Drawing.Size(304, 150);
            this.dataGridViewStudents.TabIndex = 0;
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "StudentID";
            this.StudentID.Name = "StudentID";
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "Student Name";
            this.StudentName.Name = "StudentName";
            // 
            // StudentAge
            // 
            this.StudentAge.HeaderText = "Age";
            this.StudentAge.Name = "StudentAge";
            // 
            // listBoxStudentNames
            // 
            this.listBoxStudentNames.FormattingEnabled = true;
            this.listBoxStudentNames.Location = new System.Drawing.Point(80, 266);
            this.listBoxStudentNames.Name = "listBoxStudentNames";
            this.listBoxStudentNames.Size = new System.Drawing.Size(120, 95);
            this.listBoxStudentNames.TabIndex = 1;
            // 
            // checkBoxMaxAge
            // 
            this.checkBoxMaxAge.AutoSize = true;
            this.checkBoxMaxAge.Location = new System.Drawing.Point(291, 277);
            this.checkBoxMaxAge.Name = "checkBoxMaxAge";
            this.checkBoxMaxAge.Size = new System.Drawing.Size(68, 17);
            this.checkBoxMaxAge.TabIndex = 2;
            this.checkBoxMaxAge.Text = "Max Age";
            this.checkBoxMaxAge.UseVisualStyleBackColor = true;
            // 
            // textBoxMaxAge
            // 
            this.textBoxMaxAge.Location = new System.Drawing.Point(377, 275);
            this.textBoxMaxAge.Name = "textBoxMaxAge";
            this.textBoxMaxAge.Size = new System.Drawing.Size(100, 20);
            this.textBoxMaxAge.TabIndex = 3;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(319, 337);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 4;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // labelNumberOfStudents
            // 
            this.labelNumberOfStudents.AutoSize = true;
            this.labelNumberOfStudents.Location = new System.Drawing.Point(80, 198);
            this.labelNumberOfStudents.Name = "labelNumberOfStudents";
            this.labelNumberOfStudents.Size = new System.Drawing.Size(101, 13);
            this.labelNumberOfStudents.TabIndex = 5;
            this.labelNumberOfStudents.Text = "Number of Students";
            // 
            // labelDisplayNumberOfStudents
            // 
            this.labelDisplayNumberOfStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDisplayNumberOfStudents.Location = new System.Drawing.Point(210, 198);
            this.labelDisplayNumberOfStudents.Name = "labelDisplayNumberOfStudents";
            this.labelDisplayNumberOfStudents.Size = new System.Drawing.Size(35, 13);
            this.labelDisplayNumberOfStudents.TabIndex = 6;
            // 
            // labelAverageAge
            // 
            this.labelAverageAge.AutoSize = true;
            this.labelAverageAge.Location = new System.Drawing.Point(303, 198);
            this.labelAverageAge.Name = "labelAverageAge";
            this.labelAverageAge.Size = new System.Drawing.Size(69, 13);
            this.labelAverageAge.TabIndex = 7;
            this.labelAverageAge.Text = "Average Age";
            // 
            // labelDisplayAverageAge
            // 
            this.labelDisplayAverageAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDisplayAverageAge.Location = new System.Drawing.Point(388, 198);
            this.labelDisplayAverageAge.Name = "labelDisplayAverageAge";
            this.labelDisplayAverageAge.Size = new System.Drawing.Size(35, 13);
            this.labelDisplayAverageAge.TabIndex = 8;
            // 
            // ListBoxExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 452);
            this.Controls.Add(this.labelDisplayAverageAge);
            this.Controls.Add(this.labelAverageAge);
            this.Controls.Add(this.labelDisplayNumberOfStudents);
            this.Controls.Add(this.labelNumberOfStudents);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxMaxAge);
            this.Controls.Add(this.checkBoxMaxAge);
            this.Controls.Add(this.listBoxStudentNames);
            this.Controls.Add(this.dataGridViewStudents);
            this.Name = "ListBoxExampleForm";
            this.Text = "List Box Example";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.ListBox listBoxStudentNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentAge;
        private System.Windows.Forms.CheckBox checkBoxMaxAge;
        private System.Windows.Forms.TextBox textBoxMaxAge;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelNumberOfStudents;
        private System.Windows.Forms.Label labelDisplayNumberOfStudents;
        private System.Windows.Forms.Label labelAverageAge;
        private System.Windows.Forms.Label labelDisplayAverageAge;
    }
}

