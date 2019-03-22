using System.Collections;
using CommonCar;

namespace CustomEnumeratorWithYield
{
    /// <summary>
    /// Garage contains a set of Car objects.
    /// </summary>

    public class Garage : IEnumerable
    {
        private Car[] myAutos;

        /// <summary>
        /// Fill with some Car objects upon startup.
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
        /// Defines an enumerator. Basically, use yield, which gives the next item in the array.
        /// No need to keep a counter kicking around.
        /// Same effect as using myAutos.GetEnumerator()
        /// </summary>
        /// <returns></returns>

        public IEnumerator GetEnumerator()
        {
            foreach (Car c in myAutos)
            {
                yield return c;
            }
        }
        /// <summary>
        /// Same as above, but param for reverse walk through the array. Yield keeps the current
        /// place in the array, and then executes the next step in the loop.
        /// </summary>
        /// <param name="Reversed">If true, reverse the walk through the array</param>
        /// <returns>Item in the array</returns>
        public IEnumerable GetTheCars(bool Reversed)
        {
            // Return the items in reverse.
            if (Reversed)
            {
                for (int i = myAutos.Length; i != 0; i--)
                {
                    yield return myAutos[i - 1];
                }
            }
            else
            {
                // Return the items as placed in the array.
                foreach (Car c in myAutos)
                {
                    yield return c;
                }
            }
        }
    }
}
