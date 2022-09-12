namespace SeaBattle
{
    // Filler только для одного типа кораблей? както странно, они потом соберусть в большого автобота(зачеркнуто) в универсальный филлер?)
    public interface IShipsFiller
    {
        //int ShipCount { get; set; } думаю это не надо в интерфейсе

        //nt ShipLength { get; set; } думаю это не надо в интерфейсе

         Cell[,] FillShips(Cell[,] cells);
    }
}
