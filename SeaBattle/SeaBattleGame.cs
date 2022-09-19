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
                    var target = player1.GetNextShootTarget();                    
                    var result = player2.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    //onPlayerHit.Invoke(); //or onPlayerHit();
                    //if(onPlayerHit != null) onPlayerHit("palyer1");// || onPlayerHit?.Invoke();
                    // winner set
                    //OnPlayerHit?.Invoke("dsfsd");
                    player1Turn = (result == ShootResultType.Kill)||(result == ShootResultType.Hit);
                }
                else
                {
                    var target = player2.GetNextShootTarget();
                    var result = player1.OnShoot(target);
                    gameOver = (result == ShootResultType.GameOver);
                    //player1Turn = (result == ShootResultType.Kill) || (result == ShootResultType.Hit); - почему то это не работает
                    if (result == ShootResultType.Kill || result == ShootResultType.Hit)
                    {
                        player1Turn = false;

                    }
                    else
                    {
                        player1Turn = true;
                    }                    
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
