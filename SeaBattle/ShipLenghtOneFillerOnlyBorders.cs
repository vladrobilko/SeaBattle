using System;

namespace SeaBattle
{
    public class ShipLenghtOneFillerOnlyBorders
    {
        public static Cell[,] FillShipsWithoutInterface(Cell[,] cells, int shipCount, int shipLenght)
        {
            int firstCoordinate = 1;
            while (shipCount > 0 && firstCoordinate < 10)
            {
                if (CanFillUpHorizontalLine(cells, firstCoordinate) && shipCount > 0)
                {
                    FillUpHorizontalLine(cells, firstCoordinate); shipCount--;
                }
                if (CanFillDownHorizontallLine(cells, firstCoordinate) && shipCount > 0)
                {
                    FillDownHorizontallLine(cells, firstCoordinate); shipCount--;
                }
                if (CanFillLeftVerticalLine(cells, firstCoordinate) && shipCount > 0)
                {
                    FillLeftVerticalLine(cells, firstCoordinate); shipCount--;
                }
                if (CanFillRightVerticalLine(cells, firstCoordinate) && shipCount > 0)
                {
                    FillRightVerticalLine(cells, firstCoordinate); shipCount--;
                }
                firstCoordinate++;
            }
            return cells;
        }        

        private static void FillUpHorizontalLine(Cell[,] cells, int countCoordinateX)
        {
            cells[0, countCoordinateX + 1].State = CellState.BusyDeckNearby;
            cells[0, countCoordinateX].State = CellState.BusyDeck;
        }

        private static bool CanFillUpHorizontalLine(Cell[,] cells, int countCoordinateX)
        {
            return (cells[0, countCoordinateX].State == CellState.Empty) &&
                   (cells[1, countCoordinateX - 1].State != CellState.BusyDeck) &&
                   (cells[1, countCoordinateX].State != CellState.BusyDeck) &&
                   (cells[1, countCoordinateX + 1].State != CellState.BusyDeck);
        }

        private static void FillDownHorizontallLine(Cell[,] cells, int countCoordinateX)
        {
            ////вроде визде написан код что бы размер поля можно было зачетать любым а тут хардкор на конкретые цифры - ((cells.Length - 1)) было 9
            cells[cells.Length - 1, countCoordinateX + 1].State = CellState.BusyDeckNearby;
            cells[cells.Length - 1, countCoordinateX].State = CellState.BusyDeck;            
        }

        private static bool CanFillDownHorizontallLine(Cell[,] cells, int countCoordinateX)
        {
            return (cells[cells.Length - 1, countCoordinateX].State == CellState.Empty) &&
                   (cells[cells.Length - 2, countCoordinateX - 1].State != CellState.BusyDeck) &&
                   (cells[cells.Length - 2, countCoordinateX].State != CellState.BusyDeck) &&
                   (cells[cells.Length - 2, countCoordinateX + 1].State != CellState.BusyDeck);
        }

        private static void FillLeftVerticalLine(Cell[,] cells, int countCoordinateY)
        {
            cells[countCoordinateY - 1, 0].State = CellState.BusyDeckNearby;
            cells[countCoordinateY, 0].State = CellState.BusyDeck;
        }

        private static bool CanFillLeftVerticalLine(Cell[,] cells, int countCoordinateY)
        {
            return (cells[countCoordinateY, 1].State == CellState.Empty) &&
                (cells[countCoordinateY - 1, 1].State != CellState.BusyDeck) &&
                (cells[countCoordinateY + 1, 1].State != CellState.BusyDeck) &&
                (cells[countCoordinateY, 1].State != CellState.BusyDeck);
        }

        private static void FillRightVerticalLine(Cell[,] cells, int countCoordinateY)
        {
            cells[countCoordinateY + 1, cells.Length - 1].State = CellState.BusyDeckNearby;
            cells[countCoordinateY, cells.Length - 1].State = CellState.BusyDeck;
        }

        private static bool CanFillRightVerticalLine(Cell[,] cells, int countCoordinateY)
        {
            return (cells[countCoordinateY, cells.Length - 1].State == CellState.Empty) &&
                (cells[countCoordinateY - 1, cells.Length - 2].State != CellState.BusyDeck) &&
                (cells[countCoordinateY + 1, cells.Length - 2].State != CellState.BusyDeck) &&
                (cells[countCoordinateY, cells.Length - 2].State != CellState.BusyDeck);
        }
    }
}
