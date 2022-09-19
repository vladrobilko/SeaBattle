using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle;

namespace ConsoleSeaBattle
{
    public class CellStateConsole
    {
        public static string ToString(Cell cell)
        {
            switch (cell.State)
            {
                case CellState.Empty:
                    return " ";
                case CellState.BusyDeck:
                    return "#";
                case CellState.BusyDeckNearby:
                    return "-";
                case CellState.HasMiss:
                    return "*";
                case CellState.HasHit:
                    return "x";
                default: return " ";
            }
        }
    }
}
