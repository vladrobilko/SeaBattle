using System;

namespace SeaBattle
{
    public class SeaBattleGame
    {
        IPlayer player1;

        IPlayer player2;

        public SeaBattleGame(IPlayer player1, IPlayer player2)
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
                if (player1Turn)
                {
                    var target = player1.GetNextShootTarget();
                    var result = player2.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    player1Turn = (result == ShootResultType.Kill) || (result == ShootResultType.Hit);
                }
                else
                {
                    var target = player2.GetNextShootTarget();
                    var result = player1.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    player1Turn = result != ShootResultType.Kill && result != ShootResultType.Hit;
                }
            }
            if (player1Turn)
            {
                return $"The winner is {player1.Name}";
            }
            return $"The winner is {player2.Name}";
        }
    }
}
