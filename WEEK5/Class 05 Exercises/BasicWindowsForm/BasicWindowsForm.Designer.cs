namespace BasicWindowsForm
{
    partial class BasicWindowsForm
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
            this.labelOutput = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.labelOutputLabel = new System.Windows.Forms.Label();
            this.labelInputText = new System.Windows.Forms.Label();
            this.buttonAddText = new System.Windows.Forms.Button();
            this.textBoxButtonInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelOutput
            // 
            this.labelOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelOutput.Location = new System.Drawing.Point(102, 28);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(158, 18);
            this.labelOutput.TabIndex = 0;
            // 
            // textBoxInput
            // 
            this.textBoxInput.AcceptsReturn = true;
            this.textBoxInput.Location = new System.Drawing.Point(102, 63);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(129, 19);
            this.textBoxInput.TabIndex = 1;
            this.textBoxInput.TextChanged += new System.EventHandler(this.TextBoxInput_TextChanged);
            // 
            // labelOutputLabel
            // 
            this.labelOutputLabel.AutoSize = true;
            this.labelOutputLabel.Location = new System.Drawing.Point(15, 32);
            this.labelOutputLabel.Name = "labelOutputLabel";
            this.labelOutputLabel.Size = new System.Drawing.Size(39, 13);
            this.labelOutputLabel.TabIndex = 2;
            this.labelOutputLabel.Text = "Output";
            // 
            // labelInputText
            // 
            this.labelInputText.AutoSize = true;
            this.labelInputText.Location = new System.Drawing.Point(-2, 69);
            this.labelInputText.Name = "labelInputText";
            this.labelInputText.Size = new System.Drawing.Size(86, 13);
            this.labelInputText.TabIndex = 3;
            this.labelInputText.Text = "Type in text here";
            // 
            // buttonAddText
            // 
            this.buttonAddText.Location = new System.Drawing.Point(12, 108);
            this.buttonAddText.Name = "buttonAddText";
            this.buttonAddText.Size = new System.Drawing.Size(75, 23);
            this.buttonAddText.TabIndex = 4;
            this.buttonAddText.Text = "Click to add";
            this.buttonAddText.UseVisualStyleBackColor = true;
            // 
            // textBoxButtonInput
            // 
            this.textBoxButtonInput.Location = new System.Drawing.Point(102, 111);
            this.textBoxButtonInput.Name = "textBoxButtonInput";
            this.textBoxButtonInput.Size = new System.Drawing.Size(129, 20);
            this.textBoxButtonInput.TabIndex = 5;
            // 
            // BasicWindowsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 183);
            this.Controls.Add(this.textBoxButtonInput);
            this.Controls.Add(this.buttonAddText);
            this.Controls.Add(this.labelInputText);
            this.Controls.Add(this.labelOutputLabel);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.labelOutput);
            this.Name = "BasicWindowsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelOutputLabel;
        private System.Windows.Forms.Label labelInputText;
        private System.Windows.Forms.Button buttonAddText;
        private System.Windows.Forms.TextBox textBoxButtonInput;
    }
}

