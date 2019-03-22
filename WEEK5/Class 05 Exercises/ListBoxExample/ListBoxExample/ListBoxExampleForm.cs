using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBoxExample
{
    /// <summary>
    /// Shows a set of students in a datagridview, with filters applied
    /// via a listbox and checkboxes
    /// If a name is selected in the listbox (which only consists of unique names),
    /// all of the students with that name are shown.
    /// 
    /// If the maxage checkbox is checked and a max age is given in a textbox, 
    /// then only those students less than the max age are shown.
    /// 
    /// The reset button resets everything to default, with all names selected in the listbox
    /// and checkbox/textbox cleared.
    /// </summary>
    public partial class ListBoxExampleForm : Form
    {
        // students, with many duplicate student names

        List<Student> students = new List<Student>()
         {
                new Student() {StudentID = 1, StudentName = "Jo", StudentAge = 21 },
                new Student() {StudentID = 2, StudentName = "Beth", StudentAge = 25},
                new Student() {StudentID = 3, StudentName = "Betty", StudentAge = 20 },
                new Student() {StudentID = 4, StudentName = "Tyrell", StudentAge = 18 },
                new Student() {StudentID = 5, StudentName = "Betty", StudentAge = 22},
                new Student() {StudentID = 6, StudentName = "Betty", StudentAge = 25 },
                new Student() {StudentID = 7, StudentName = "Tyrell", StudentAge = 19 },
                new Student() {StudentID = 8, StudentName = "Betty", StudentAge = 29},
                new Student() {StudentID = 9, StudentName = "Tyrell", StudentAge = 19 },
                new Student() {StudentID = 10, StudentName = "Jo", StudentAge = 50 },
                new Student() {StudentID = 11, StudentName = "Tyrell", StudentAge = 45 },
                new Student() {StudentID = 12, StudentName = "Jo", StudentAge = 39 },
                new Student() {StudentID = 13, StudentName = "Betty", StudentAge = 32 },
                new Student() {StudentID = 14, StudentName = "Betty", StudentAge = 49 },
                new Student() {StudentID = 15, StudentName = "Tyrell", StudentAge = 26 },

         };

        public ListBoxExampleForm()
        {
            InitializeComponent();

            // initialize controls

            InitializeDataGridViewStudents();

            InitializeListBoxStudentNames();

            // set all controls to defaults, and set listbox event handler

            ResetControlsToDefault();

            // set the event handlers for checkbox, textbox and button

            checkBoxMaxAge.CheckedChanged += CheckBoxMaxAge_CheckedChanged;
            buttonReset.Click += ButtonReset_Click;
            textBoxMaxAge.TextChanged += TextBoxMaxAge_TextChanged;
        }

        /// <summary>
        /// If the textbox has changed, and the checkbox is still checked, then redisplay students
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxMaxAge_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxMaxAge.Checked == true)
                DisplayStudents();
        }
        /// <summary>
        /// Reset all controls on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ResetControlsToDefault();
        }
        /// <summary>
        /// If maxage checkbox is checked, display all students less than the max age
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxMaxAge_CheckedChanged(object sender, EventArgs e)
        {
            DisplayStudents();
        }
        /// <summary>
        /// Display only selected students from the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxStudentNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayStudents();
        }

        /// <summary>
        /// Reset all controls to default settings.
        /// Textbox is cleared, all students are selected.
        /// SelectIndexChanged event needs to be off when selection is set, and then
        ///   reenabled.
        /// Finally, (re)display all students
        /// </summary>
        private void ResetControlsToDefault()
        {
            // set the defaults
            //  listbox student names are all selected
            //  maxAge box is unchecked and textbox is cleared

            // note how one must use SetSelected on an index instead of items
            // STUDY THIS!!

            // since we are resetting all student names in the listbox so they are selected
            // each time we do this, an event fires.
            // so we need to turn off the event first, reset the name selections, display the student data
            // and THEN set the event handler again.

            // unregister listbox event handler

            listBoxStudentNames.SelectedIndexChanged -= ListBoxStudentNames_SelectedIndexChanged;

            // set all of the listbox names to selected

            for (int i = 0; i < listBoxStudentNames.Items.Count; i++)
                listBoxStudentNames.SetSelected(i, true);

            // clear the checkbox and associated text

            checkBoxMaxAge.Checked = false;
            textBoxMaxAge.Clear();

            // redisplay students, which will see that all have been selected

            DisplayStudents();

            // register the listbox event handler again

            listBoxStudentNames.SelectedIndexChanged += ListBoxStudentNames_SelectedIndexChanged;
        }
        /// <summary>
        /// Display a unique set of student names in the listbox
        /// Also, set any other control properties.
        /// </summary>
        private void InitializeListBoxStudentNames()
        {
            listBoxStudentNames.Items.Clear(); // clear anything that was set up previously

            // ensure listbox selection can be multiple and can use shift, ctl-a, etc

            listBoxStudentNames.SelectionMode = SelectionMode.MultiSimple; // this is REQUIRED!!

            // get a list of unique student names and add to listbox

            // listBoxStudentNames.Items.AddRange(students.OrderBy(x => x.StudentName).Select(x => x.StudentName).Distinct().ToArray());

            var names = from student in students
                        orderby student.StudentName
                        select student.StudentName;

            listBoxStudentNames.Items.AddRange(names.Distinct().ToArray());
        }

        /// <summary>
        /// Set up the students datagridview control, including columns and column names
        /// </summary>
        private void InitializeDataGridViewStudents()
        {
            // control should be readonly, nothing can be changed
            dataGridViewStudents.ReadOnly = true;
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.RowHeadersVisible = false;

            // autofill the columns to the control width
            dataGridViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewStudents.Width = 400;

            // set up the columns and column names. first clear anything previously set.

            dataGridViewStudents.Columns.Clear();

            DataGridViewTextBoxColumn[] columns = new DataGridViewTextBoxColumn[] {
                new DataGridViewTextBoxColumn() { Name = "StudentID" },
                new DataGridViewTextBoxColumn() { Name = "Student Name" },
                new DataGridViewTextBoxColumn() { Name = "Age" },
                };

            dataGridViewStudents.Columns.AddRange(columns);

            // another way to add property names from a class to columns in datagridview
            // this uses reflection.

            dataGridViewStudents.Columns.Clear();

            foreach (PropertyInfo classProperty in (new Student()).GetType().GetProperties())
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn()
                {
                    Name = classProperty.Name,
                    ValueType = classProperty.GetType()
                };

                dataGridViewStudents.Columns.Add(column);
            }


        }

        /// <summary>
        /// Given selected students and a specified max age, display the students matching
        /// these.
        /// Then show statistics - number of students displayed, and their average age
        /// </summary>
        public void DisplayStudents()
        {
            // see if maxage checkbox was checked, if so get the max age

            int maxAge = 0;
            if(checkBoxMaxAge.Checked == true)
                int.TryParse(textBoxMaxAge.Text, out maxAge);

            // get the list of student names selected
            // note use of SelectedItems[index]
            // STUDY THIS

            List<string> selectedNames = new List<string>();

            for (int i = 0; i < listBoxStudentNames.SelectedItems.Count; i++)
                selectedNames.Add(listBoxStudentNames.SelectedItems[i].ToString());

            // now build a query joining names with students, filtering by maxage
            // note if Checked is true AND less than maxAge OR Checked is false makes the where clause evaluate to true
            //  and the student is selected

            var selectedStudents = from student in students
                                   join name in selectedNames on student.StudentName equals name
                                   where (checkBoxMaxAge.Checked == true && student.StudentAge < maxAge) || checkBoxMaxAge.Checked == false
                                   select student;

            // no join, using multiple from and where, same result as above

            var selectedStudents2 = from student in students
                                    from name in selectedNames
                                    where name == student.StudentName
                                    where (checkBoxMaxAge.Checked == true && student.StudentAge < maxAge) || checkBoxMaxAge.Checked == false
                                    select student;


            // now display the students in the datagridview

            dataGridViewStudents.Rows.Clear(); // clear old data first

            foreach (Student student in selectedStudents)
            {
                dataGridViewStudents.Rows.Add(student.StudentID, student.StudentName, student.StudentAge);                
            }

            // show statistics, note use of lambda for average age

            int numberOfStudents = selectedStudents.Count();
            labelDisplayNumberOfStudents.Text = numberOfStudents.ToString();

            if (numberOfStudents > 0)
                labelDisplayAverageAge.Text = selectedStudents.Average(s => s.StudentAge).ToString();
            else labelDisplayAverageAge.Text = "0";
        }
    }

    /// <summary>
    /// Student class, very simple
    /// </summary>
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StudentAge { get; set; }
    }
}
