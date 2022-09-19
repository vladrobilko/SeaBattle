using System.Collections.Generic;

namespace SeaBattle
{
    public class ShipsCreator
    {
        public static List<Ship> CreatShips(int countShipsLengthFour,
            int countShipsLengthThree, int countShipsLengthTwo, int countShipsLengthtOne)
        {
            var _ships = new List<Ship>();

            for (int i = 0; i < countShipsLengthFour; i++)
            {
                _ships.Add(new Ship(4));
            }
            for (int i = 0; i < countShipsLengthThree; i++)
            {
                _ships.Add(new Ship(3));
            }
            for (int i = 0; i < countShipsLengthTwo; i++)
            {
                _ships.Add(new Ship(2));
            }
            for (int i = 0; i < countShipsLengthtOne; i++)
            {
                _ships.Add(new Ship(1));
            }
            return _ships;
        }

    }
}





