using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    public class GameAction
    {
        CreatorPlayArea player;
        CreatorPlayArea easyBot;

        static Random rnd = new Random();

        public bool PlayerMove
        {
            get { return !EasyBotMove; }
        }

        public bool EasyBotMove { get; set; }

        public GameAction(CreatorPlayArea player, CreatorPlayArea bot)
        {
            this.player = player;
            this.easyBot = bot;
        }

        public void Shoot(int y, int x)
        {
            if (PlayerMove && easyBot.cells[y, x].Condition == '#' && !easyBot.cells[y, x].IsShooting)
            {
                easyBot.cells[y, x].Condition = 'x';
                easyBot.cells[y, x].IsShooting = true;
                return;
            }
            else if (PlayerMove && !easyBot.cells[y, x].IsShooting)
            {
                easyBot.cells[y, x].Condition = '*';
                easyBot.cells[y, x].IsShooting = true;
                EasyBotMove = true;
                return;
            }

            if (EasyBotMove)
            {
                int rndY = rnd.Next(10);
                int rndX = rnd.Next(10);
                while (player.cells[rndY, rndX].IsShooting)
                {
                    rndY = rnd.Next(10);
                    rndX = rnd.Next(10);
                }
                if (player.cells[rndY, rndX].Condition == '#')
                {
                    player.cells[rndY, rndX].Condition = 'x';
                    player.cells[rndY, rndX].IsShooting = true;
                    return;
                }
                else
                {
                    player.cells[rndY, rndX].Condition = '*';
                    player.cells[rndY, rndX].IsShooting = true;
                    EasyBotMove = false;
                    return;
                }
            }
        }

        public bool IsLose(CreatorPlayArea playArea)
        {
            for (int i = 0; i < playArea.cells.GetLength(0); i++)
            {
                for (int j = 0; j < playArea.cells.GetLength(1); j++)
                {
                    if (playArea.cells[i, j].Condition == '#')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
