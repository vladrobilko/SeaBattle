using System;

namespace SeaBattle
{
    public class Cell
    {
        public int PosY { get; set; }

        public int PosX { get; set; }

        private char _condition = ' ';

        

        public char Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }


        public bool IsBusy
        {
            get
            {
                return Condition != ' ';
            }
        }

        public Cell(int posY, int posX)
        {
            PosY = posY;
            PosX = posX;
        }
    }

    public class PlayArea
    {
        int height;
        int width;
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

        public void FillShipsRandomly(int shipCount, int shipLength)//
        {
            int posY = 0;
            int posX = 0;

            for (int j = 0; j < shipCount; j++)//цикл выполняется столько раз сколько корбалей 
            {
                while (true)
                {
                    posY = rnd.Next(10);
                    posX = rnd.Next(10);
                   
                    var ship = new Ship(cells[posY, posX], shipLength);
                    if (cells[posY, posX].IsBusy||!IsAreaForShipFree(ship))
                    {
                        continue;
                    }
                    //метод который будет кораблю давать информацию относительно этого поля!!!проверять все клетки заняты они или нет! - ShipInPlay area(Ship ship)
                    //тогда нужно делать корабль равным null, если не получается нарисовать его из клетки
                    if (ship.IsUp)
                    {
                        cells[posY, posX].Condition = '#';
                        
                        for (int i = 0; i < shipLength; i++)
                        {
                            cells[posY--, posX].Condition = '#';
                            //тут сразу заполним клетки(наверное метод)
                        }
                        FillShipAround(ship);
                        break;
                    }

                    if (ship.IsRight)
                    {
                        cells[posY, posX].Condition = '#';
                        
                        for (int i = 0; i < shipLength; i++)
                        {
                            cells[posY, posX++].Condition = '#';                           
                        }
                        FillShipAround(ship);
                        break;
                    }
                }
            }
        }
        public bool IsAreaForShipFree(Ship ship)//проверка свободных ячеек
        //получим либо null(значит в данной точке корабль не построится) либо один true, и тогда строим в ту сторону в какую тру
        {
            int y = ship.cell.PosY;
            int x = ship.cell.PosX;
            if (x == 0 || y == 9 || y == 0 || x + ship.length == 9)
            {
                return false;
            }
            if (x + ship.length < 10)
            {
                for (int i = 0; i < ship.length; i++)
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

            if (x == 0 || y == 9 || x == 9 || y - ship.length == 0)
            {
                return false;
            }
            if (y - ship.length > 0)
            {
                for (int i = 0; i < ship.length; i++)
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


        //тут добавить на заполнение вокруг корбаля области(учесть аут оф рендж)((сдлеать это методом))(((у нас есть
        //объект корбаль, с длинной и первым элементом мы его проверим на то в какую он сторону и исходя этого заполним
        //клетки вокруг что корабль рядом и будем и сключать для каждого свое
        //так же если клетка уже имеет статус то ее пропускаем
        
        //сделать метод для проверки всего массива и выставления isBusy если что то занято, или присуждать это после того как сразу бдут корабль

        public void FillShipAround(Ship ship)//делаем для общего случая в котором нету исключений()
        {
            if (ship.IsUp)
            {                
                int rightPosX = ship.cell.PosX + 1;
                int leftPosX = ship.cell.PosX - 1;
                int posY = ship.cell.PosY + 1;
                cells[posY, rightPosX].Condition = '-';
                cells[posY, leftPosX].Condition = '-';
                cells[posY, ship.cell.PosX].Condition = '-';
                cells[posY, ship.cell.PosX + ship.length + 1].Condition = '-';

                for (int i = 0; i < ship.length + 1; i++)
                {
                    posY--;
                    cells[posY, rightPosX].Condition = '-';
                    cells[posY, leftPosX].Condition = '-';
                }                            
            }

            int upPosY = ship.cell.PosY - 1;
            int downPosY = ship.cell.PosY + 1;
            int posX = ship.cell.PosX - 1;
            cells[upPosY, posX].Condition = '-';
            cells[downPosY, posX].Condition = '-';
            cells[ship.cell.PosY, posX].Condition = '-';
            cells[ship.cell.PosY , posX + ship.length+1].Condition = '-';

            for (int i = 0; i < ship.length + 1; i++)
            {
                posX++;
                cells[upPosY, posX].Condition = '-';
                cells[downPosY, posX].Condition = '-';
            }            
        }

        public Cell Exception(Cell cell)//или сделать на аут оф рендж прото метод без трай кетч
        {
            try
            {

            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }

    }//делать 2 корабля 

    public class Ship
    {
        public int length;

        public Cell cell;             

        public Ship(Cell cell, int length)
        {
            this.cell = cell;
            this.length = length;
        }
        public bool IsRight { get; set; }
        
        public bool IsUp { get; set; }

        //public bool IsLeft { get; set; }
        //public bool IsDown { get; set; }        
    }

}
