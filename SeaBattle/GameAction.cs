using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public interface IShoot
    {
        PlayArea Shoot(PlayArea playAreaEnemy, int y, int x);
    }

    public class Player : IShoot
    {
        private PlayArea playArea;

        public bool IsLose
        {
            get
            {
                for (int i = 0; i < playArea.cells.GetLength(0); i++)
                {
                    for (int j = 0; j < playArea.cells.GetLength(1); j++)
                    {
                        if (playArea.cells[i, j].ConditionType == ConditionType.BusyDeck)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public Player(PlayArea playArea)
        {
            this.playArea = playArea;
        }

        public PlayArea Shoot(PlayArea playAreaEnemy, int y, int x)
        {
            if (playAreaEnemy.cells[y, x].ConditionType == ConditionType.BusyDeck && !playAreaEnemy.cells[y, x].HasShooted)
            {
                playAreaEnemy.cells[y, x].ConditionType = ConditionType.HasShooted;
                playAreaEnemy.cells[y, x].HasShooted = true;
                return playAreaEnemy;
            }
            else if (!playAreaEnemy.cells[y, x].HasShooted)
            {
                playAreaEnemy.cells[y, x].ConditionType = ConditionType.HasMiss;
                playAreaEnemy.cells[y, x].HasShooted = true;
                return playAreaEnemy;
            }
            return playAreaEnemy;//в данном случае выстрела не будет, тогда проверять это в Program, если равны PlayArea то делать заново
        }
    }


    public class Game
    {
        Player player1;
        Player player2;

        private bool _gameOver;

        public bool GameOver
        {
            get { return player1.IsLose && player2.IsLose; }
        }


        public Game(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void PlayGame(IShoot shoot)
        {

        }
    }


      // Делать класс Player класс Bot у них Интерфейсы IShoot поля PlayArea
     //Класс SeaBattleGame - в нем конструктор который примет двух игроков с игровыми аренами, и реализация выстрелов
    //методы SeaBattleGame - bool GameOver(), void Game(), bool IsShipKilled







}
