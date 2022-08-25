using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Ship
    {
        public int Lenght { get; set; }

        public Cell Cell { get; set; }

        public bool IsRight { get; set; }

        public bool IsUp { get; set; }

        public Ship(Cell cell, int length)
        {
            this.Cell = cell;
            this.Lenght = length;
        }
    }
}
