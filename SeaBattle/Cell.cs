using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class Cell
    {
        public ConditionType ConditionType { get; set; } = ConditionType.Empty;

        public bool HasShooted { get; set; }
        
        public string ConditionTypeToString()
        {
            string cellCondition = " ";
            switch (ConditionType)
            {
                case ConditionType.Empty:
                    cellCondition = " ";
                    break;
                case ConditionType.BusyDeck:
                    cellCondition = "#";
                    break;
                case ConditionType.BusyDeckNearby:
                    cellCondition = "-";
                    break;
                case ConditionType.HasShooted:
                    cellCondition = "x";
                    break;
                case ConditionType.HasMiss:
                    cellCondition = "*";
                    break;               
            }
            return cellCondition;
        }
    }
}
