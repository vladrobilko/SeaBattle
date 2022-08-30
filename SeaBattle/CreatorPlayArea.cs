using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class PlayArea
    {
        private int height;
        private int width;
        public Cell[,] cells;

        static Random rnd = new Random();

        public PlayArea(int height, int width)
        {
            this.height = height;
            this.width = width;
            this.cells = new Cell[height, width];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            }
        }

        public void FillShipsRandomly(int shipCount, int shipLength)
        {
            for (int j = 0; j < shipCount; j++)
            {
                while (true)
                {
                    int posY = rnd.Next(10);
                    int posX = rnd.Next(10);
                    var ship = new Ship(cells[posY, posX], shipLength);
                    if ((cells[posY, posX].IsBusy) || (!IsAreaForShipFree(ship)) || (FillShipAround(ship) == null))
                    {                       
                        continue;
                    }
                    if (ship.IsUp)//в метод 1 
                    {
                        cells[posY, posX].ConditionType = ConditionType.BusyShip;
                        FillShipAround(ship);
                        for (int i = 0; i < shipLength; i++)
                        {
                            cells[posY--, posX].ConditionType = ConditionType.BusyShip;
                        }
                        break;
                    }

                    if (ship.IsRight)//в метод 1 
                    {
                        cells[posY, posX].ConditionType = ConditionType.BusyShip;
                        FillShipAround(ship);
                        for (int i = 0; i < shipLength; i++)
                        {
                            cells[posY, posX++].ConditionType = ConditionType.BusyShip;
                        }
                        break;
                    }
                }
            }
        }
     
        public bool IsAreaForShipFree(Ship ship)
        {
            int y = ship.Cell.PosY;
            int x = ship.Cell.PosX;

            if ((x + ship.Lenght < 10) && (!(x == 0 || y == 9 || y == 0)) && (rnd.Next(2) == 1))
            {
                for (int i = 0; i < ship.Lenght; i++)
                {
                    if (cells[y, x++].IsBusy)
                    {
                        ship.IsRight = false;
                        break;
                    }
                }
                ship.IsRight = true;
                return true;
            }

            if ((y - ship.Lenght > 0) && !(x == 0 || y == 9 || x == 9))
            {
                for (int i = 0; i < ship.Lenght; i++)
                {
                    if (cells[y--, x].IsBusy)
                    {
                        ship.IsUp = false;
                        break;
                    }
                }
                ship.IsUp = true;
                return true;
            }
            return false;
        }

        public Ship FillShipAround(Ship ship)//TryFillShipAround (сделать метод заполнит ли)
        {
            if (ship.IsUp)
            {
                int rightPosX = ship.Cell.PosX + 1;
                int leftPosX = ship.Cell.PosX - 1;
                int posY = ship.Cell.PosY + 1;
                if (cells[posY, rightPosX].ConditionType == ConditionType.BusyShip || cells[posY, leftPosX].ConditionType == ConditionType.BusyShip || cells[posY, ship.Cell.PosX].ConditionType == ConditionType.BusyShip || cells[posY - (ship.Lenght + 1), ship.Cell.PosX].ConditionType == ConditionType.BusyShip)
                {
                    return null;
                }
                cells[posY, rightPosX].ConditionType = ConditionType.BusyShipNearby;
                cells[posY, leftPosX].ConditionType = ConditionType.BusyShipNearby;
                cells[posY, ship.Cell.PosX].ConditionType = ConditionType.BusyShipNearby;
                cells[posY - (ship.Lenght + 1), ship.Cell.PosX].ConditionType = ConditionType.BusyShipNearby;

                for (int i = 0; i < ship.Lenght + 1; i++)
                {
                    posY--;
                    cells[posY, rightPosX].ConditionType = ConditionType.BusyShipNearby;
                    cells[posY, leftPosX].ConditionType = ConditionType.BusyShipNearby;
                }
                return ship;
            }
            else if (ship.IsRight)
            {
                int upPosY = ship.Cell.PosY - 1;
                int downPosY = ship.Cell.PosY + 1;
                int posX = ship.Cell.PosX - 1;
                if (cells[upPosY, posX].ConditionType == ConditionType.BusyShip || cells[downPosY, posX].ConditionType == ConditionType.BusyShip || cells[ship.Cell.PosY, posX].ConditionType == ConditionType.BusyShip || cells[ship.Cell.PosY, posX + ship.Lenght + 1].ConditionType == ConditionType.BusyShip)
                {
                    return null;
                }
                cells[upPosY, posX].ConditionType = ConditionType.BusyShipNearby;
                cells[downPosY, posX].ConditionType = ConditionType.BusyShipNearby;
                cells[ship.Cell.PosY, posX].ConditionType = ConditionType.BusyShipNearby;
                cells[ship.Cell.PosY, posX + ship.Lenght + 1].ConditionType = ConditionType.BusyShipNearby;

                for (int i = 0; i < ship.Lenght + 1; i++)
                {
                    posX++;
                    cells[upPosY, posX].ConditionType = ConditionType.BusyShipNearby;
                    cells[downPosY, posX].ConditionType = ConditionType.BusyShipNearby;
                }
                return ship;
            }
            return null;
        }

        public bool IsCellsBusy(int countBusyCells)//в класс расстоновщик
        {
            int count = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (cells[i, j].ConditionType == ConditionType.BusyShip)
                    {
                        count++;
                    }                    
                }
            }
            return countBusyCells == count;
        }

        //Ниже открефакторил, осталось сделать ссылку на корабль в класс Cell, и нужен метод чтобы понимать корбаль удит или нет
        public void FillShipLenghtOneRandomly(int shipCount)//нужна ссылка на корабль, чтобы присваивалась
        {
            for (int i = 1, j = 0; i < height - 1 && j < shipCount; i++)
            {
                if (CheckCellFreeInUpHorizontallLine(i) && rnd.Next(4) == 0 && j < shipCount)
                {
                    FillShipLenghtOneInUpHorizontallLine(i); j++;
                }
                if (CheckCellFreeInDownHorizontallLine(i) && rnd.Next(4) == 1 && j < shipCount)
                {
                    FillShipLenghtOneInDownHorizontallLine(i); j++;
                }
                if (CheckCellFreeInLeftVerticalLine(i) && rnd.Next(4) == 2 && j < shipCount)
                {
                    FillShipLenghtOneInLeftVerticalLine(i); j++;
                }
                if (CheckCellFreeInRightVerticalLine(i) && rnd.Next(4) == 3 && j < shipCount)
                {
                    FillShipLenghtOneInRightVerticalLine(i); j++;
                }
            }
        }

        private bool CheckCellFreeInUpHorizontallLine(int countCoordinateX)
        {
            return (!cells[0, countCoordinateX].IsBusy) && (cells[1, countCoordinateX - 1].ConditionType != ConditionType.BusyShip) &&
                   (cells[1, countCoordinateX].ConditionType != ConditionType.BusyShip) &&
                   (cells[1, countCoordinateX + 1].ConditionType != ConditionType.BusyShip);
        }

        private void FillShipLenghtOneInUpHorizontallLine(int countCoordinateX)
        {
            cells[0, countCoordinateX + 1].ConditionType = ConditionType.BusyShipNearby;
            cells[0, countCoordinateX].ConditionType = ConditionType.BusyShip;
        }

        private bool CheckCellFreeInDownHorizontallLine(int countCoordinateX)
        {
            return (!cells[9, countCoordinateX].IsBusy) && (cells[8, countCoordinateX - 1].ConditionType != ConditionType.BusyShip) &&
                   (cells[8, countCoordinateX].ConditionType != ConditionType.BusyShip) &&
                   (cells[8, countCoordinateX + 1].ConditionType != ConditionType.BusyShip);
        }

        private void FillShipLenghtOneInDownHorizontallLine(int countCoordinateX)
        {
            cells[9, countCoordinateX + 1].ConditionType = ConditionType.BusyShipNearby;
            cells[9, countCoordinateX].ConditionType = ConditionType.BusyShip;
        }

        private bool CheckCellFreeInLeftVerticalLine(int countCoordinateY)
        {
            return (!cells[countCoordinateY, 1].IsBusy) && (cells[countCoordinateY - 1, 1].ConditionType != ConditionType.BusyShip) &&
                (cells[countCoordinateY + 1, 1].ConditionType != ConditionType.BusyShip) &&
                (cells[countCoordinateY, 1].ConditionType != ConditionType.BusyShip);
        }

        private void FillShipLenghtOneInLeftVerticalLine(int countCoordinateY)
        {
            cells[countCoordinateY - 1, 0].ConditionType = ConditionType.BusyShipNearby;
            cells[countCoordinateY, 0].ConditionType = ConditionType.BusyShip;
        }

        private bool CheckCellFreeInRightVerticalLine(int countCoordinateY)
        {
            return (!cells[countCoordinateY, 9].IsBusy) && (cells[countCoordinateY - 1, 8].ConditionType != ConditionType.BusyShip) &&
                (cells[countCoordinateY + 1, 8].ConditionType != ConditionType.BusyShip) &&
                (cells[countCoordinateY, 8].ConditionType != ConditionType.BusyShip);
        }

        private void FillShipLenghtOneInRightVerticalLine(int countCoordinateY)
        {
            cells[countCoordinateY + 1, 9].ConditionType = ConditionType.BusyShipNearby;
            cells[countCoordinateY, 9].ConditionType = ConditionType.BusyShip;
        }
    }
}
