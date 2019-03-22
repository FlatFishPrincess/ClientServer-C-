namespace Lab05RentalHousing
{
    partial class RentalHousingForm
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
            this.dataGridViewRentalHousing = new System.Windows.Forms.DataGridView();
            this.labelNumberOfApartments = new System.Windows.Forms.Label();
            this.labelDisplayNumberOfApartments = new System.Windows.Forms.Label();
            this.labelTotalResidences = new System.Windows.Forms.Label();
            this.labelDisplayTotalResidences = new System.Windows.Forms.Label();
            this.listBoxNeighborhoods = new System.Windows.Forms.ListBox();
            this.buttonBuildingNameSearch = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxBuildingNameSearch = new System.Windows.Forms.TextBox();
            this.labelSelectNeighborhoods = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRentalHousing)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRentalHousing
            // 
            this.dataGridViewRentalHousing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRentalHousing.Location = new System.Drawing.Point(85, 24);
            this.dataGridViewRentalHousing.Name = "dataGridViewRentalHousing";
            this.dataGridViewRentalHousing.Size = new System.Drawing.Size(619, 287);
            this.dataGridViewRentalHousing.TabIndex = 0;
            // 
            // labelNumberOfApartments
            // 
            this.labelNumberOfApartments.AutoSize = true;
            this.labelNumberOfApartments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfApartments.Location = new System.Drawing.Point(82, 338);
            this.labelNumberOfApartments.Name = "labelNumberOfApartments";
            this.labelNumberOfApartments.Size = new System.Drawing.Size(153, 17);
            this.labelNumberOfApartments.TabIndex = 2;
            this.labelNumberOfApartments.Text = "Number Of Apartments";
            this.labelNumberOfApartments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDisplayNumberOfApartments
            // 
            this.labelDisplayNumberOfApartments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDisplayNumberOfApartments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplayNumberOfApartments.Location = new System.Drawing.Point(251, 337);
            this.labelDisplayNumberOfApartments.Name = "labelDisplayNumberOfApartments";
            this.labelDisplayNumberOfApartments.Size = new System.Drawing.Size(85, 18);
            this.labelDisplayNumberOfApartments.TabIndex = 3;
            this.labelDisplayNumberOfApartments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTotalResidences
            // 
            this.labelTotalResidences.AutoSize = true;
            this.labelTotalResidences.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalResidences.Location = new System.Drawing.Point(360, 338);
            this.labelTotalResidences.Name = "labelTotalResidences";
            this.labelTotalResidences.Size = new System.Drawing.Size(118, 17);
            this.labelTotalResidences.TabIndex = 4;
            this.labelTotalResidences.Text = "Total Residences";
            this.labelTotalResidences.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDisplayTotalResidences
            // 
            this.labelDisplayTotalResidences.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDisplayTotalResidences.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplayTotalResidences.Location = new System.Drawing.Point(494, 338);
            this.labelDisplayTotalResidences.Name = "labelDisplayTotalResidences";
            this.labelDisplayTotalResidences.Size = new System.Drawing.Size(85, 17);
            this.labelDisplayTotalResidences.TabIndex = 5;
            this.labelDisplayTotalResidences.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBoxNeighborhoods
            // 
            this.listBoxNeighborhoods.FormattingEnabled = true;
            this.listBoxNeighborhoods.Location = new System.Drawing.Point(85, 398);
            this.listBoxNeighborhoods.Name = "listBoxNeighborhoods";
            this.listBoxNeighborhoods.Size = new System.Drawing.Size(198, 173);
            this.listBoxNeighborhoods.TabIndex = 6;
            // 
            // buttonBuildingNameSearch
            // 
            this.buttonBuildingNameSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.buttonBuildingNameSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonBuildingNameSearch.Location = new System.Drawing.Point(332, 398);
            this.buttonBuildingNameSearch.Name = "buttonBuildingNameSearch";
            this.buttonBuildingNameSearch.Size = new System.Drawing.Size(106, 39);
            this.buttonBuildingNameSearch.TabIndex = 7;
            this.buttonBuildingNameSearch.Text = "Building Name Search";
            this.buttonBuildingNameSearch.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(412, 465);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // textBoxBuildingNameSearch
            // 
            this.textBoxBuildingNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBuildingNameSearch.Location = new System.Drawing.Point(466, 406);
            this.textBoxBuildingNameSearch.Name = "textBoxBuildingNameSearch";
            this.textBoxBuildingNameSearch.Size = new System.Drawing.Size(238, 23);
            this.textBoxBuildingNameSearch.TabIndex = 9;
            // 
            // labelSelectNeighborhoods
            // 
            this.labelSelectNeighborhoods.AutoSize = true;
            this.labelSelectNeighborhoods.Location = new System.Drawing.Point(82, 382);
            this.labelSelectNeighborhoods.Name = "labelSelectNeighborhoods";
            this.labelSelectNeighborhoods.Size = new System.Drawing.Size(112, 13);
            this.labelSelectNeighborhoods.TabIndex = 10;
            this.labelSelectNeighborhoods.Text = "Select Neighborhoods";
            // 
            // RentalHousingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 644);
            this.Controls.Add(this.labelSelectNeighborhoods);
            this.Controls.Add(this.textBoxBuildingNameSearch);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonBuildingNameSearch);
            this.Controls.Add(this.listBoxNeighborhoods);
            this.Controls.Add(this.labelDisplayTotalResidences);
            this.Controls.Add(this.labelTotalResidences);
            this.Controls.Add(this.labelDisplayNumberOfApartments);
            this.Controls.Add(this.labelNumberOfApartments);
            this.Controls.Add(this.dataGridViewRentalHousing);
            this.Name = "RentalHousingForm";
            this.Text = "New Westminster Rental Housing";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRentalHousing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRentalHousing;
        private System.Windows.Forms.Label labelNumberOfApartments;
        private System.Windows.Forms.Label labelDisplayNumberOfApartments;
        private System.Windows.Forms.Label labelTotalResidences;
        private System.Windows.Forms.Label labelDisplayTotalResidences;
        private System.Windows.Forms.ListBox listBoxNeighborhoods;
        private System.Windows.Forms.Button buttonBuildingNameSearch;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxBuildingNameSearch;
        private System.Windows.Forms.Label labelSelectNeighborhoods;
    }
}

