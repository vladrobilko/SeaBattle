using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Cell
    {
        public int PosY { get; set; }

        public int PosX { get; set; }

        private char _condition = ' ';

        public char Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        public bool IsBusy
        {
            get
            {
                return Condition != ' ';
            }
        }

        public bool IsShooting { get; set; }

        public Cell(int posY, int posX)
        {
            PosY = posY;
            PosX = posX;
        }
    }
}
