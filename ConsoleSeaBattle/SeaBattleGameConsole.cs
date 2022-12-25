using SeaBattle;
using System;

namespace ConsoleSeaBattle
{
    internal class SeaBattleGameConsole
    {
 
        IPlayer player1;

        IPlayer player2;

        public SeaBattleGameConsole(IPlayer player1, IPlayer player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public string Start()
        {
            player1.FillShips();
            player2.FillShips();

            var gameOver = false;
            var player1Turn = true;
            while (!gameOver)
            {
                ConsoleFillerForGame.FillConsole(player1, player2);
                if (player1Turn)
                {
                    Point target = player1.GetNextShootTarget();
                    ShootResultType result = player2.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    player1Turn = (result == ShootResultType.Kill) || (result == ShootResultType.Hit);
                    GetConsoleInfoAfterKillOrHitShip(result);
                }
                else
                {
                    Point target = player2.GetNextShootTarget();
                    ShootResultType result = player1.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    player1Turn = result != ShootResultType.Kill && result != ShootResultType.Hit;
                }
            }            
            if (player1Turn)
            {                
                return $"The winner is {player2.NamePlayer}";
            }            
            return $"The winner is {player1.NamePlayer}";
        }

        private void GetConsoleInfoAfterKillOrHitShip(ShootResultType shootResultType)
        {
            if (shootResultType == ShootResultType.Kill)
            {
                ConsoleFillerForGame.FillConsole(player1, player2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The ship is dead, press enter");
                Console.ReadLine();
                Console.ResetColor();
                return;
            }
            else if (shootResultType == ShootResultType.Hit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ConsoleFillerForGame.FillConsole(player1, player2);
                Console.WriteLine("It's a hit! Press enter");
                Console.ReadLine();
                Console.ResetColor();
                return;
            }
        }
    }

}
