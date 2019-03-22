using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    // Fork implements IPointy, has 4 points and a color
    // others below are the same, but with different number of points
    class Fork : IPointy
    {
        public string Description { get; set; } = "Fork";
        public byte Points
        {
            get { return 4; }
        }

        public ConsoleColor Color { get; set; }
    }

    class PitchFork : IPointy
    {
        public string Description { get; set; } = "PitchFork";
        public byte Points
        {
            get { return 3; }
        }

        public ConsoleColor Color { get; set; }

    }

    class Knife : IPointy
    {
        public string Description { get; set; } = "Knife";
        public byte Points
        {
            get { return 1; }
        }

        public ConsoleColor Color { get; set; }

    }
}
