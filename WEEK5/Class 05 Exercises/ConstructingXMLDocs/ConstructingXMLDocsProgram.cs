using System;
using System.Linq;
using System.Xml.Linq;
using static System.Console;

namespace ConstructingXmlDocs
{
    class ConstructingXMLDocsProgram
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun making XML docs! *****");
            CreateFullXDocument();
            ReadLine();

            CreateRootAndChildren();
            ReadLine();

            MakeXElementFromArray();
            WriteLine();

            ParseAndLoadExistingXml();
            ReadLine();
        }

        #region Create full XDocument
        /// <summary>
        /// Create an xml document of cars and save it to a file
        /// </summary>
        static void CreateFullXDocument()
        {
            WriteLine("CreateFullXDocument()");

            // root document Inventory has three cars
            XDocument inventoryDoc =
              new XDocument(
                new XComment("Current Inventory of cars!"),
                new XProcessingInstruction("xml-stylesheet",
                  "href='MyStyles.css' title='Compact' type='text/css'"),
                // <?xml-stylesheet href='MyStyles.css' title='Compact' type='text/css'?>
                new XElement("Inventory",
                    new XElement("Car", new XAttribute("ID", "1"),
                        new XElement("Color", "Green"),
                        new XElement("Make", "BMW"),
                        new XElement("Name", "Stan")
                    ),
                    new XElement("Car", new XAttribute("ID", "2"),
                        new XElement("Color", "Pink"),
                        new XElement("Make", "Yugo"),
                        new XElement("Name", "Melvin")
                    ),
                    new XElement("Car", new XAttribute("ID", "5"),
                        new XElement("Color", "Red"),
                        new XElement("Make", "Honda"),
                        new XElement("Name", "Henry")
                    )
                )
              );

            // add another element
            inventoryDoc.Root.Add(
                    new XElement("Car", new XAttribute("ID", "7"),
                        new XElement("Color", "Orange"),
                        new XElement("Make", "Toyota"),
                        new XElement("Name", "Tomi")
                    )
                 );
            Console.WriteLine(inventoryDoc);

            // save this to disk

            inventoryDoc.Save("FullXmlDoc.xml");

            WriteLine("Saved inventory to FullXmlDoc.xml");

        }
        #endregion

        #region Make XElement and save to disk.

        /// <summary>
        /// Same as above, but now add ID attribute
        /// </summary>
        static void CreateRootAndChildren()
        {
            WriteLine("CreateRootAndChildren()");

            // create root Inventory and add two car elements.
            // note use of ID attribute

            XElement inventoryDoc =
              new XElement("Inventory",
                    new XComment("Current Inventory of cars!"),
                    new XElement("Car", new XAttribute("ID", "1"),
                        new XElement("Color", "Green"),
                        new XElement("Make", "BMW"),
                        new XElement("Name", "Stan")
                    ),
                    new XElement("Car", new XAttribute("ID", "2"),
                        new XElement("Color", "Pink"),
                        new XElement("Make", "Yugo"),
                        new XElement("Name", "Melvin")
                    )
              );

            // Inventory is root, so simply add another car element to it

            inventoryDoc.Add(
                    new XElement("Car", new XAttribute("ID", "5"),
                        new XElement("Color", "Red"),
                        new XElement("Make", "Honda"),
                        new XElement("Name", "Henry")
                    )
                 );

            WriteLine("Displaying car inventory using toString()");

            WriteLine(inventoryDoc);
            // Save to disk.
            inventoryDoc.Save("SimpleInventory.xml");
            WriteLine("Saved inventory to SimpleInventory.xml");

        }
        #endregion

        #region Map array to XElement
        /// <summary>
        /// Use linq and an array to make an xml doc
        /// </summary>
        static void MakeXElementFromArray()
        {
            WriteLine("MakeXElementFromArray()");
            // Create an anonymous array of anonymous types.
            var people = new[] {
                new { FirstName = "Mandy", Age = 40},
                new { FirstName = "Andrew", Age  = 32 },
                new { FirstName = "Dave", Age  = 41 },
                new { FirstName = "Sara", Age  = 31}
            };

            //XElement peopleDoc =
            //  new XElement("People",
            //     from person in people
            //     select
            //        new XElement("Person", new XAttribute("Age", person.Age), new XElement("FirstName", person.FirstName))
            //   );

            // Convert each array element to an array/list of XElements
            // Note use of age as an attribute here

            var peopleXElementArray = from person in people
                                       select
                                       new XElement("Person",
                                           new XAttribute("Age", person.Age),
                                           new XElement("FirstName", person.FirstName));

            // create the root document and add the people array to it

            XElement peopleDoc = new XElement("People", peopleXElementArray);

            WriteLine("Display XML list of people using toString()");
            WriteLine(peopleDoc);
            peopleDoc.Save("PeopleArray.xml");
            WriteLine("PeopleArray.xml saved");
        }
        #endregion

        #region Parse / Load
        /// <summary>
        /// Shows parsing an xml formatted string into an XElement
        /// Also shows reading in an xml file and displaying elements.
        /// 
        /// Note: this can be used to read in any xml file and place the data in
        /// an object. Alternative to XMLSerialize.
        /// </summary>
        static void ParseAndLoadExistingXml()
        {
            WriteLine("ParseAndLoadExistingXML()");
            // Build an XElement from string and display
            string myElement =
              @"<Car ID ='3'>
                  <Color>Yellow</Color>
                  <Make>Yugo</Make>
                </Car>";

            WriteLine("Parsing Car ID 3 Yugo and displaying using toString()");
            XElement newElement = XElement.Parse(myElement);
            Console.WriteLine(newElement);
            Console.WriteLine();

            WriteLine("Reading SimpleInventory.xml");
            // Load the SimpleInventory.xml file.
            XDocument carDocument = XDocument.Load("SimpleInventory.xml");

            // for each element in the root 
            // display any attributes and values, and then element name and value
            WriteLine("Displaying car data iterating through elements");
            foreach (XElement inventory in carDocument.Elements())
            {
                // really only one element in the root - Inventory

                WriteLine(inventory.Name);

                // now iterate through all the cars 
                foreach (XElement car in inventory.Elements())
                {
                    // display the ID attribute, but should check for null here

                    XAttribute carAttribute = car.Attributes().First();
                    WriteLine(carAttribute.Name + " = " + carAttribute.Value); // <car id="4">

                    // now display each car element with name and value

                    foreach (XElement carElement in car.Elements())
                    {
                        WriteLine(carElement.Name + " = " + carElement.Value);
                    }
 
                }
            }

            // do the same using descendants

            WriteLine("Displaying car data using Descendants() and choosing elements ID and Name specifically");
            foreach (XElement car in carDocument.Descendants("Car"))
            {
                WriteLine("ID = " + car.Attribute("ID").Value);
                WriteLine("Color = " + car.Element("Color").Value);
                WriteLine("Make = " + car.Element("Make").Value);
                WriteLine("Name = " + car.Element("Name").Value);
            }

            WriteLine("Displaying the original XML doc using toString()");
            WriteLine(carDocument);
        }
        #endregion
    }
}
