using SeaBattle;
using SeaBattleApi.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace SeaBattleApi.Models
{
    public class PlayerClient : IPlayerClient
    {
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
