using System;

namespace SeaBattle
{
    public class RandomShipsFiller : IShipsFiller
    {
        static Random rnd = new Random();

        public int ShipCount { get; set; }

        public int ShipLength { get; set; }

        public RandomShipsFiller(int shipCount, int shipLength)
        {
            ShipCount = shipCount;
            ShipLength = shipLength;
        }

        public Cell[,] FillShips(Cell[,] cells)
        {
            while (ShipCount > 0)
            {
                int y = rnd.Next(10);
                int x = rnd.Next(10);
                if (CanFillShipUp(cells, y, x) && rnd.Next(2) == 0)
                {
                    FillShipUp(cells, y, x);
                    ShipCount--;
                    continue;
                }
                if (CanFillShipRight(cells, y, x) && rnd.Next(2) == 1)
                {
                    FillShipRight(cells, y, x);
                    ShipCount--;
                    continue;
                }
            }
            return cells;
        }

        private void FillShipRight(Cell[,] cells, int y, int x)
        {
            FillAroundShipRight(cells, y, x);
            for (int i = 0; i < ShipLength; i++)
            {
                cells[y, x].ConditionType = ConditionType.BusyDeck;
                x++;
            }
        }

        private bool CanFillShipRight(Cell[,] cells, int y, int x)
        {
            if ((x + ShipLength >= 10) || IsCellInSideLine(y, x) || !CanFillAroundShipRight(cells, y, x)) return false;
            for (int i = 0; i < ShipLength; i++)
            {
                if ((cells[y, x].ConditionType != ConditionType.Empty))
                {
                    return false;
                }
                x++;
            }
            return true;
        }

        private void FillAroundShipRight(Cell[,] cells, int y, int x)
        {
            int upPosY = y - 1;
            int downPosY = y + 1;
            int posX = x - 1;
            cells[y, posX].ConditionType = ConditionType.BusyDeckNearby;
            cells[y, posX + ShipLength + 1].ConditionType = ConditionType.BusyDeckNearby;
            for (int i = 0; i < ShipLength + 2; i++)
            {
                cells[upPosY, posX].ConditionType = ConditionType.BusyDeckNearby;
                cells[downPosY, posX].ConditionType = ConditionType.BusyDeckNearby;
                posX++;
            }
        }

        private bool CanFillAroundShipRight(Cell[,] cells, int y, int x)
        {
            if (IsCellLeftOfShipAndRigthOfShipBusyDeck(cells, y, x)) return false;
            x--;
            for (int i = 0; i < ShipLength + 2; i++)
            {
                if (IsCellUpAndDownBusyDeck(cells, y, x)) return false;
                x++;
            }
            return true;
        }

        private bool IsCellUpAndDownBusyDeck(Cell[,] cells, int y, int x)
        {
            return cells[y - 1, x].ConditionType == ConditionType.BusyDeck ||
                cells[y + 1, x].ConditionType == ConditionType.BusyDeck;
        }

        private bool IsCellLeftOfShipAndRigthOfShipBusyDeck(Cell[,] cells, int y, int x)
        {
            return cells[y, x - 1].ConditionType == ConditionType.BusyDeck ||
                cells[y, x + ShipLength].ConditionType == ConditionType.BusyDeck;
        }

        private void FillShipUp(Cell[,] cells, int y, int x)
        {
            FillAroundShipUp(cells, y, x);
            for (int i = 0; i < ShipLength; i++)
            {
                cells[y, x].ConditionType = ConditionType.BusyDeck;
                y--;
            }
        }

        private bool CanFillShipUp(Cell[,] cells, int y, int x)
        {
            if ((y - ShipLength <= 0) || IsCellInSideLine(y, x) || !CanFillAroundShipUp(cells, y, x)) return false;
            for (int i = 0; i < ShipLength; i++)
            {
                if (cells[y, x].ConditionType != ConditionType.Empty)
                {
                    return false;
                }
                y--;
            }
            return true;
        }

        private void FillAroundShipUp(Cell[,] cells, int y, int x)
        {
            int rightPosX = x + 1;
            int leftPosX = x - 1;
            int posY = y + 1;
            cells[posY, x].ConditionType = ConditionType.BusyDeckNearby;
            cells[posY - (ShipLength + 1), x].ConditionType = ConditionType.BusyDeckNearby;
            for (int i = 0; i < ShipLength + 2; i++)
            {
                cells[posY, rightPosX].ConditionType = ConditionType.BusyDeckNearby;
                cells[posY, leftPosX].ConditionType = ConditionType.BusyDeckNearby;
                posY--;
            }
        }

        private bool CanFillAroundShipUp(Cell[,] cells, int y, int x)
        {
            if (IsCellUpOfShipAndDownOfShipBusyDeck(cells, y, x)) return false;
            y++;
            for (int i = 0; i > ShipLength + 2; i++)
            {
                if (IsCellRightAndLeftBusyDeck(cells, y, x)) return false;
                y--;
            }
            return true;
        }

        private bool IsCellRightAndLeftBusyDeck(Cell[,] cells, int y, int x)
        {
            return cells[y, x - 1].ConditionType == ConditionType.BusyDeck ||
                cells[y, x + 1].ConditionType == ConditionType.BusyDeck;
        }

        private bool IsCellUpOfShipAndDownOfShipBusyDeck(Cell[,] cells, int y, int x)
        {
            return cells[y + 1, x].ConditionType == ConditionType.BusyDeck ||
                cells[y - ShipLength, x].ConditionType == ConditionType.BusyDeck;
        }

        private bool IsCellInSideLine(int y, int x)
        {
            return x == 0 || y == 9 || y == 0 || x == 9;
        }


    }
}
