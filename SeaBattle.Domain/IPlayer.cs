namespace SeaBattle
{
    public interface IPlayer
    {
        string NamePlayer { get; }

        void FillShips();

        Point GetNextValidShootTarget();

        ShootResultType OnShoot(Point target);

        PlayArea GetPlayArea();
    }
}