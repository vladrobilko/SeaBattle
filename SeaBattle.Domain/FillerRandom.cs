using System.Collections.Generic;

namespace SeaBattle
{
    public class FillerRandom : IFillerShips
    {
        public Cell[,] FillShips(Cell[,] cells, List<Ship> ships)
        {
            for (var i = 0; i < ships.Count; i++)
            {
                if (ships[i].Length == 1)
                {
                    FillerRandomShipLengthOneOnlyBorders.FillShips(cells, ships[i]);
                }

                else
                {
                    FillerRandomShipsWithoutBorders.FillShip(cells, ships[i]);
                }
            }
            return cells;
        }
    }
}