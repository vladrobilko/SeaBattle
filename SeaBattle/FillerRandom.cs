using System.Collections.Generic;

namespace SeaBattle
{
    public class FillerRandom : IFillerShips
    {
        public Cell[,] FillShips(Cell[,] cells, List<Ship> ships)
        {

            for (int i = 0; i < ships.Count; i++)
            {
                if (ships[i].Length == 1)
                {
                    FillerRandomShipLenghtOneOnlyBorders.FillShips(cells, ships[i]);
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