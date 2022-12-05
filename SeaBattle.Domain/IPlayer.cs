namespace SeaBattle
{
    public interface IPlayer
    {
        string Name { get; set; }

        void FillShips();

        Point GetNextShootTarget(int Y = 0, int X = 0);

        ShootResultType OnShoot(Point target);

        PlayArea GetPlayArea();
    }
}