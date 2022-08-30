using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public enum ConditionType
    {
        Empty,
        BusyShip,
        BusyShipNearby,
        HasShooted,
        HasMiss
    }

    public class Cell
    {
        
        public int PosY { get; set; }//переиминовать координатой и создать класс

        public int PosX { get; set; }

        public ConditionType ConditionType { get; set; } = ConditionType.Empty;

        public bool IsBusy
        {
            get
            {
                return ConditionType != ConditionType.Empty;
            }
        }

        public bool HasShooted { get; set; }

        public Cell(int posY, int posX)
        {
            PosY = posY;
            PosX = posX;
        }

        public string ConditionTypeToString()
        {
            string cellCondition = " ";
            switch (ConditionType)
            {
                case ConditionType.Empty:
                    cellCondition = " ";
                    break;
                case ConditionType.BusyShip:
                    cellCondition = "#";
                    break;
                case ConditionType.BusyShipNearby:
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
