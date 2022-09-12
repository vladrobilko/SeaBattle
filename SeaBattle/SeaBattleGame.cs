using System;

namespace SeaBattle
{


    public class SeaBattleGame   //Game я бы добавил
    {
        IPlayer player1;
        IPlayer player2;


        static Random rnd = new Random();

        public bool GameOver
        {
            get { return player1.IsLose() && player2.IsLose(); }
        }

        public SeaBattleGame(IPlayer player1, IPlayer player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        // Надеюсь ты не собераешься все комбиныции дописывать) а если я захочу 3д игроков добавить?
        // У игры должен быть один метод публичный в теории - Start()
        public void Start()
        {
            while (!GameOver)
            {                
                if (true)
                {
                    
                }
                else if (true)
                {

                }
            }
        }

        //??
        //private bool IsShipDead(Player player)
        //{
           
        //    return true;
        //}

    }
}
