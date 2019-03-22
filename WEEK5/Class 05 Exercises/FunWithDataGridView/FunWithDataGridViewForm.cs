using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunWithDataGridView
{
    /// <summary>
    /// Populate a dataGridView control with school information
    ///    name, type, enrolment
    /// When button is clicked, show each school's info on a separate line
    ///     in a listBox, pulling data from the dataGridView control, as 
    ///     the user will have entered other schools.
    /// This demonstrates iterating through dataGridView data
    /// 
    /// </summary>
    public partial class FunWithDataGridViewForm : Form
    {
        public FunWithDataGridViewForm()
        {
            InitializeComponent();

            // set list box so multiple items can be selected

            listBoxOutput.SelectionMode = SelectionMode.MultiSimple;

            // this can be done with double tab!!

            listBoxOutput.SelectedIndexChanged += ListBoxOutput_SelectedIndexChanged;
 
            // shows how to add rows to the grid

            dataGridViewSchools.Rows.Add(new string[] { "UBC", "University", "50000" });
            dataGridViewSchools.Rows.Add(new string[] { "SFU", "University", "30000" });
        }

        /// <summary>
        /// event handler that simply shows all of the selected items in a message box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string item in listBoxOutput.SelectedItems)
                MessageBox.Show(item);
        }

        /// <summary>
        /// display grid data in a listbox with values separated by colons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonShowGridData_Click(object sender, EventArgs e)
        {
            listBoxOutput.Items.Clear(); // clear the listBox first

            // build a string for displaying the school data

            StringBuilder school = new StringBuilder();

            // iterate through rows then columns to get each cell value

            int totalEnrolment = 0; // to keep total enrolment of all schools

            foreach (DataGridViewRow row in dataGridViewSchools.Rows)
            {
                school.Clear();  // clear the string

                // for every cell in the row, add the cell value to the string
                // this is the info for an individual school

                foreach (DataGridViewCell cell in row.Cells)
                {
                    // make sure the cell value exists
                    if (cell.Value != null)
                    {
                        // get the value of the cell and convert

                        school.Append(cell.Value.ToString());

                        // if not at the last cell, add a :

                        if (cell.ColumnIndex != row.Cells.Count - 1)
                            school.Append(":");

                        // if our column is school size, add this to the total enrolment
                        if (cell.OwningColumn.HeaderText == "School Size")
                        {
                            int.TryParse(cell.Value.ToString(), out int enrolment);
                            totalEnrolment += enrolment;
                        }
                            
                    }
                }

                // string has been built, so add it to the listBox
                if (school.Length > 0)
                    listBoxOutput.Items.Add(school.ToString());

            }
            listBoxOutput.Items.Add("Total Enrolment = " + totalEnrolment);
        }
        
    }
}
