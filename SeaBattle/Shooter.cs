using System.Collections.Generic;
using System.Linq;

namespace SeaBattle
{
    public class Shooter
    {
        public static ShootResultType Result(List<Ship> shipsTarget, Point pointShoot)
        {
            var ship = SearchShip(shipsTarget, pointShoot);
            var shootResultType = ship == null ? ShootResultType.Miss : ShootResultType.Hit;
            if (shootResultType == ShootResultType.Hit)
            {
                KillDeck(ship, pointShoot);                
                shootResultType = IsAllShipsDead(shipsTarget) ? ShootResultType.GameOver : ShootResultType.Hit;
                if (IsShipDead(ship) && shootResultType != ShootResultType.GameOver)
                    shootResultType = ShootResultType.Kill;
            }
            return shootResultType;
        }

        private static Ship SearchShip(List<Ship> ships, Point point)
        {
            foreach (var ship in ships)
            {
                //condition ? value1 : value2;
                //.?
                //if (ship._decks.Any(deck => deck != null && deck.Point.Y == point.Y && deck.Point.X == point.X)) return ship;
                //ship?.obj1 == null
                //if here null ?? value;


                foreach (var deck in ship._decks)
                {
                    if (deck != null && deck.Point.Y == point.Y && deck.Point.X == point.X)
                        return ship;
                }
            }
            return null;
        }

        private static Ship KillDeck(Ship ship, Point point)
        {
            for (int i = 0; i < ship.Length; i++)
            {
                if (ship._decks[i] != null && ship._decks[i].Point.Y == point.Y && ship._decks[i].Point.X == point.X)
                    ship._decks[i] = null;
            }
            return ship;
        }

        private static bool IsAllShipsDead(List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                if (!IsShipDead(ship))
                    return false;
            }
            return true;
        }


        private static bool IsShipDead(Ship ship)
        {
            foreach (var deck in ship._decks)
            {
                if (deck != null)
                    return false;
            }
            return true;
        }
    }

}
