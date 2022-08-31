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
            while (shipCount > 0)
            {
                int y = rnd.Next(10);
                int x = rnd.Next(10);                
                if (CanFillShipUp(shipLength, y, x) && rnd.Next(2) == 0)//добавить сюда элемент рандома
                {
                    FillShipUp(shipLength, y, x);
                    shipCount--;
                    continue;
                }
                if (CanFillShipRight(shipLength, y, x) && rnd.Next(2) == 0)
                {
                    FillShipRight(shipLength, y, x);
                    shipCount--;
                    continue;
                }
            }

        }

        private void FillShipRight(int shipLength, int y, int x)
        {
            FillAroundShipRight(shipLength, y, x);
            for (int i = 0; i < shipLength; i++)
            {
                cells[y, x].ConditionType = ConditionType.BusyDeck;
                x++;
            }
        }
        private bool CanFillShipRight(int shipLength, int y, int x)
        {
            if ((x + shipLength >= 10) || IsCellInSideLine(y, x) || !CanFillAroundShipRight(shipLength, y, x)) return false;        
            for (int i = 0; i < shipLength; i++)
            {
                if ((cells[y, x].ConditionType != ConditionType.Empty))
                {                    
                    return false;
                }
                x++;
            }            
            return true;
        }
        private void FillAroundShipRight(int shipLength, int y, int x)
        {
            int upPosY = y - 1;
            int downPosY = y + 1;
            int posX = x - 1;            
            cells[y, posX].ConditionType = ConditionType.BusyDeckNearby;
            cells[y, posX + shipLength + 1].ConditionType = ConditionType.BusyDeckNearby;
            for (int i = 0; i < shipLength + 2; i++)
            {                
                cells[upPosY, posX].ConditionType = ConditionType.BusyDeckNearby;
                cells[downPosY, posX].ConditionType = ConditionType.BusyDeckNearby;
                posX++;
            }
        }
        private bool CanFillAroundShipRight(int shipLength, int y, int x)
        {
            if (IsCellLeftOfShipAndRigthOfShipBusyDeck(shipLength, y, x)) return false;
            x--;
            for (int i = 0; i < shipLength + 2; i++)
            {
                if (IsCellUpAndDownBusyDeck(y, x)) return false;
                x++;
            }
            return true;
        }
        private bool IsCellUpAndDownBusyDeck(int y, int x)
        {            
            return cells[y - 1, x].ConditionType == ConditionType.BusyDeck || cells[y + 1, x].ConditionType == ConditionType.BusyDeck;
        }
        private bool IsCellLeftOfShipAndRigthOfShipBusyDeck(int shipLength, int y, int x)
        {
            return cells[y, x - 1].ConditionType == ConditionType.BusyDeck || cells[y , x + shipLength].ConditionType == ConditionType.BusyDeck;
        }

        private void FillShipUp(int shipLength, int y, int x)
        {
            FillAroundShipUp(shipLength, y, x);                       
            for (int i = 0; i < shipLength; i++)
            {
                cells[y, x].ConditionType = ConditionType.BusyDeck;
                y--;
            }            
        }
        private bool CanFillShipUp(int shipLength, int y, int x)
        {
            if ((y - shipLength <= 0) || IsCellInSideLine(y, x) || !CanFillAroundShipUp(shipLength, y, x)) return false;
            for (int i = 0; i < shipLength; i++)
            {
                if (cells[y, x].ConditionType != ConditionType.Empty)
                {
                    return false;
                }
                y--;
            }
            return true;
        }
        private void FillAroundShipUp(int shipLength, int y, int x)
        {
            int rightPosX = x + 1;
            int leftPosX = x - 1;
            int posY = y + 1;
            cells[posY, x].ConditionType = ConditionType.BusyDeckNearby;
            cells[posY - (shipLength + 1), x].ConditionType = ConditionType.BusyDeckNearby;
            for (int i = 0; i < shipLength + 2; i++)
            {
                cells[posY, rightPosX].ConditionType = ConditionType.BusyDeckNearby;
                cells[posY, leftPosX].ConditionType = ConditionType.BusyDeckNearby;
                posY--;
            }
        }        
        private bool CanFillAroundShipUp(int shipLength, int y, int x)
        {
            if (IsCellUpOfShipAndDownOfShipBusyDeck(shipLength, y, x)) return false;
            y++;
            for (int i = 0; i > shipLength + 2; i++)
            {
                if (IsCellRightAndLeftBusyDeck(y, x)) return false;
                y--;
            }
            return true;
        }
        private bool IsCellRightAndLeftBusyDeck(int y, int x)
        {
            return cells[y, x - 1].ConditionType == ConditionType.BusyDeck || cells[y, x + 1].ConditionType == ConditionType.BusyDeck;            
        }
        private bool IsCellUpOfShipAndDownOfShipBusyDeck(int shipLength, int y, int x)
        {
            return cells[y + 1, x].ConditionType == ConditionType.BusyDeck || cells[y - shipLength, x].ConditionType == ConditionType.BusyDeck;
        }
        

        //индейка - может не нужен класс корабль? а просто сделать проверку если вокруг клетки нету больше кораблей то убит!!
        private bool IsCellInSideLine(int y, int x)
        {
            return x == 0 || y == 9 || y == 0 || x == 9;
        }

        //нужен метод чтобы понимать корбаль убит или нет - метод есть ли вокруг палубы, если нет то убит и эта проверка в том случае, если 
        //было попадание
        public void FillShipLenghtOneRandomly(int shipCount)//нужна ссылка на корабль, чтобы присваивалась
        {
            for (int i = 1, j = 0; i < height - 1 && j < shipCount; i++)
            {
                if (CanFillShipLenghtOneUpHorizontallLine(i) && j < shipCount)
                {
                    FillShipLenghtOneUpHorizontalLine(i); j++;
                }
                if (CanFillShipLenghtOneInDownHorizontallLine(i) && j < shipCount)
                {
                    FillShipLenghtOneInDownHorizontallLine(i); j++;
                }
                if (CanFillShipLenghtOneInLeftVerticalLine(i) && j < shipCount)
                {
                    FillShipLenghtOneInLeftVerticalLine(i); j++;
                }
                if (CanFillShipLenghtOneInRightVerticalLine(i) && j < shipCount)
                {
                    FillShipLenghtOneInRightVerticalLine(i); j++;
                }
            }
        }

        private void FillShipLenghtOneUpHorizontalLine(int countCoordinateX)
        {
            cells[0, countCoordinateX + 1].ConditionType = ConditionType.BusyDeckNearby;
            cells[0, countCoordinateX].ConditionType = ConditionType.BusyDeck;
        }

        private bool CanFillShipLenghtOneUpHorizontallLine(int countCoordinateX)
        {
            return (cells[0, countCoordinateX].ConditionType == ConditionType.Empty) && 
                   (cells[1, countCoordinateX - 1].ConditionType != ConditionType.BusyDeck) &&
                   (cells[1, countCoordinateX].ConditionType != ConditionType.BusyDeck) &&
                   (cells[1, countCoordinateX + 1].ConditionType != ConditionType.BusyDeck);
        }                        

        private void FillShipLenghtOneInDownHorizontallLine(int countCoordinateX)
        {
            cells[9, countCoordinateX + 1].ConditionType = ConditionType.BusyDeckNearby;
            cells[9, countCoordinateX].ConditionType = ConditionType.BusyDeck;
        }

        private bool CanFillShipLenghtOneInDownHorizontallLine(int countCoordinateX)
        {
            return (cells[9, countCoordinateX].ConditionType == ConditionType.Empty) && 
                   (cells[8, countCoordinateX - 1].ConditionType != ConditionType.BusyDeck) &&
                   (cells[8, countCoordinateX].ConditionType != ConditionType.BusyDeck) &&
                   (cells[8, countCoordinateX + 1].ConditionType != ConditionType.BusyDeck);
        }        

        private void FillShipLenghtOneInLeftVerticalLine(int countCoordinateY)
        {
            cells[countCoordinateY - 1, 0].ConditionType = ConditionType.BusyDeckNearby;
            cells[countCoordinateY, 0].ConditionType = ConditionType.BusyDeck;
        }

        private bool CanFillShipLenghtOneInLeftVerticalLine(int countCoordinateY)
        {
            return (cells[countCoordinateY, 1].ConditionType == ConditionType.Empty) && 
                (cells[countCoordinateY - 1, 1].ConditionType != ConditionType.BusyDeck) &&
                (cells[countCoordinateY + 1, 1].ConditionType != ConditionType.BusyDeck) &&
                (cells[countCoordinateY, 1].ConditionType != ConditionType.BusyDeck);
        }        

        private void FillShipLenghtOneInRightVerticalLine(int countCoordinateY)
        {
            cells[countCoordinateY + 1, 9].ConditionType = ConditionType.BusyDeckNearby;
            cells[countCoordinateY, 9].ConditionType = ConditionType.BusyDeck;
        }

        private bool CanFillShipLenghtOneInRightVerticalLine(int countCoordinateY)
        {
            return (cells[countCoordinateY, 9].ConditionType == ConditionType.Empty) && 
                (cells[countCoordinateY - 1, 8].ConditionType != ConditionType.BusyDeck) &&
                (cells[countCoordinateY + 1, 8].ConditionType != ConditionType.BusyDeck) &&
                (cells[countCoordinateY, 8].ConditionType != ConditionType.BusyDeck);
        }
    }
}
