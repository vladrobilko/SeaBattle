using System;

namespace SeaBattle
{
    public class ShipLenghtOneFiller : IShipsFiller
    {       
        public int ShipCount { get; set; }

        public int ShipLength { get; set; }
     
        public ShipLenghtOneFiller(int shipCount)
        {            
            ShipCount = shipCount;            
        }

        public Cell[,] FillShips(Cell[,] cells)
        {
            int firstCoordinate = 1;
            while (ShipCount > 0 && firstCoordinate < 10)
            {
                if (CanFillUpHorizontalLine(cells, firstCoordinate) && ShipCount > 0)
                {
                    FillUpHorizontalLine(cells, firstCoordinate); ShipCount--;
                }
                if (CanFillDownHorizontallLine(cells, firstCoordinate) && ShipCount > 0)
                {
                    FillDownHorizontallLine(cells, firstCoordinate); ShipCount--;
                }
                if (CanFillLeftVerticalLine(cells, firstCoordinate) && ShipCount > 0)
                {
                    FillLeftVerticalLine(cells, firstCoordinate); ShipCount--;
                }
                if (CanFillRightVerticalLine(cells, firstCoordinate) && ShipCount > 0)
                {
                    FillRightVerticalLine(cells, firstCoordinate); ShipCount--;
                }
                firstCoordinate++;
            }
            return cells;
        }        

        private void FillUpHorizontalLine(Cell[,] cells, int countCoordinateX)
        {
            cells[0, countCoordinateX + 1].ConditionType = ConditionType.BusyDeckNearby;
            cells[0, countCoordinateX].ConditionType = ConditionType.BusyDeck;
        }

        private bool CanFillUpHorizontalLine(Cell[,] cells, int countCoordinateX)
        {
            return (cells[0, countCoordinateX].ConditionType == ConditionType.Empty) &&
                   (cells[1, countCoordinateX - 1].ConditionType != ConditionType.BusyDeck) &&
                   (cells[1, countCoordinateX].ConditionType != ConditionType.BusyDeck) &&
                   (cells[1, countCoordinateX + 1].ConditionType != ConditionType.BusyDeck);
        }

        private void FillDownHorizontallLine(Cell[,] cells, int countCoordinateX)
        {
            cells[9, countCoordinateX + 1].ConditionType = ConditionType.BusyDeckNearby;
            cells[9, countCoordinateX].ConditionType = ConditionType.BusyDeck;
        }

        private bool CanFillDownHorizontallLine(Cell[,] cells, int countCoordinateX)
        {
            return (cells[9, countCoordinateX].ConditionType == ConditionType.Empty) &&
                   (cells[8, countCoordinateX - 1].ConditionType != ConditionType.BusyDeck) &&
                   (cells[8, countCoordinateX].ConditionType != ConditionType.BusyDeck) &&
                   (cells[8, countCoordinateX + 1].ConditionType != ConditionType.BusyDeck);
        }

        private void FillLeftVerticalLine(Cell[,] cells, int countCoordinateY)
        {
            cells[countCoordinateY - 1, 0].ConditionType = ConditionType.BusyDeckNearby;
            cells[countCoordinateY, 0].ConditionType = ConditionType.BusyDeck;
        }

        private bool CanFillLeftVerticalLine(Cell[,] cells, int countCoordinateY)
        {
            return (cells[countCoordinateY, 1].ConditionType == ConditionType.Empty) &&
                (cells[countCoordinateY - 1, 1].ConditionType != ConditionType.BusyDeck) &&
                (cells[countCoordinateY + 1, 1].ConditionType != ConditionType.BusyDeck) &&
                (cells[countCoordinateY, 1].ConditionType != ConditionType.BusyDeck);
        }

        private void FillRightVerticalLine(Cell[,] cells, int countCoordinateY)
        {
            cells[countCoordinateY + 1, 9].ConditionType = ConditionType.BusyDeckNearby;
            cells[countCoordinateY, 9].ConditionType = ConditionType.BusyDeck;
        }

        private bool CanFillRightVerticalLine(Cell[,] cells, int countCoordinateY)
        {
            return (cells[countCoordinateY, 9].ConditionType == ConditionType.Empty) &&
                (cells[countCoordinateY - 1, 8].ConditionType != ConditionType.BusyDeck) &&
                (cells[countCoordinateY + 1, 8].ConditionType != ConditionType.BusyDeck) &&
                (cells[countCoordinateY, 8].ConditionType != ConditionType.BusyDeck);
        }
    }
}
