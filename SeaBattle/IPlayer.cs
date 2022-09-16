namespace SeaBattle
{
    public interface IPlayer// наверное еще нужен метод принятия выстрела 
    {
        string Name { get;}

        void FillShips();

        Point GetNextShootTarget();//(PlayArea area)

        ShootResultType OnShoot(Point target);

        PlayArea GetPlayArea();
    }

}
