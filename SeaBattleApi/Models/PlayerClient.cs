using SeaBattle;
using SeaBattleApi.Models.Interfaces;

namespace SeaBattleApi.Models
{
    public class PlayerClient : IPlayerClient
    {
        public string ID { get; } = Guid.NewGuid().ToString();
        public string TimeAdding { get; } = DateTime.Now.ToString();
        public string Name { get; set; }



        //PlayerSeaBattleGame
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
