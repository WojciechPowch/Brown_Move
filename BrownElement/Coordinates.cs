/**
 * Author: Wojciech Powch
 * About (PL): Objekt przechowujący dane wspólbierznych [x, y].
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownElement
{
    class Coordinate
    {
        public double X;
        public double Y;

        public Coordinate(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
