using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterfaces
{
    class PointyClassTest : IPointy
    {
        public string Description { get; set; } = "Pointy thing with no points!";
        public byte Points
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ConsoleColor Color { get; set; }
    }
}
