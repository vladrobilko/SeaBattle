namespace SeaBattle
{
    public interface IPlayer
    {
        string Name { get; set; }
        void FillShips();
        Point GetNextShootTarget(int y = 0, int x = 0);
        ShootResultType OnShoot(Point target);
        PlayArea GetPlayArea();
    }
}