using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OpenFileDialogExample
{
    public partial class OpenFileDialogExampleForm : Form
    {
        /// <summary>
        /// Open a CSV file for reading, display it in a listBox,
        /// then write it to a file (should be .txt)
        /// 
        /// If the user selects an item in the ListBox, show it in a MessageBox
        /// </summary>
        public OpenFileDialogExampleForm()
        {
            InitializeComponent();


            // set up the selection in the ListBox by hand
            //  if not done in VS

            // listBoxOutput.SelectionMode = SelectionMode.MultiSimple;
            // listBoxOutput.SelectedIndexChanged += ListBoxItem_Click;

            OpenFileDialog openFileDialogCSV = new OpenFileDialog
            {
                // we start up in the debug directory, go two levels up to get to the main project area
                // note need to use Path.GetFullPath() as InitialDirectory does not like relative directories
                InitialDirectory = Path.GetFullPath(Application.StartupPath + "\\..\\.."),
                Filter = "CSV files|*.csv"
            };

            StreamReader inputFile;

            // open the filedialog, get a name, and open the file

            if (openFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                // could use new StreamReader() here as well
                inputFile = File.OpenText(openFileDialogCSV.FileName);
            }
            else return; // failure!!

            // for all of the lines in the file
            // read a line, and then split it using a , (comma) as a delimiter
            // then put it back together separated by a : and 
            // output to a listbox
            //
            // note use of StringBuilder so we can append
            // also, this is a bit of a silly example!

            while (inputFile.EndOfStream == false)
            {
                StringBuilder sb = new StringBuilder();
                string[] fields = inputFile.ReadLine()
                    .Split(',')
                    .Select(s => s.Trim())
                    .ToArray();

                for(int i = 0; i < fields.Length; i++)
                {
                    sb.Append(fields[i]);
                    // only append a : if NOT the last field
                    if (i < (fields.Length - 1))
                        sb.Append(" : ");
                }

                // populate the listBox with what was read in

                listBoxOutput.Items.Add(sb.ToString());                

            }

            // update the number of records on the form

            labelNumberOfRecords.Text += " = " + listBoxOutput.Items.Count;

            // now open a file for writing, and simply 
            // write the formatted lines from the listbox

            SaveFileDialog openFileToSave = new SaveFileDialog
            {
                InitialDirectory = Path.GetFullPath(Application.StartupPath + "\\..\\.."),
                Filter = "Text Files|*.txt"  // only allow .txt files for output
            };
            StreamWriter outputFile;

            if (openFileToSave.ShowDialog() == DialogResult.OK)
                outputFile = new StreamWriter(openFileToSave.FileName);
            else return;

            // write out what was shown in the listbox to the file

            foreach (var s in listBoxOutput.Items)
                outputFile.WriteLine(s);

            outputFile.Close(); // don't forget this or last buffer may not be written!

        }
        public void ListBoxItem_Click(object sender, EventArgs e)
        {
            foreach(string item in listBoxOutput.SelectedItems)
            {
                MessageBox.Show(item);
            }
        }

    }
}
