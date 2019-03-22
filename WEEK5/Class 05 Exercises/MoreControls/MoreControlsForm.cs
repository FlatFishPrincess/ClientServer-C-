using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoreControls
{
    public partial class MoreControlsForm : Form
    {
        School[] postSecondarySchools = new School[] {
            new School("UBC", SchoolType.University, 55000),
            new School("SFU", SchoolType.University, 40000),
            new School("BCIT", SchoolType.Technical, 25000),
            new School("UVic", SchoolType.University, 30000),
            new School("Douglas", SchoolType.College, 20000),
            new School("Langara", SchoolType.College, 22000),
            new School("Sprott Shaw", SchoolType.Vocational, 8000)
        };

        public MoreControlsForm()
        {
            InitializeComponent();

            Text = "MoreControls";

            // reset all listboxes with full data
            // and all checkboxes and radio buttons to clear

            Reset();

            // set up the reset button

            buttonReset.Text = "Reset";
            buttonReset.Click += ButtonReset_Click;

            // demonstrates use of list box selection

            // allow use of ctl and shift
            listBoxCheckedSchools.SelectionMode = SelectionMode.MultiExtended;
            listBoxCheckedSchools.SelectedIndexChanged += ListBox_SelectedIndexChanged;

            // simple multi select enabled
            listBoxButtonSchools.SelectionMode = SelectionMode.MultiSimple;
            listBoxButtonSchools.SelectedIndexChanged += ListBox_SelectedIndexChanged;
 
        }

        /// <summary>
        /// display selected items in a list box using a message box
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;

            // use a for loop
            //for (int i = 0; i < listBox.SelectedItems.Count; i++)
            //MessageBox.Show(listBox.SelectedItems[i].ToString());

            //MessageBox.Show(listBox.SelectedItem.ToString() + "selectedItem");
            // use foreach since we know it is a string
            foreach (object listItem in listBox.SelectedItems)
                MessageBox.Show(listItem.ToString());
        }

        /// <summary>
        /// Event handler for reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        /// <summary>
        /// Clear all radio buttons and checkboxes and reset event handlers
        /// Show data for all schools in each listbox
        /// </summary>
        private void Reset()
        {
            // clear the checkboxes, and turn off/turn on event handler

            foreach(CheckBox checkBox in groupBoxSelectSchoolTypeCheckBoxes.Controls)
            {
                checkBox.CheckedChanged -= CheckBox_Checked;
                 checkBox.CheckedChanged += new System.EventHandler(CheckBox_Checked);
                // checkBox.AutoCheck = false;  // don't check anything to start
                checkBox.Checked = false;
                checkBox.CheckedChanged += CheckBox_Checked;
            }

            // clear the radio buttons and turn off/turn on event handler

            foreach (RadioButton radioButton in groupBoxSchoolTypeRadioButtons.Controls)
            {
                radioButton.CheckedChanged -= RadioButton_Checked;
                // radioButton.AutoCheck = false;  // don't check anything to start
                radioButton.Checked = false;
                radioButton.CheckedChanged += RadioButton_Checked;
            }


            // show all of the schools in each list box
            listBoxButtonSchools.Items.Clear();
            listBoxButtonSchools.Items.AddRange(postSecondarySchools); // easy due to tostring() method in School class

            listBoxCheckedSchools.Items.Clear();
            listBoxCheckedSchools.Items.AddRange(postSecondarySchools);
        }

        /// <summary>
        /// This is the event handler for any radio button that was checked.
        /// First see if anything got checked, then determine which radio
        ///     button was responsible.
        /// Figure out the type of school, then look it up using LINQ query.
        /// Finally, display the results of the query.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void RadioButton_Checked(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            // Was it checked?

            if (radioButton.Checked == false)
                return;

            // set school type according to radio button checked

            SchoolType selectedSchoolType = SchoolType.Vocational;

            if (radioButton == radioButtonUniversity)
                selectedSchoolType = SchoolType.University;
            else if (radioButton == radioButtonCollege)
                selectedSchoolType = SchoolType.College;
            else if (radioButton == radioButtonTechnical)
                selectedSchoolType = SchoolType.Technical;
            else if (radioButton == radioButtonVocational)
                selectedSchoolType = SchoolType.Vocational;

            // look up the type

            var query =
                 from school in postSecondarySchools
                 where school.SchoolType == selectedSchoolType
                 select school;

            // display in the listBox

            listBoxButtonSchools.Items.Clear();

            foreach (School school in query)
                listBoxButtonSchools.Items.Add(school);

        }

        /// <summary>
        /// This is the event handler for the checkBox group. We could use the 
        /// same logic as for the radio button, but instead use a complex LINQ query. 
        /// 
        /// The query examines school type, and if it matches, then looks to see which
        ///     checkBox was checked. Both conditions have to be true in order for the 
        ///     school to be selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Checked(object sender, EventArgs e)
        {
            CheckBox schoolCheckBox = sender as CheckBox;

            // SchoolType enum is equal to the school in school array && checked school type in check box is true, 
            // the get the school from the array school
            // If university and univeristy is checked, get universities from array and put them into query
            var query =
                from school in postSecondarySchools
                where (school.SchoolType == SchoolType.University && checkBoxUniversity.Checked == true) ||
                    (school.SchoolType == SchoolType.College && checkBoxCollege.Checked == true) ||
                    (school.SchoolType == SchoolType.Technical && checkBoxTechnical.Checked == true) ||
                    (school.SchoolType == SchoolType.Vocational && checkBoxVocational.Checked == true)
                select school;

            // display in the listBox

            listBoxCheckedSchools.Items.Clear();

            foreach (School school in query)
                listBoxCheckedSchools.Items.Add(school);

        }
    }
}
