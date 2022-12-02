namespace SeaBattle
{
    public interface IPlayer
    {
        string Name { get; set; }
        void FillShips();
        Point GetNextShootTarget();
        ShootResultType OnShoot(Point target);
        PlayArea GetPlayArea();
    }
}