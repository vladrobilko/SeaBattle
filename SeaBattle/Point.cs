using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Point
    {
        public int Y { get; set; }

        public int X { get; set; }

        public Point(int y, int x)
        {
            this.Y = y;
            this.X = x;
        }
    }
}
