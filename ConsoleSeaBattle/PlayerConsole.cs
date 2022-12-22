using System;
using System.Collections.Generic;
using SeaBattle;

namespace ConsoleSeaBattle
{
    public class PlayerConsole : IPlayer
    {
        public string Name { get; set; }

        private IFillerShips _filler;

        PlayArea _playArea;

        PlayArea _playAreaEnemyForInformation;

        List<Ship> _ships;

        public PlayerConsole(IFillerShips filler)
        {
            _playArea = new PlayArea();
            _playAreaEnemyForInformation = new PlayArea();
            _filler = filler;
            _ships = ShipsCreator.CreatShips(new List<ShipConfige>()
            { new ShipConfige(1,4), new ShipConfige(2, 3), new ShipConfige(3, 2), new ShipConfige(4, 1) });
            Console.WriteLine("Enter your name");
            Name = Console.ReadLine();
            Console.Clear();
        }

        public void FillShips()
        {
            _filler.FillShips(_playArea.Cells, _ships);
        }

        public PlayArea GetPlayArea()
        {
            return new PlayArea(_playArea);
        }

        public Point GetNextShootTarget()
        {
            try
            {
                Console.WriteLine("Enter the vertical coordinate.");
                int Y = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the horizontal coordinate.");
                int X = int.Parse(Console.ReadLine());
                if (_playAreaEnemyForInformation.Cells[Y, X].State == CellState.HasShooted)
                {
                    Console.WriteLine("You have already shot here. Please enter again.");
                    Console.WriteLine("Enter the vertical coordinate.");
                    Y = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the horizontal coordinate.");
                    X = int.Parse(Console.ReadLine());
                }
                _playAreaEnemyForInformation.Cells[Y, X].State = CellState.HasShooted;
                return new Point(Y, X);
            }
            catch (Exception)
            {
                Console.WriteLine("Error. Please enter again.");
                return GetNextShootTarget();
            }
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
    }

}
