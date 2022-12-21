using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public static class CellStateConverter
    {
        public static string ToStringForInfo(this CellState cell)
        {
            switch (cell)
            {
                case CellState.Empty:
                    return " ";
                case CellState.BusyDeck:
                    return "#";
                case CellState.BusyDeckNearby:
                    return " ";
                case CellState.HasMiss:
                    return "*";
                case CellState.HasHit:
                    return "x";
                default: return " ";
            }
        }

    }
}
