using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class EasyBotPlayer : IPlayer
    {
        public string Name { get; } = "Easy bot";

        IShipsFiller _filler;

        PlayArea _playArea;

        PlayArea _playAreaEnemyForInformation;

        List<Ship> _ships;

        static Random rnd = new Random();

        public EasyBotPlayer(IShipsFiller filler)
        {
            _playArea = new PlayArea();
            _playAreaEnemyForInformation = new PlayArea();
            _filler = filler;
            _ships = CreatorShips.CreatShips(1, 2, 3, 4);
        }

        public void FillShips()
        {
            _filler.FillShips(_playArea.Cells, _ships);
        }

        public Point GetNextShootTarget()
        {
            int Y = rnd.Next(10);
            int X = rnd.Next(10);
            while (_playAreaEnemyForInformation.Cells[Y, X].State != CellState.HasShooted)
            {
                _playAreaEnemyForInformation.Cells[Y, X].State = CellState.HasShooted;
                return new Point(Y, X);
            }
            return GetNextShootTarget();
        }

        public ShootResultType OnShoot(Point target)
        {            
            return ShootResult.Result(_ships, target);
        }

        public PlayArea GetPlayArea()
        {
            return _playArea;
        }
    }

}
