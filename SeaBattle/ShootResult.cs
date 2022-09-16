using System.Collections.Generic;

namespace SeaBattle
{    
    public class ShootResult
    {
        public static ShootResultType Result(List<Ship> shipsTarget, Point pointShoot)
        {
            Ship ship = SearchShip(shipsTarget, pointShoot);
            if (ship == null)
            {
                return ShootResultType.Miss;
            }
            KillDeck(ship, pointShoot);
            if (IsShipDead(ship))
            {
                if (IsAllShipsDead(shipsTarget))
                {
                    return ShootResultType.GameOver;
                }
                return ShootResultType.Kill;
            }
            else if (!IsShipDead(ship))
            {
                return ShootResultType.Hit;
            }
            return ShootResultType.Miss;
        }

        private static Ship SearchShip(List<Ship> ships, Point point)
        {
            foreach (var ship in ships)
            {
                foreach (var deck in ship._decks)
                {
                    if (deck.Point.Y == point.Y && deck.Point.X == point.X)//тут null вылетает 
                    {
                        return ship;
                    }
                }
            }
            return null;
        }

        private static Ship KillDeck(Ship ship, Point point)
        {
            for (int i = 0; i < ship.Length; i++)
            {
                if (ship._decks[i].Point.Y == point.Y && ship._decks[i].Point.X == point.X)
                {
                    ship._decks[i] = null;
                }
            }
            return ship;
        }

        private static bool IsAllShipsDead(List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                if (!IsShipDead(ship))
                {
                    return false;
                }
            }
            return true;
        }
              
       
        private static bool IsShipDead(Ship ship)
        {
            foreach (var deck in ship._decks)
            {
                if (deck != null)
                {
                    return false;
                }
            }
            return true;
        }
    }

}
