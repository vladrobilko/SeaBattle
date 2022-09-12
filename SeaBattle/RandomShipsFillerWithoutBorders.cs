using System;

namespace SeaBattle
{
    public class RandomShipsFillerWithoutBorders //интефейс здесь убрать и сделать Filler общий и ему интерфейс и этот интерфейс уже 
        //игроку передавать, в общем филлере список создаваемых кораблей или что то типо того
    {
        static Random rnd = new Random();

        public static Cell[,] FillShipsWithoutInterface(Cell[,] cells, int shipCount, int shipLength)
        {
            while (shipCount > 0)
            {
                int y = rnd.Next(10);
                int x = rnd.Next(10);
                if (CanFillShipUp(cells, shipLength, y, x) && rnd.Next(2) == 0)
                {
                    FillShipUp(cells, shipLength, y, x);
                    shipCount--;
                    continue;
                }
                if (CanFillShipRight(cells, shipLength, y, x) && rnd.Next(2) == 1)
                {
                    FillShipRight(cells, shipLength, y, x);
                    shipCount--;
                    continue;
                }
            }
            return cells;
        }

        private static void FillShipRight(Cell[,] cells, int shipLength, int y, int x)
        {
            FillAroundShipRight(cells, shipLength, y, x);
            for (int i = 0; i < shipLength; i++)
            {
                cells[y, x + i].State = CellState.BusyDeck;                
            }
        }

        private static bool CanFillShipRight(Cell[,] cells, int shipLength, int y, int x)
        {
            if ((x + shipLength >= 10) || IsCellInSideLine(y, x) || !CanFillAroundShipRight(cells, shipLength, y, x)) return false;
            for (int i = 0; i < shipLength; i++)
            {
                if ((cells[y, x + i].State != CellState.Empty))
                {
                    return false;
                }                
            }
            return true;
        }

        private static void FillAroundShipRight(Cell[,] cells, int shipLength, int y, int x)
        {
            int upPosY = y - 1;
            int downPosY = y + 1;
            int posX = x - 1;
            cells[y, posX].State = CellState.BusyDeckNearby;
            cells[y, posX + shipLength + 1].State = CellState.BusyDeckNearby;
            for (int i = 0; i < shipLength + 2; i++)
            {
                cells[upPosY, posX].State = CellState.BusyDeckNearby;
                cells[downPosY, posX + i].State = CellState.BusyDeckNearby;
                ////posX++; i каждый цикл уже увеличивается на 1 может как нить ее заюзать? cells[downPosY, posX + i]
            }
        }

        private static bool CanFillAroundShipRight(Cell[,] cells, int shipLength, int y, int x)
        {
            if (IsCellLeftOfShipAndRigthOfShipBusyDeck(cells, shipLength, y, x)) return false;
            x--;
            for (int i = 0; i < shipLength + 2; i++)
            {
                if (IsCellUpAndDownBusyDeck(cells, y, x + i)) return false;                
            }
            return true;
        }

        private static bool IsCellUpAndDownBusyDeck(Cell[,] cells, int y, int x)
        {
            return cells[y - 1, x].State == CellState.BusyDeck ||
                cells[y + 1, x].State == CellState.BusyDeck;
        }

        private static bool IsCellLeftOfShipAndRigthOfShipBusyDeck(Cell[,] cells, int shipLength, int y, int x)
        {
            return cells[y, x - 1].State == CellState.BusyDeck ||
                cells[y, x + shipLength].State == CellState.BusyDeck;
        }

        private static void FillShipUp(Cell[,] cells, int shipLength, int y, int x)
        {
            FillAroundShipUp(cells, shipLength, y, x);
            for (int i = 0; i < shipLength; i++)
            {
                cells[y - i, x].State = CellState.BusyDeck;                
            }
        }

        private static bool CanFillShipUp(Cell[,] cells, int shipLength, int y, int x)
        {
            if ((y - shipLength <= 0) || IsCellInSideLine(y, x) || !CanFillAroundShipUp(cells, shipLength, y, x)) return false;
            for (int i = 0; i < shipLength; i++)
            {
                if (cells[y - i, x].State != CellState.Empty)
                {
                    return false;
                }                
            }
            return true;
        }

        private static void FillAroundShipUp(Cell[,] cells, int shipLength, int y, int x)
        {
            int rightPosX = x + 1;
            int leftPosX = x - 1;
            int posY = y + 1;
            cells[posY, x].State = CellState.BusyDeckNearby;
            cells[posY - (shipLength + 1), x].State = CellState.BusyDeckNearby;
            for (int i = 0; i < shipLength + 2; i++)
            {
                cells[posY, rightPosX].State = CellState.BusyDeckNearby;
                cells[posY, leftPosX].State = CellState.BusyDeckNearby;
                posY--;
            }
        }

        private static bool CanFillAroundShipUp(Cell[,] cells, int shipLength, int y, int x)
        {
            if (IsCellUpOfShipAndDownOfShipBusyDeck(cells, shipLength, y, x)) return false;
            y++;
            for (int i = 0; i > shipLength + 2; i++)
            {
                if (IsCellRightAndLeftBusyDeck(cells, y - i, x)) return false;                
            }
            return true;
        }

        private static bool IsCellRightAndLeftBusyDeck(Cell[,] cells, int y, int x)
        {
            return cells[y, x - 1].State == CellState.BusyDeck ||
                cells[y, x + 1].State == CellState.BusyDeck;
        }

        private static bool IsCellUpOfShipAndDownOfShipBusyDeck(Cell[,] cells, int shipLength, int y, int x)
        {
            return cells[y + 1, x].State == CellState.BusyDeck ||
                cells[y - shipLength, x].State == CellState.BusyDeck;
        }

        private static bool IsCellInSideLine(int y, int x)
        {
            return x == 0 || y == 9 || y == 0 || x == 9;
        }
    }
}
