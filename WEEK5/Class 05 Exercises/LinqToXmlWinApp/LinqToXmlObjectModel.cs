using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using System.Windows.Forms;

namespace LinqToXmlWinApp
{
    /// <summary>
    /// utility class to manipulate XML files
    /// </summary>
    /// 
    static class LinqToXmlObjectModel
    {
        #region Load XML doc
        /// <summary>
        /// Get the car inventory from an xml file
        /// </summary>
        /// <returns>XDocument containing inventory or a null if the file is not found</returns>
        public static XDocument GetXmlInventory()
        {
            try
            {
                return XDocument.Load("Inventory.xml");
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        #endregion

        #region Insert new item

        /// <summary>
        /// Insert a new element in the XML XDocument and save to disk
        /// </summary>
        /// <param name="make"></param>
        /// <param name="color"></param>
        /// <param name="name"></param>
        public static void InsertNewElement(string make, string color, string name)
        {
            // Load current document. 
            XDocument inventoryDoc = XDocument.Load("Inventory.xml");

            // Generate a random number for the ID.
            Random r = new Random();

            // Make new XElement based on incoming parameters. 
            XElement newElement = new XElement("Car", new XAttribute("ID", r.Next(50000)),
                      new XElement("Color", color),
                      new XElement("Make", make),
                      new XElement("Name", name));

            // Add to in-memory object.
            inventoryDoc.Descendants("Inventory").First().Add(newElement);

            // Save changes to disk.
            inventoryDoc.Save("Inventory.xml");
        }
        #endregion

        #region Query doc

        /// <summary>
        /// Given a car make, show all of the colors associated with that make
        /// </summary>
        /// <param name="make">string containing the make to be looked up</param>
        public static void LookUpColorsForMake(string make)
        {
            // Load current document. 
            XDocument inventoryDoc = XDocument.Load("Inventory.xml");

            // Find the colors for a given make.
            var makeColors = from car in inventoryDoc.Descendants("Car")
                           //where (string)car.Element("Make") == make
                           where car.Element("Make").Value == make
                           select car.Element("Color").Value;

            // Build a string representing each color. 
            // Get all of the unique colors in the list, and display
            //  each on a separate line in a MessageBox
            string colorsString = "";
            foreach (var color in makeColors.Distinct())
            {
                colorsString += string.Format($"- {color}\n");
            }

            // Show colors. 
            MessageBox.Show(colorsString, $"{make} colors:");
        }
        #endregion
    }
}
