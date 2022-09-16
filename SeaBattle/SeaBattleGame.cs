using System;

namespace SeaBattle
{
    //public delegate void OnPlayerHit(string playerName);

    public class SeaBattleGame
    {
        //public event OnPlayerHit OnPlayerHit;

        //public OnPlayerHit onPlayerHit2;

        IPlayer player1;

        IPlayer player2;

        static Random rnd = new Random();

        public SeaBattleGame(IPlayer player1, IPlayer player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public string Start()//OnPlayerHit onPlayerHit
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
                    //onPlayerHit.Invoke(); //or onPlayerHit();
                    //if(onPlayerHit != null) onPlayerHit("palyer1");// || onPlayerHit?.Invoke();
                    // winner set
                    //OnPlayerHit?.Invoke("dsfsd");
                    player1Turn = (result == ShootResultType.Kill)||(result == ShootResultType.Hit);
                }
                else
                {
                    Point target = player2.GetNextShootTarget();
                    ShootResultType result = player1.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    // winner set
                    player1Turn = !(result == ShootResultType.Kill) || !(result == ShootResultType.Hit);
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
