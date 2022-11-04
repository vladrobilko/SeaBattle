using SeaBattle;
using SeaBattleApi.Services.Intefaces;

namespace SeaBattleApi.Services
{
    public class PlayerClientService : IPlayerClientService
    {

        public string Name { get; set; }

        public string ID { get; } = Guid.NewGuid().ToString();

        public string TimeAdding { get; } = DateTime.Now.ToString();

        public void FillShips()
        {
            throw new NotImplementedException();
        }

        public Point GetNextShootTarget()
        {
            throw new NotImplementedException();
        }

        public PlayArea GetPlayArea()
        {
            throw new NotImplementedException();
        }

        public ShootResultType OnShoot(Point target)
        {
            throw new NotImplementedException();
        }


    }
}
