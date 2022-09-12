using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle;

namespace ConsoleSeaBattle
{
    public class CellStateToString
    {
        private Cell cell;
        public CellStateToString(Cell cell)
        {
            this.cell = cell;
            ConditionTypeToString();
        }
        public string ConditionTypeToString()
        {
            // лишний код пишешь
            //string cellCondition = " ";
            switch (cell.State)
            {
                case CellState.Empty:
                    return " ";
                //cellCondition = " ";
                //break;
                case CellState.BusyDeck:
                    return "#";
                //cellCondition = "#";
                //break;
                case CellState.BusyDeckNearby:
                    return "-";
                //cellCondition = "-";
                //break;
                case CellState.HasShooted:
                    return "x";
                //cellCondition = "x";
                //break;
                case CellState.HasMiss:
                    return "*";
                //cellCondition = "*";
                //break;
                default: return " ";// если ниодно условя не подошло
            }
            //return cellCondition;
        }
    }
}
