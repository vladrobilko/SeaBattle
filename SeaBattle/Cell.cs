using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Cell
    {
        public Point Point { get; }

        public CellState State { get; set; } = CellState.Empty;

        public Cell(int coordinateY, int coordinateX)
        {
            this.Point = new Point(coordinateY, coordinateX);
        }
    }
}
