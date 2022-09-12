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
            SeaBattleGame seaBattle = new SeaBattleGame(new ConsolePlayer(new Filler()), new BotPlayer(new Filler()));
            seaBattle.Start();
            //player.Move = true;
            //while (!player.IsLose && !bot.IsLose)
            //{
            //    FillConsole(playAreaForPlayer, playAreaForBot);
            //    if (player.Move)
            //    {
            //        int coordinateY = int.Parse(Console.ReadLine());
            //        int coordinateX = int.Parse(Console.ReadLine());
            //        player.Shoot(playAreaForBot, coordinateY, coordinateX);
            //        if (playAreaForBot.Cells[coordinateY, coordinateX].ConditionType == ConditionType.BusyDeck)
            //        {
            //            Console.WriteLine();
            //        }                                              
            //    }
            //    Console.Clear();
            //}


            ////var gameAction = new GameAction(playArea1, playArea2);
            ////while (true)
            ////{
            ////    while (gameAction.PlayerMove)
            ////    {
            ////        try
            ////        {
            ////            Console.WriteLine("Enter the coordinate. The first is vertical the second is horizontal.");
            ////            gameAction.Shoot(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            ////        }
            ////        catch (Exception)
            ////        {
            ////            continue;
            ////        }
            ////    }
            ////    gameAction.Shoot(0, 0);//0 0 - потому что ход бота    
            ////}

            //FillConsole(playAreaForPlayer, playAreaForBot);
            //if (player.IsLose)
            //{
            //    Console.WriteLine("Bot Win!!!");
            //}
            //Console.WriteLine("Player Win!!!");
            //Console.ReadLine();


        }

        static void FillConsole(PlayArea player, PlayArea bot)
        {
            FillFirstLineWithSignatures(player.Cells.GetLength(0));
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < player.Cells.GetLength(0); i++)
            {
                Console.Write(i + "|");
                FillPlayerWithVisibleShips(player, i);
                Console.Write("|" + i + "|");
                FillEnemyWithInvisibleShips(bot, i);
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
            for (int i = 0; i < playerOne.Cells.GetLength(1); i++)
            {
                if (playerOne.Cells[lineNumber, i].State == CellState.BusyDeckNearby)
                {
                    Console.Write(' ' + "|");
                    continue;
                }
                Console.Write(new CellStateToString(playerOne.Cells[lineNumber, i]) + "|");
            }
        }

        static void FillEnemyWithInvisibleShips(PlayArea bot, int lineNumber)
        {
            for (int k = 0; k < bot.Cells.GetLength(1); k++)
            {
                if ((bot.Cells[lineNumber, k].State == CellState.BusyDeckNearby || bot.Cells[lineNumber, k].State == CellState.BusyDeck))
                {
                    Console.Write(' ' + "|");
                    continue;
                }
                Console.Write(new CellStateToString(bot.Cells[lineNumber, k]) + "|");
            }
        }
    }
}
