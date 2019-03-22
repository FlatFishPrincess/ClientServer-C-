using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XMLSerialize
{
    #region Types to serialize
    /// <summary>
    /// Car class 
    ///   has a Radio
    ///   may be a hatchback
    /// 
    /// Can name child or parent XMLRoot
    /// Each is Serializable, meaning it can be written to and read from a file
    /// </summary>
    [Serializable]
    [XmlRoot]
    public class Car
    {
        public Car(string name, bool hatchBack)
        {
            Name = name;
            isHatchBack = hatchBack;
        }
        public Car() { }
        public string Name { get; set; }

        public Radio theRadio = new Radio();
        public bool isHatchBack;

    }

    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;

        [NonSerialized]
        public string radioID = "XF-552RR6";
    }

    [Serializable]
    public class SecretAgentCar : Car
    {
        [XmlAttribute]
        public bool canFly;
        [XmlAttribute]
        public bool canSubmerge;

        public SecretAgentCar(string name, bool hatchBack, bool skyWorthy, bool seaWorthy)
            : base(name, hatchBack)
        {
            canFly = skyWorthy;
            canSubmerge = seaWorthy;
        }
        // The XmlSerializer demands a default constructor
        public SecretAgentCar() : base("", false) { }

    }

    #endregion

    class XMLSerializeProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with XML Serialization *****\n");

            // Make a JamesBondCar and set state.
            SecretAgentCar jamesBondCar = new SecretAgentCar
            {
                Name = "Maserati",
                //isHatchBack = true,
                canFly = true,
                canSubmerge = false,
                theRadio = new Radio()
                {
                    stationPresets = new double[] { 89.3, 105.1, 97.1 },
                    hasSubWoofers = true,
                    hasTweeters = true
                }
            };

            // save the above to a file

            SaveObjectAsXML(jamesBondCar, typeof(SecretAgentCar), "JamesBondCar.xml");

            Car myCar = new Car()
            {
                Name = "Honda",
                isHatchBack = true
            };

            // save this to another file

            SaveObjectAsXML(myCar, typeof(Car), "SingleCar.xml");

            // save a list of cars to an xml file using XMLSerialize
            // and read it back

            SaveListOfSecretAgentCars("SecretAgentCars.xml");

            ReadListOfSecretAgentCars("SecretAgentCars.xml");

            Console.ReadLine();
        }

        /// <summary>
        /// Use XMLSerializer to save a single object to a file
        /// </summary>
        /// <param name="myCar">some object, although we know it is a car</param>
        /// <param name="carType">the object type</param>
        /// <param name="fileName">filename to save the object to</param>
        static void SaveObjectAsXML(object myCar, Type carType, string fileName)
        {
            // Save object to a file in XML format.

            // create the serializer

            XmlSerializer carSerializer = new XmlSerializer(carType);

            // open the file for writing
            StreamWriter fileStream = new StreamWriter(fileName);

            // serialize the data to the file. don't forget to close it
            carSerializer.Serialize(fileStream, myCar);
            fileStream.Close();
            Console.WriteLine($"=> Saved car in {fileName} in XML format");
        }

        /// <summary>
        /// Save a list of cars to an xml file
        /// </summary>
        /// <param name="fileName">name of the xml file</param>
        static void SaveListOfSecretAgentCars(string fileName)
        {
            // a list of JamesBondCars.
            List<SecretAgentCar> myCars = new List<SecretAgentCar>
            {
                new SecretAgentCar("Bentley", false, true, true),
                new SecretAgentCar("HumVee", true, true, false),
                new SecretAgentCar("Corvette", true, false, true),
                new SecretAgentCar("Rolls Royce", false, false, false),
                new SecretAgentCar("Maclaren", false, true, true)

            };

            // open the file for writing

            StreamWriter fileStream = new StreamWriter(fileName);

            // create the serializer, write the file, and close it

            XmlSerializer secretAgentCarSerializer = new XmlSerializer(typeof(List<SecretAgentCar>));
            secretAgentCarSerializer.Serialize(fileStream, myCars);

            fileStream.Close();

            Console.WriteLine($"=> Saved list of cars to {fileName}");
        }

        /// <summary>
        /// read a list of secret agent cars from a file
        /// </summary>
        /// <param name="fileName">xml file containing the list of cars</param>
        static void ReadListOfSecretAgentCars(string fileName)
        {
            List<SecretAgentCar> myCars;  // list to be populated

            // open the file for reading

            StreamReader carsFile = new StreamReader(fileName);

            // create the serializer, note use of typeof
            XmlSerializer secretAgentCarSerializer = new XmlSerializer(typeof(List<SecretAgentCar>));

            // deserialize to the list of cars from file, note use of cast

            myCars = secretAgentCarSerializer.Deserialize(carsFile) as List<SecretAgentCar>;
            carsFile.Close();
            Console.WriteLine($"=> Reading list of cars from {fileName}");

            // display

            foreach (SecretAgentCar car in myCars)
            {
                Console.WriteLine($"{car.Name} flies {car.canFly}, goes under water {car.canSubmerge}, \n"
                    + $"\thatchback {car.isHatchBack}, radio {car.theRadio.radioID} subwoofers {car.theRadio.hasSubWoofers}");
            }
        }

    }
}
