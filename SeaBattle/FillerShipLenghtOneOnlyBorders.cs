using System;

namespace SeaBattle
{
    public class FillerShipLenghtOneOnlyBorders
    {

        public static Cell[,] FillShips(Cell[,] cells, Ship ship, int shipCount)
        {
            int firstCoordinate = 1;
            while (shipCount > 0 && firstCoordinate < 10)
            {
                if (CanFillUpHorizontalLine(cells, firstCoordinate) && shipCount > 0)
                {
                    FillUpHorizontalLine(cells, ship, firstCoordinate); shipCount--;
                }
                if (CanFillDownHorizontallLine(cells, firstCoordinate) && shipCount > 0)
                {
                    FillDownHorizontallLine(cells, ship, firstCoordinate); shipCount--;
                }
                if (CanFillLeftVerticalLine(cells, firstCoordinate) && shipCount > 0)
                {
                    FillLeftVerticalLine(cells, ship, firstCoordinate); shipCount--;
                }
                if (CanFillRightVerticalLine(cells, firstCoordinate) && shipCount > 0)
                {
                    FillRightVerticalLine(cells, ship, firstCoordinate); shipCount--;
                }
                firstCoordinate++;
            }
            return cells;
        }

        private static void FillUpHorizontalLine(Cell[,] cells, Ship ship, int countCoordinateX)
        {
            
            cells[0, countCoordinateX + 1].State = CellState.BusyDeckNearby;
            cells[0, countCoordinateX].State = CellState.BusyDeck;
            ship.PutDeck(0, countCoordinateX);
        }

        private static bool CanFillUpHorizontalLine(Cell[,] cells, int countCoordinateX)
        {
            return (cells[0, countCoordinateX].State == CellState.Empty) &&
                (cells[0, countCoordinateX - 1].State == CellState.Empty) &&
                   (cells[1, countCoordinateX - 1].State != CellState.BusyDeck) &&
                   (cells[1, countCoordinateX].State != CellState.BusyDeck) &&
                   (cells[1, countCoordinateX + 1].State != CellState.BusyDeck);
        }

        private static void FillDownHorizontallLine(Cell[,] cells, Ship ship, int countCoordinateX)
        {
            cells[cells.GetLength(0) - 1, countCoordinateX + 1].State = CellState.BusyDeckNearby;
            cells[cells.GetLength(0) - 1, countCoordinateX].State = CellState.BusyDeck;
            ship.PutDeck(cells.GetLength(0) - 1, countCoordinateX);
        }

        private static bool CanFillDownHorizontallLine(Cell[,] cells, int countCoordinateX)
        {
            return (cells[cells.GetLength(0) - 1, countCoordinateX].State == CellState.Empty) &&
                
                   (cells[cells.GetLength(0) - 2, countCoordinateX - 1].State != CellState.BusyDeck) &&
                   (cells[cells.GetLength(0) - 2, countCoordinateX].State != CellState.BusyDeck) &&
                   (cells[cells.GetLength(0) - 2, countCoordinateX + 1].State != CellState.BusyDeck);
        }

        private static void FillLeftVerticalLine(Cell[,] cells,Ship ship, int countCoordinateY)
        {
            cells[countCoordinateY + 1, 0].State = CellState.BusyDeckNearby;
            cells[countCoordinateY, 0].State = CellState.BusyDeck;
            ship.PutDeck(countCoordinateY, 0);
        }

        private static bool CanFillLeftVerticalLine(Cell[,] cells, int countCoordinateY)
        {
            return (cells[countCoordinateY, 0].State == CellState.Empty) &&                
                (cells[countCoordinateY - 1, 1].State != CellState.BusyDeck) &&
                (cells[countCoordinateY + 1, 1].State != CellState.BusyDeck) &&
                (cells[countCoordinateY, 1].State != CellState.BusyDeck);
        }

        private static void FillRightVerticalLine(Cell[,] cells,Ship ship, int countCoordinateY)
        {
            cells[countCoordinateY + 1, cells.GetLength(0) - 1].State = CellState.BusyDeckNearby;
            cells[countCoordinateY, cells.GetLength(0) - 1].State = CellState.BusyDeck;
            ship.PutDeck(countCoordinateY, cells.GetLength(0) - 1);
        }

        private static bool CanFillRightVerticalLine(Cell[,] cells, int countCoordinateY)
        {
            return (cells[countCoordinateY, cells.GetLength(0) - 1].State == CellState.Empty) &&                
                (cells[countCoordinateY - 1, cells.GetLength(0) - 2].State != CellState.BusyDeck) &&
                (cells[countCoordinateY + 1, cells.GetLength(0) - 2].State != CellState.BusyDeck) &&
                (cells[countCoordinateY, cells.GetLength(0) - 2].State != CellState.BusyDeck);
        }
    }
}
