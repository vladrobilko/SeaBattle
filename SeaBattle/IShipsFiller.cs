namespace SeaBattle
{
    public interface IShipsFiller
    {
        int ShipCount { get; set; }

        int ShipLength { get; set; }

        Cell[,] FillShips(Cell[,] cells);
    }


}
