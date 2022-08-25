﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class CreatorPlayArea
    {
        private int height;
        private int width;
        public Cell[,] cells;

        static Random rnd = new Random();

        public CreatorPlayArea(int height, int width)
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
                    if (cells[posY, posX].IsBusy || !IsAreaForShipFree(ship) || FillShipAround(ship) == null)
                    {
                        continue;
                    }
                    if (ship.IsUp)
                    {
                        cells[posY, posX].Condition = '#';
                        FillShipAround(ship);
                        for (int i = 0; i < shipLength; i++)
                        {
                            cells[posY--, posX].Condition = '#';
                        }
                        break;
                    }

                    if (ship.IsRight)
                    {
                        cells[posY, posX].Condition = '#';
                        FillShipAround(ship);
                        for (int i = 0; i < shipLength; i++)
                        {
                            cells[posY, posX++].Condition = '#';
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

            if ((x + ship.Lenght < 10) && !(x == 0 || y == 9 || y == 0) && rnd.Next(2) == 1)
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

        public Ship FillShipAround(Ship ship)
        {
            if (ship.IsUp)
            {
                int rightPosX = ship.Cell.PosX + 1;
                int leftPosX = ship.Cell.PosX - 1;
                int posY = ship.Cell.PosY + 1;
                if (cells[posY, rightPosX].Condition == '#' || cells[posY, leftPosX].Condition == '#' || cells[posY, ship.Cell.PosX].Condition == '#' || cells[posY - (ship.Lenght + 1), ship.Cell.PosX].Condition == '#')
                {
                    return null;
                }
                cells[posY, rightPosX].Condition = '-';
                cells[posY, leftPosX].Condition = '-';
                cells[posY, ship.Cell.PosX].Condition = '-';
                cells[posY - (ship.Lenght + 1), ship.Cell.PosX].Condition = '-';

                for (int i = 0; i < ship.Lenght + 1; i++)
                {
                    posY--;
                    cells[posY, rightPosX].Condition = '-';
                    cells[posY, leftPosX].Condition = '-';
                }
                return ship;
            }
            else if (ship.IsRight)
            {
                int upPosY = ship.Cell.PosY - 1;
                int downPosY = ship.Cell.PosY + 1;
                int posX = ship.Cell.PosX - 1;
                if (cells[upPosY, posX].Condition == '#' || cells[downPosY, posX].Condition == '#' || cells[ship.Cell.PosY, posX].Condition == '#' || cells[ship.Cell.PosY, posX + ship.Lenght + 1].Condition == '#')
                {
                    return null;
                }
                cells[upPosY, posX].Condition = '-';
                cells[downPosY, posX].Condition = '-';
                cells[ship.Cell.PosY, posX].Condition = '-';
                cells[ship.Cell.PosY, posX + ship.Lenght + 1].Condition = '-';

                for (int i = 0; i < ship.Lenght + 1; i++)
                {
                    posX++;
                    cells[upPosY, posX].Condition = '-';
                    cells[downPosY, posX].Condition = '-';
                }
                return ship;
            }
            return null;
        }
    }
}
