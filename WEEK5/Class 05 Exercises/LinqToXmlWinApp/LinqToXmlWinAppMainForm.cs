using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinqToXmlWinApp
{
    public partial class LinqToXmlWinAppMainForm : Form
    {
        public LinqToXmlWinAppMainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the form loads, display the Inventory.xml file
        /// Note use of static methods in LinqToXmlObjectModel class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinqToXmlWinAppMainForm_Load(object sender, EventArgs e)
        {
            // Display current XML inventory document in TextBox control. 
            // Inventory is from Inventory.xml file
            textBoxDisplayInventory.Text = LinqToXmlObjectModel.GetXmlInventory().ToString();
        }

        /// <summary>
        /// When Add button is clicked, update inventory with make, color and name from
        /// textBoxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddNewItem_Click(object sender, EventArgs e)
        {
            // Add new item to doc.
            LinqToXmlObjectModel.InsertNewElement(textBoxMake.Text, textBoxColor.Text, textBoxName.Text);

            // Display current XML inventory document in TextBox control. 
            textBoxDisplayInventory.Text = LinqToXmlObjectModel.GetXmlInventory().ToString();
        }

        /// <summary>
        /// When lookup colors button is clicked, display all of the colors that a make has
        /// in a message box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLookUpColors_Click(object sender, EventArgs e)
        {
            LinqToXmlObjectModel.LookUpColorsForMake(textBoxMakeToLookUp.Text);
        }
    }
}
