﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle;

namespace ConsoleSeaBattle
{
    public class ConsoleCellState
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
                default: return " ";
            }            
        }
    }
}
