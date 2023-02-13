using System;
using System.Collections.Generic;

namespace SeaBattle
{
    public class PlayerEasyBot : IPlayer
    {
        public string NamePlayer { get; set; } = "Easy bot";

        private readonly IFillerShips _filler;

        private readonly PlayArea _playArea;

        private readonly PlayArea _playAreaEnemyForInformation;

        public List<Ship> Ships { get; }

        private static readonly  Random Random = new Random();

        public PlayerEasyBot(IFillerShips filler)
        {
            _playArea = new PlayArea();
            _playAreaEnemyForInformation = new PlayArea();
            _filler = filler;
            Ships = ShipsCreator.CreateShips(new List<ShipConfigure>()
            { new ShipConfigure(1,4), new ShipConfigure(2, 3), new ShipConfigure(3, 2), new ShipConfigure(4, 1) });       
        }

        public void FillShips()
        {
            _filler.FillShips(_playArea.Cells, Ships);
        }

        public Point GetNextValidShootTarget()
        {
            var y = Random.Next(10);
            var x = Random.Next(10);
            while (_playAreaEnemyForInformation.Cells[y, x].State != CellState.HasShot)
            {
                _playAreaEnemyForInformation.Cells[y, x].State = CellState.HasShot;
                
                return new Point(y, x);
            }
            return GetNextValidShootTarget();
        }

        public ShootResultType OnShoot(Point target)
        {
            var shootResultType = Shooter.Result(Ships, target);
            _playArea.Cells[target.Y, target.X].State = CellState.HasShot;
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
