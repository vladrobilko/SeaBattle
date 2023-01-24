using System.Collections.Generic;

namespace SeaBattle
{
    public interface IPlayer
    {
        string NamePlayer { get; }

        List<Ship> _ships { get; }

        void FillShips();

        Point GetNextValidShootTarget();

        ShootResultType OnShoot(Point target);

        PlayArea GetPlayArea();
    }
}