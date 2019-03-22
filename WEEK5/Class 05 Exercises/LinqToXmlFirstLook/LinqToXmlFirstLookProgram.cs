using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// For older DOM support.
using System.Xml;

// For newer LINQ to XML support. 
using System.Xml.Linq;

namespace LinqToXmlFirstLook
{
    class LinqToXmlFirstLookProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** A Tale of Two XML APIs *****");
            BuildXmlDocWithDOM();
            BuildXmlDocWithLINQToXml();

            Console.WriteLine("XML data saved to output directory.");

            // Delete a node. 
            DeleteNodeFromDoc();
            Console.ReadLine();
        }

        #region Build XML file using System.Xml.dll types.
        private static void BuildXmlDocWithDOM()
        {
            Console.WriteLine("XmlDocwithDOM()");
            // Make a new XML document in memory.
            XmlDocument doc = new XmlDocument();

            // Fill this document with a root element
            // named <Inventory>.
            XmlElement inventory = doc.CreateElement("Inventory");

            // Now, make a sub element named <Car> with 
            // an ID attribute. 
            XmlElement car = doc.CreateElement("Car");
            car.SetAttribute("ID", "1000");

            // Build the data within the <Car> element. 
            XmlElement name = doc.CreateElement("Name");
            
            // name.Value = "Jimbo"; // this won't work!
            name.InnerText = "Jimbo";
            XmlElement color = doc.CreateElement("Color");
            color.InnerText = "Red";
            XmlElement make = doc.CreateElement("Make");
            make.InnerText = "Ford";

            // Add <Name>, <Color> and <Make> to the <Car>
            // element. 
            car.AppendChild(name);
            car.AppendChild(color);
            car.AppendChild(make);

            // Add the <Car> element to the <Inventory> element. 
            inventory.AppendChild(car);

            // Insert the complete XML into the XmlDocument object,
            // and save to file. 
            doc.AppendChild(inventory);
            doc.Save("Inventory.xml");
        }
        #endregion

        #region Build XML doc with LINQ to XML
        private static void BuildXmlDocWithLINQToXml()
        {
            Console.WriteLine("XmlDocwithLINQ()");

            // Create a 'functional' XML document.
            XElement doc =
                new XElement("Inventory",   // Root
                    new XElement("Car", new XAttribute("ID", "1000"),   // Car node with ID
                        new XElement("Name", "Jimbo"),  // Car elements and values
                        new XElement("Color", "Red"),
                        new XElement("Make", "Ford")
                    )
                );

            // Save to file.
            doc.Save("InventoryWithLINQ.xml");
        }
        #endregion

        #region Remove an element.
        private static void DeleteNodeFromDoc()
        {
            // Create a 'functional' XML document.
            XElement doc =
                new XElement("Inventory",
                    new XElement("Car", new XAttribute("ID", "1000"),
                        new XElement("Name", "Jimbo"),
                        new XElement("Color", "Red"),
                        new XElement("Make", "Ford")
                    )
                );
            Console.WriteLine("DeleteNodeFromDoc()\nIn memory inventory XML doc");
            Console.WriteLine(doc);
            Console.WriteLine("Now remove the Name element");
            // Delete the Name element from the tree. 
            doc.Descendants("Name").Remove();
            Console.WriteLine("Revised car document");
            Console.WriteLine(doc);
        }
        #endregion
    }
}
