using System.Collections.Generic;

namespace SeaBattle
{
    public class ShipsCreator
    {
        public static List<Ship> CreatShips(List<ShipConfige> configeShips)
        {
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
    }
}





