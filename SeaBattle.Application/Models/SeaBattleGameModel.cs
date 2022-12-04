using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Models
{
    public class SeaBattleGameModel
    {
        IPlayer player1;

        IPlayer player2;

        public string NameSession { get; private set; }

        public SeaBattleGameModel(IPlayer player1, IPlayer player2, string nameSession)
        {
            this.player1 = player1;
            this.player2 = player2;
            NameSession = nameSession;
        }

        public string Start()
        {
            player1.FillShips();
            player2.FillShips();

            var gameOver = false;
            var player1Turn = true;
            while (!gameOver)
            {
                if (player1Turn)
                {
                    Point target = player1.GetNextShootTarget();
                    ShootResultType result = player2.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    player1Turn = (result == ShootResultType.Kill) || (result == ShootResultType.Hit);
                    GetMessageForGameInformation(result);
                }
                else
                {
                    Point target = player2.GetNextShootTarget();
                    ShootResultType result = player1.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    player1Turn = result != ShootResultType.Kill && result != ShootResultType.Hit;
                    GetMessageForGameInformation(result);
                }
            }
            if (player1Turn)
            {
                return $"The winner is {player2.Name}";
            }
            return $"The winner is {player1.Name}";
        }

        private void GetMessageForGameInformation(ShootResultType shootResultType)// string message for client
        {
            if (shootResultType == ShootResultType.Kill)
            {
                //ConsoleFillerForGame.FillConsole(player1, player2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The ship is dead, press enter");
                Console.ReadLine();
                Console.ResetColor();
                return;
            }
            else if (shootResultType == ShootResultType.Hit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //.FillConsole(player1, player2);
                Console.WriteLine("It's a hit! Press enter");
                Console.ReadLine();
                Console.ResetColor();
                return;
            }
        }
    }
}
