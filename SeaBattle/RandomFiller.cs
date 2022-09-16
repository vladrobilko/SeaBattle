using System.Collections.Generic;

namespace SeaBattle
{
    public class RandomFiller : IShipsFiller
    {
        public Cell[,] FillShips(Cell[,] cells, List<Ship> ships)
        {
            for (int i = 0; i < ships.Count; i++)
            {
                if (ships[i].Length == 1)
                {
                    ShipLenghtOneFillerOnlyBorders.FillShips(cells, ships[i], 1);
                }
                RandomShipsFillerWithoutBorders.FillShip(cells, ships[i]);
            }
            return cells;
        }

        void Comments()
        {

            // не понимаю нафига нам создовать набор одинаковых заполнителей для разных кораблей
            // мы врядли будем раставлять одни корабли одним смособом например рандомно, а другие вручную
            // ну и ваще игрок должен раставлять свои корабли с помощью растановщика
            // это тоже этап игры, даже если они сейчас рандомно раставлябтся
            //List<IShipsFiller> fillShips = new List<IShipsFiller>();
            //fillShips.Add(new RandomShipsFiller(1, 4));// без интерфейса
            //fillShips.Add(new RandomShipsFiller(2, 3));
            //fillShips.Add(new RandomShipsFiller(3, 2));
            //fillShips.Add(new ShipLenghtOneFiller(4)); // этот кусок это кусок рандомного филлера кораблей, он может быть в отдельном классе
            // но не надо ломать архитектуру из за того что у тебя имлементация одного филлера требудет вспомогательных классов
            // Ибо выходит что я в данном месте должен знать порядок и какие филлеры юзать что бы ратваить каждый тип корабля рандомно
            //foreach (var item in fillShips)
            //{
            //item.FillShips(playArea.Cells);уже не работает
            //}

        }
    }
}