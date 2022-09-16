using System.Collections.Generic;

namespace SeaBattle
{
    public interface IShipsFiller
    {        
        Cell[,] FillShips(Cell[,] cells, List<Ship> ships);
    }
}
