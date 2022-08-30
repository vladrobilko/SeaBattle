using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class GameAction
    {
        PlayArea player;
        PlayArea easyBot;

        static Random rnd = new Random();

        public bool PlayerMove
        {
            get { return !EasyBotMove; }
        }

        public bool EasyBotMove { get; set; }

        public GameAction(PlayArea player, PlayArea bot)
        {
            this.player = player;            
            this.easyBot = bot;
        }

        public void Shoot(int y, int x)
        {
            if (PlayerMove && easyBot.cells[y, x].ConditionType == ConditionType.BusyShip && !easyBot.cells[y, x].HasShooted)
            {
                easyBot.cells[y, x].ConditionType = ConditionType.HasShooted;
                easyBot.cells[y, x].HasShooted = true;
                return;
            }
            else if (PlayerMove && !easyBot.cells[y, x].HasShooted)
            {
                easyBot.cells[y, x].ConditionType = ConditionType.HasMiss;
                easyBot.cells[y, x].HasShooted = true;
                EasyBotMove = true;
                return;
            }

            if (EasyBotMove)
            {
                int rndY = rnd.Next(10);
                int rndX = rnd.Next(10);
                while (player.cells[rndY, rndX].HasShooted)
                {
                    rndY = rnd.Next(10);
                    rndX = rnd.Next(10);
                }
                if (player.cells[rndY, rndX].ConditionType == ConditionType.BusyShip)
                {
                    player.cells[rndY, rndX].ConditionType = ConditionType.HasShooted;
                    player.cells[rndY, rndX].HasShooted = true;
                    return;
                }
                else
                {
                    player.cells[rndY, rndX].ConditionType = ConditionType.HasMiss;
                    player.cells[rndY, rndX].HasShooted = true;
                    EasyBotMove = false;
                    return;
                }
            }
        }

        public bool IsLose(PlayArea playArea)
        {
            for (int i = 0; i < playArea.cells.GetLength(0); i++)
            {
                for (int j = 0; j < playArea.cells.GetLength(1); j++)
                {
                    if (playArea.cells[i, j].ConditionType == ConditionType.BusyShip)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
