using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle;

namespace ConsoleSeaBattle
{
    class Program
    {
        static void FillConsole(CreatorPlayArea player, CreatorPlayArea bot)
        {
            Console.Write("  ");
            for (int i = 0; i < player.cells.GetLength(0); i++)
            {
                Console.Write(i + "|");
            }
            Console.Write("   ");
            for (int i = 0; i < player.cells.GetLength(0); i++)
            {
                Console.Write(i + "|");
            }
            Console.WriteLine();

            for (int i = 0; i < player.cells.GetLength(0); i++)
            {
                Console.Write(i + "|");
                for (int j = 0; j < player.cells.GetLength(1); j++)
                {
                    if (player.cells[i, j].Condition == '-')
                    {
                        Console.Write(' ' + "|");
                        continue;
                    }
                    Console.Write(player.cells[i, j].Condition + "|");
                }
                Console.Write("|" + i + "|");
                for (int k = 0; k < player.cells.GetLength(1); k++)
                {
                    if ((bot.cells[i, k].Condition == '-' || bot.cells[i, k].Condition == '#'))
                    {
                        Console.Write(' ' + "|");
                        continue;
                    }
                    Console.Write(bot.cells[i, k].Condition + "|");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            var player = new CreatorPlayArea(10, 10);

            player.FillShipsRandomly(1, 4);
            player.FillShipsRandomly(2, 3);
            player.FillShipsRandomly(3, 2);
            //player.FillShipsRandomly(4, 1);
            //без бокового поля херово получается, баги есть и бывает нету места для корбалей         
            //может cделать метод который будет проверять правильное ки количество созданных корбалей, например для стандартного случая должно быть
            //1*4+2*3+3*2+4*1=20 клеток, если клеток не двадцать создавать заново поле, и так пока не будет 20
            //или писать для кораблей длиной в 1 клетку отдельную логику, где ими будет заполняться только боковые
            var bot = new CreatorPlayArea(10, 10);

            bot.FillShipsRandomly(1, 4);
            bot.FillShipsRandomly(2, 3);
            bot.FillShipsRandomly(3, 2);

            var gameAction = new GameAction(player, bot);
            while (!gameAction.IsLose(player) && !gameAction.IsLose(bot))
            {
                FillConsole(player, bot);
                while (gameAction.PlayerMove)
                {
                    try
                    {
                        Console.WriteLine("Enter the coordinate. The first is vertical the second is horizontal.");
                        gameAction.Shoot(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                gameAction.Shoot(0, 0);
                Console.Clear();
            }

            FillConsole(player, bot);
            if (gameAction.IsLose(player))
            {
                Console.WriteLine("Bot Win!!!");
            }
            Console.WriteLine("Player Win!!!");
            Console.ReadLine();
        }
    }
}
