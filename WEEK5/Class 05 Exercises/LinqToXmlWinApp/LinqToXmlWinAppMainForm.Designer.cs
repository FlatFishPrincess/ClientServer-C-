namespace LinqToXmlWinApp
{
  partial class LinqToXmlWinAppMainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDisplayInventory = new System.Windows.Forms.TextBox();
            this.groupBoxAddInventoryItem = new System.Windows.Forms.GroupBox();
            this.buttonAddNewItem = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.textBoxMake = new System.Windows.Forms.TextBox();
            this.labelMake = new System.Windows.Forms.Label();
            this.groupBoxColorsForMake = new System.Windows.Forms.GroupBox();
            this.buttonLookUpColors = new System.Windows.Forms.Button();
            this.textBoxMakeToLookUp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxAddInventoryItem.SuspendLayout();
            this.groupBoxColorsForMake.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Inventory";
            // 
            // textBoxDisplayInventory
            // 
            this.textBoxDisplayInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDisplayInventory.Location = new System.Drawing.Point(16, 39);
            this.textBoxDisplayInventory.Multiline = true;
            this.textBoxDisplayInventory.Name = "textBoxDisplayInventory";
            this.textBoxDisplayInventory.ReadOnly = true;
            this.textBoxDisplayInventory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDisplayInventory.Size = new System.Drawing.Size(255, 195);
            this.textBoxDisplayInventory.TabIndex = 1;
            // 
            // groupBoxAddInventoryItem
            // 
            this.groupBoxAddInventoryItem.Controls.Add(this.buttonAddNewItem);
            this.groupBoxAddInventoryItem.Controls.Add(this.textBoxName);
            this.groupBoxAddInventoryItem.Controls.Add(this.labelName);
            this.groupBoxAddInventoryItem.Controls.Add(this.textBoxColor);
            this.groupBoxAddInventoryItem.Controls.Add(this.labelColor);
            this.groupBoxAddInventoryItem.Controls.Add(this.textBoxMake);
            this.groupBoxAddInventoryItem.Controls.Add(this.labelMake);
            this.groupBoxAddInventoryItem.Location = new System.Drawing.Point(296, 39);
            this.groupBoxAddInventoryItem.Name = "groupBoxAddInventoryItem";
            this.groupBoxAddInventoryItem.Size = new System.Drawing.Size(301, 153);
            this.groupBoxAddInventoryItem.TabIndex = 2;
            this.groupBoxAddInventoryItem.TabStop = false;
            this.groupBoxAddInventoryItem.Text = "Add Inventory Item";
            // 
            // buttonAddNewItem
            // 
            this.buttonAddNewItem.Location = new System.Drawing.Point(167, 114);
            this.buttonAddNewItem.Name = "buttonAddNewItem";
            this.buttonAddNewItem.Size = new System.Drawing.Size(109, 23);
            this.buttonAddNewItem.TabIndex = 6;
            this.buttonAddNewItem.Text = "Add";
            this.buttonAddNewItem.UseVisualStyleBackColor = true;
            this.buttonAddNewItem.Click += new System.EventHandler(this.ButtonAddNewItem_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(77, 88);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 20);
            this.textBoxName.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(16, 88);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Name";
            // 
            // textBoxColor
            // 
            this.textBoxColor.Location = new System.Drawing.Point(76, 61);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(200, 20);
            this.textBoxColor.TabIndex = 3;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(15, 61);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(31, 13);
            this.labelColor.TabIndex = 2;
            this.labelColor.Text = "Color";
            // 
            // textBoxMake
            // 
            this.textBoxMake.Location = new System.Drawing.Point(76, 35);
            this.textBoxMake.Name = "textBoxMake";
            this.textBoxMake.Size = new System.Drawing.Size(200, 20);
            this.textBoxMake.TabIndex = 1;
            // 
            // labelMake
            // 
            this.labelMake.AutoSize = true;
            this.labelMake.Location = new System.Drawing.Point(15, 35);
            this.labelMake.Name = "labelMake";
            this.labelMake.Size = new System.Drawing.Size(34, 13);
            this.labelMake.TabIndex = 0;
            this.labelMake.Text = "Make";
            // 
            // groupBoxColorsForMake
            // 
            this.groupBoxColorsForMake.Controls.Add(this.buttonLookUpColors);
            this.groupBoxColorsForMake.Controls.Add(this.textBoxMakeToLookUp);
            this.groupBoxColorsForMake.Controls.Add(this.label5);
            this.groupBoxColorsForMake.Location = new System.Drawing.Point(296, 211);
            this.groupBoxColorsForMake.Name = "groupBoxColorsForMake";
            this.groupBoxColorsForMake.Size = new System.Drawing.Size(301, 105);
            this.groupBoxColorsForMake.TabIndex = 3;
            this.groupBoxColorsForMake.TabStop = false;
            this.groupBoxColorsForMake.Text = "Look up Colors for Make";
            // 
            // buttonLookUpColors
            // 
            this.buttonLookUpColors.Location = new System.Drawing.Point(126, 69);
            this.buttonLookUpColors.Name = "buttonLookUpColors";
            this.buttonLookUpColors.Size = new System.Drawing.Size(150, 23);
            this.buttonLookUpColors.TabIndex = 2;
            this.buttonLookUpColors.Text = "Look Up Colors";
            this.buttonLookUpColors.UseVisualStyleBackColor = true;
            this.buttonLookUpColors.Click += new System.EventHandler(this.ButtonLookUpColors_Click);
            // 
            // textBoxMakeToLookUp
            // 
            this.textBoxMakeToLookUp.Location = new System.Drawing.Point(126, 36);
            this.textBoxMakeToLookUp.Name = "textBoxMakeToLookUp";
            this.textBoxMakeToLookUp.Size = new System.Drawing.Size(150, 20);
            this.textBoxMakeToLookUp.TabIndex = 1;
            this.textBoxMakeToLookUp.Text = "BMW";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Make to Look Up";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 351);
            this.Controls.Add(this.groupBoxColorsForMake);
            this.Controls.Add(this.groupBoxAddInventoryItem);
            this.Controls.Add(this.textBoxDisplayInventory);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fun with LINQ to XML";
            this.Load += new System.EventHandler(this.LinqToXmlWinAppMainForm_Load);
            this.groupBoxAddInventoryItem.ResumeLayout(false);
            this.groupBoxAddInventoryItem.PerformLayout();
            this.groupBoxColorsForMake.ResumeLayout(false);
            this.groupBoxColorsForMake.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxDisplayInventory;
    private System.Windows.Forms.GroupBox groupBoxAddInventoryItem;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.TextBox textBoxColor;
    private System.Windows.Forms.Label labelColor;
    private System.Windows.Forms.TextBox textBoxMake;
    private System.Windows.Forms.Label labelMake;
    private System.Windows.Forms.Button buttonAddNewItem;
    private System.Windows.Forms.GroupBox groupBoxColorsForMake;
    private System.Windows.Forms.Button buttonLookUpColors;
    private System.Windows.Forms.TextBox textBoxMakeToLookUp;
    private System.Windows.Forms.Label label5;
  }
}

