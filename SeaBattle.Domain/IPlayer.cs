using System.Collections.Generic;

namespace SeaBattle
{
    public interface IPlayer
    {
        string NamePlayer { get; }

        List<Ship> Ships { get; }

        void FillShips();

        Point GetNextValidShootTarget();

        ShootResultType OnShoot(Point target);

        PlayArea GetPlayArea();
    }
}