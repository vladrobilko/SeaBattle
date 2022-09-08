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
        static void Main(string[] args)
        {
            while (true)
            {
                List<IShipsFiller> fillShips1 = new List<IShipsFiller>();
                fillShips1.Add(new RandomShipsFiller(1, 4));
                fillShips1.Add(new RandomShipsFiller(2, 3));
                fillShips1.Add(new RandomShipsFiller(3, 2));
                fillShips1.Add(new ShipLenghtOneFiller(4));

                var playArea1 = new PlayArea(10, 10, fillShips1);

                List<IShipsFiller> fillShips2 = new List<IShipsFiller>();
                fillShips2.Add(new RandomShipsFiller(1, 4));
                fillShips2.Add(new RandomShipsFiller(2, 3));
                fillShips2.Add(new RandomShipsFiller(3, 2));
                fillShips2.Add(new ShipLenghtOneFiller(4));

                var playArea2 = new PlayArea(10, 10, fillShips2);

                //var gameAction = new GameAction(playArea1, playArea2);
                //while (true)
                //{
                //    FillConsole(playArea1, playArea2);
                //    while (gameAction.PlayerMove)
                //    {
                //        try
                //        {
                //            Console.WriteLine("Enter the coordinate. The first is vertical the second is horizontal.");
                //            gameAction.Shoot(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                //        }
                //        catch (Exception)
                //        {
                //            continue;
                //        }
                //    }
                //    gameAction.Shoot(0, 0);//0 0 - потому что ход бота
                //    Console.Clear();
                //}

                FillConsole(playArea1, playArea2);
                if (true)
                {
                    Console.WriteLine("Bot Win!!!");
                }
                Console.WriteLine("Player Win!!!");
                Console.ReadLine();
            }

        }
        static void FillConsole(PlayArea player, PlayArea bot)
        {
            FillFirstLineWithSignatures(player.cells.GetLength(0));
            Console.SetCursorPosition(0,1);
            for (int i = 0; i < player.cells.GetLength(0); i++)
            {
                Console.Write(i + "|");
                FillPlayerWithVisibleShips(player, i);
                Console.Write("|" + i + "|");
                FillBotWithInvisibleShips(bot, i);
                Console.SetCursorPosition(0, i + 2);
            }
        }

        static void FillFirstLineWithSignatures(int lenght)
        {
            Console.SetCursorPosition(2, 0);
            for (int i = 0; i < lenght; i++)
            {
                Console.SetCursorPosition(2 + i * 2, 0);
                Console.Write(i + "|");
                Console.SetCursorPosition((2 * lenght) + i * 2 + 5, 0);
                Console.Write(i + "|");
            }
        }

        static void FillPlayerWithVisibleShips(PlayArea playerOne, int lineNumber)
        {
            for (int i = 0;i < playerOne.cells.GetLength(1); i++)
            {
                if (playerOne.cells[lineNumber, i].ConditionType == ConditionType.BusyDeckNearby)
                {
                    Console.Write(' ' + "|");
                    continue;
                }
                Console.Write(playerOne.cells[lineNumber, i].ConditionTypeToString() + "|");
            }
        }

        static void FillBotWithInvisibleShips(PlayArea bot, int lineNumber)
        {
            for (int k = 0; k < bot.cells.GetLength(1); k++)
            {
                if ((bot.cells[lineNumber, k].ConditionType == ConditionType.BusyDeckNearby || bot.cells[lineNumber, k].ConditionType == ConditionType.BusyDeck))
                {
                    Console.Write(' ' + "|");
                    continue;
                }
                Console.Write(bot.cells[lineNumber, k].ConditionTypeToString() + "|");
            }
        }
    }
}
