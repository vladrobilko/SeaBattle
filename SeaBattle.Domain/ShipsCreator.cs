using System.Collections.Generic;

namespace SeaBattle
{
    public class ShipsCreator
    {
        public static List<Ship> CreatShips(List<ShipConfige> configeShips = null)
        {
            if (configeShips == null)
            {
                configeShips = CreateShipsForDefaultGame();
            }

            var _ships = new List<Ship>();

            for (int i = 0; i < configeShips.Count; i++)
            {
                for (int j = 0; j < configeShips[i].CountShip; j++)
                {
                    _ships.Add(new Ship(configeShips[i].LengthShip));
                }
            }
            return _ships;
        }

        private static List<ShipConfige> CreateShipsForDefaultGame()
        {
            return new List<ShipConfige>() {
                new ShipConfige(1, 4),
                new ShipConfige(2, 3),
                new ShipConfige(3, 2),
                new ShipConfige(4, 1)
            };
        }
    }
}