using System.Collections.Generic;

namespace SeaBattle
{
    public interface IFillerShips
    {        
        Cell[,] FillShips(Cell[,] cells, List<Ship> ships);
    }
}
