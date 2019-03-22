using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Lab05RentalHousing
{
    public partial class RentalHousingForm : Form
    {
        // We keep the list of rental housing here

        List<NewWestminsterRentalHousing> rentalHousingList;

        public RentalHousingForm()
        {
            InitializeComponent();

            // load the rentalHousingList from the .xml file
            GetRentalHousingFromXML();

            // initialize the form's controls to default settings

            InitializeDataGridViewRentalHousing();

            InitializeAllOtherFormControls();

            // reset the listbox so neighborhoods are selected,
            // and the textbox is cleared

            ResetControlsToDefault();

            // TASK: Add the event handlers here
            //   use += tab and everything will be set up
            // buttonBuildingNameSearch.Click
            // buttonReset.Click
            //
            // then have each event method call the correct method
            // 


        }

        /// <summary>
        /// Set all relevant controls to their defaults.
        /// The listbox should have all items selected, and the textbox should be cleared.
        /// 
        /// Note we need to turn off SelectedIndexChanged before we select each listbox entry
        /// or it will trigger the event for EACH selection. A performance hit.
        /// </summary>
        private void ResetControlsToDefault()
        {
            // TASK: unregister the listbox SelectedIndexChanged event


            // TASK: add the code to clear the textbox and select all neighborhoods in the listbox


            // now show all of the selected neighborhoods in the datagridview control
            DisplayRentalHousing();

            // TASK: turn on the event handler for the listbox now that we have selected all

        }


        /// <summary>
        /// Initialize settings for the listbox and textbox.
        /// 
        /// Generate a unique list of neighborhoods and add them to the listbox
        /// </summary>
        public void InitializeAllOtherFormControls()
        {
            listBoxNeighborhoods.Items.Clear();
            listBoxNeighborhoods.Width = 200;
            listBoxNeighborhoods.SelectionMode = SelectionMode.MultiExtended;

            // TASK: create LINQ query or methods/lambdas to generate
            // a unique list of neighborhoods from the rentalHousingList
            // then add this list of neighborhoods to the listbox
            // make sure all neighborhoods are in UPPERCASE in the listbox

        }

        /// <summary>
        /// Display rental housing according to 
        /// </summary>
        public void DisplayRentalHousing()
        {
            // TASK: create a list of chosen neighborhoods from 
            //  listBoxNeighborhoods.SelectedItems (hint, iterate through these)
            //  get the building name from the textbox and convert to UPPERCASE
            //  generate a LINQ query to create a selectedHousing list of RentalHousing
            //     (hint: use a where statement with compound logic
            //     order by neighborhood and building name
            //  display the results of the query in the datagridview control
            //  finally, in the appropriate labels, 
            //     show the number of of apartments (basically, the record count)
            //     and the total number of residences


        }

        /// <summary>
        /// Initialize the datagridview control.
        /// Set the width, and have the columns autofill.
        /// Set other properties as needed
        /// 
        /// </summary>
        public void InitializeDataGridViewRentalHousing()
        {

            dataGridViewRentalHousing.ReadOnly = true;
            dataGridViewRentalHousing.AllowUserToAddRows = false;
            dataGridViewRentalHousing.RowHeadersVisible = false;
            dataGridViewRentalHousing.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRentalHousing.Width = 900;

            // the control's width based on the number of columns and their width

            dataGridViewRentalHousing.Columns.Clear();

            // TASK: create an array of DataGridViewTextBoxColumn, and set each
            // column name to the appropriate heading.
            //    add this array to the datagridview control (hint: Columns.AddRange())


        }

        /// <summary>
        /// Use Deserialize to get all RentalHousing from XML file
        /// </summary>
        private void GetRentalHousingFromXML()
        {
            // TASK: code to open a file using OpenFileDialog and returning a 
            // StreamReader object


            // TASK: two lines of code.
            // first, set up the XmlSerializer with a type of List<NewWestminsterRentalHousing>
            // second, deserialize and return a list set to rentalHousingList.
            // hint: cast or use as List<NewWestminsterRentalHousing>
            // make sure you close the file before the method exits.

        }

    }

    /// <summary>
    /// Rental Housing class. Note that it MUST be named NewWestminsterRentalHousing,
    /// as the xml file root is ArrayOfNewWestMinsterRentalHousing, and each element is
    /// NewWestminsterRentalHousing.
    /// 
    /// Do not touch this or the xmlserializer will not work
    /// </summary>
    /// 

   [Serializable]
    public class NewWestminsterRentalHousing
    {
        public string BuildingId { get; set; }
        public string Address { get; set; }
        public string BuildingName { get; set; }
        public int NumberOfResidences { get; set; }
        public string Neighborhood { get; set; }

        public override string ToString()
        {
            return $"{BuildingId},{Address},{BuildingName},{NumberOfResidences},{Neighborhood}";
        }
    }

}
