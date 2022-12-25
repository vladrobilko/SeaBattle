namespace SeaBattle
{
    public interface IPlayer
    {
        string NamePlayer { get; }

        void FillShips();

        Point GetNextShootTarget();

        ShootResultType OnShoot(Point target);

        PlayArea GetPlayArea();
    }
}