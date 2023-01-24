using System;
using System.Collections.Generic;

namespace SeaBattle
{
    public class PlayerEasyBot : IPlayer
    {
        public string NamePlayer { get; set; } = "Easy bot";

        IFillerShips _filler;

        PlayArea _playArea;

        PlayArea _playAreaEnemyForInformation;

        public List<Ship> _ships { get; }

        static Random rnd = new Random();

        public PlayerEasyBot(IFillerShips filler)
        {
            _playArea = new PlayArea();
            _playAreaEnemyForInformation = new PlayArea();
            _filler = filler;
            _ships = ShipsCreator.CreatShips(new List<ShipConfige>()
            { new ShipConfige(1,4), new ShipConfige(2, 3), new ShipConfige(3, 2), new ShipConfige(4, 1) });       
        }

        public void FillShips()
        {
            _filler.FillShips(_playArea.Cells, _ships);
        }

        public Point GetNextValidShootTarget()
        {
            int Y = rnd.Next(10);
            int X = rnd.Next(10);
            while (_playAreaEnemyForInformation.Cells[Y, X].State != CellState.HasShooted)
            {
                _playAreaEnemyForInformation.Cells[Y, X].State = CellState.HasShooted;
                
                return new Point(Y, X);
            }
            return GetNextValidShootTarget();
        }

        public ShootResultType OnShoot(Point target)
        {
            ShootResultType shootResultType = Shooter.Result(_ships, target);
            _playArea.Cells[target.Y, target.X].State = CellState.HasShooted;
            if (shootResultType == ShootResultType.Miss)
            {
                _playArea.Cells[target.Y, target.X].State = CellState.HasMiss;
            }
            else if (shootResultType == ShootResultType.Hit || shootResultType == ShootResultType.Kill)
            {
                _playArea.Cells[target.Y, target.X].State = CellState.HasHit;
            }
            return shootResultType;
        }

        public PlayArea GetPlayArea()
        {           
            return new PlayArea(_playArea);
        }
    }

}
