using System.Collections.Generic;

namespace SeaBattle
{
    public class ShipsCreator
    {
        public static List<Ship> CreateShips(List<ShipConfige> configureShips)
        {
            var ships = new List<Ship>();

            for (int i = 0; i < configureShips.Count; i++)
            {
                for (int j = 0; j < configureShips[i].CountShip; j++)
                {
                    ships.Add(new Ship(configureShips[i].LengthShip));
                }
            }
            return ships;
        }

        public static List<Ship> CreateShipsForDefaultGame()
        {
            return CreateShips(GetConfigureShips());
        }

        private static List<ShipConfige> GetConfigureShips()
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