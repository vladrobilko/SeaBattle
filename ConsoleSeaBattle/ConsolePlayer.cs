using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle;

namespace ConsoleSeaBattle
{
    public class ConsolePlayer : IPlayer
    {
        public string Name { get; }

        private IShipsFiller _filler;

        PlayArea _playArea;

        PlayArea _playAreaEnemyForInformation;

        List<Ship> _ships;

        public ConsolePlayer(IShipsFiller filler)
        {
            _playArea = new PlayArea();
            _playAreaEnemyForInformation = new PlayArea();
            _filler = filler;
            _ships = CreatorShips.CreatShips(1, 2, 3, 4);
            Console.WriteLine("Enter your name");
            Name = Console.ReadLine();
        }

        public void FillShips()
        {
            _filler.FillShips(_playArea.Cells, _ships);
        }

        public Point GetNextShootTarget()
        {
            try
            {
                Console.WriteLine("Enter the vertical coordinate.");
                int Y = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the horizontal coordinate.");
                int X = int.Parse(Console.ReadLine());
                if (_playAreaEnemyForInformation.Cells[Y,X].State == CellState.HasShooted)
                {
                    Console.WriteLine("You have already shot here. Please enter again.");
                    GetNextShootTarget();
                }
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
            return ShootResult.Result(_ships, target);
        }

        public PlayArea GetPlayArea()
        {
            return _playArea;
        }
    }

}
