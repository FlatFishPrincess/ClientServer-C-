using System.Collections;
using CommonCar;

namespace CustomEnumerator
{
    /// <summary>
    /// Garage contains a set of Car objects.
    /// </summary>

    public class Garage : IEnumerable
    {
        private Car[] myAutos;

        /// <summary>
        /// Fill with some Car objects upon startup.
        /// We typically wouldn't hide an array like this, but it shows the use of GetEnumerator()
        /// </summary>
        public Garage()
        {
            myAutos = new Car[]
            {
                new Car() { CarName = "Rusty", CurrentSpeed = 80, CarID = 1},
                new Car() { CarName = "Mary", CurrentSpeed = 40, CarID = 234},
                new Car() { CarName = "Viper", CurrentSpeed = 40, CarID = 34},
                new Car() { CarName = "Mel", CurrentSpeed = 40, CarID = 4},
                new Car() { CarName = "Chucky", CurrentSpeed = 40, CarID = 5},
                // null
            };
        }

        /// <summary>
        /// Return the enumerator for the array of cars. 
        /// If you comment out IEnumerable and the code below, foreach will not compile!
        /// It requires GetEnumerator.
        /// Gets the next item in myAutos.
        /// </summary>
        /// <returns>Enumerator from Car[] array</returns>

        public IEnumerator GetEnumerator()
        {
            // Return the array object's IEnumerator.
            return myAutos.GetEnumerator();
        }
    }
}
