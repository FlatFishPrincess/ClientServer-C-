namespace OpenFileDialogExample
{
    partial class OpenFileDialogExampleForm
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
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.labelNumberOfRecords = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.HorizontalScrollbar = true;
            this.listBoxOutput.Location = new System.Drawing.Point(81, 56);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxOutput.Size = new System.Drawing.Size(409, 251);
            this.listBoxOutput.TabIndex = 0;
            this.listBoxOutput.SelectedIndexChanged += new System.EventHandler(this.ListBoxItem_Click);
            // 
            // labelNumberOfRecords
            // 
            this.labelNumberOfRecords.AutoSize = true;
            this.labelNumberOfRecords.Location = new System.Drawing.Point(78, 19);
            this.labelNumberOfRecords.Name = "labelNumberOfRecords";
            this.labelNumberOfRecords.Size = new System.Drawing.Size(99, 13);
            this.labelNumberOfRecords.TabIndex = 1;
            this.labelNumberOfRecords.Text = "Number of Records";
            // 
            // FormOpenFileDialogExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 375);
            this.Controls.Add(this.labelNumberOfRecords);
            this.Controls.Add(this.listBoxOutput);
            this.Name = "FormOpenFileDialogExample";
            this.Text = "Open File Dialog Example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxOutput;
        private System.Windows.Forms.Label labelNumberOfRecords;
    }
}

