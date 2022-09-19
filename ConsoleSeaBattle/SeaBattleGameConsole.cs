using SeaBattle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    if (result == ShootResultType.Kill)
                    {
                        //заполнить корабль вокруг                        
                        ConsoleFillerForGame.FillConsole(player1, player2);
                        Console.WriteLine("The ship is dead, press enter");
                        Console.ReadLine();
                    }
                    if (result == ShootResultType.Hit)
                    {                        
                        ConsoleFillerForGame.FillConsole(player1, player2); 
                        Console.WriteLine("it's a hit! Press enter");
                        Console.ReadLine();
                    }                    
                }
                else
                {
                    Point target = player2.GetNextShootTarget();
                    ShootResultType result = player1.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    if (result == ShootResultType.Kill || result == ShootResultType.Hit)
                    {
                        player1Turn = false;

                    }
                    else
                    {
                        player1Turn = true;
                    }                    
                }
            }            
            if (player1Turn)
            {                
                return $"The winner is {player2.Name}";
            }            
            return $"The winner is {player1.Name}";
        }



    }
}
