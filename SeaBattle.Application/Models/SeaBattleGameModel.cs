using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Models
{
    public class SeaBattleGameModel
    {
        public string NameSession { get; private set; }

        public IPlayer Player1 { get; private set; }

        public IPlayer Player2 { get; private set; }

        public SeaBattleGameModel(IPlayer player1, IPlayer player2, string nameSession)
        {
            Player1 = player1;
            Player2 = player2;
            NameSession = nameSession;
        }

        public string Start()
        {
            var gameOver = false;
            var player1Turn = true;
            while (!gameOver)
            {
                if (player1Turn)
                {
                    Point target = Player1.GetNextShootTarget();
                    ShootResultType result = Player2.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    player1Turn = (result == ShootResultType.Kill) || (result == ShootResultType.Hit);
                    GetMessageForGameInformation(result);
                }
                else
                {
                    Point target = Player2.GetNextShootTarget();
                    ShootResultType result = Player1.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    player1Turn = result != ShootResultType.Kill && result != ShootResultType.Hit;
                    GetMessageForGameInformation(result);
                }
            }
            if (player1Turn)
            {
                return $"The winner is {Player2.Name}";
            }
            return $"The winner is {Player1.Name}";
        }

        private void GetMessageForGameInformation(ShootResultType shootResultType)// string message for client
        {
            if (shootResultType == ShootResultType.Kill)
            {
                Console.WriteLine("The ship is dead, press enter");
                return;
            }
            else if (shootResultType == ShootResultType.Hit)
            {
                Console.WriteLine("It's a hit! Press enter");
                return;
            }
        }
    }
}
