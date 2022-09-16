using System;
using SeaBattle;

namespace ConsoleSeaBattle
{

    public class ConsoleFillerForGame //Не понятно как взять арену игрока, или сюда что то другое передавать или нет
    {
        //public static void FillConsole(IPlayer player, IPlayer enemy)
        //{
        //    FillFirstLineWithSignatures(player.PlayArea.Cells.GetLength(0));
        //    Console.SetCursorPosition(0, 1);
        //    for (int i = 0; i < player.PlayArea.Cells.GetLength(0); i++)
        //    {
        //        Console.Write(i + "|");
        //        FillPlayerWithVisibleShips(player, i);
        //        Console.Write("|" + i + "|");
        //        FillEnemyWithInvisibleShips(enemy, i);
        //        Console.SetCursorPosition(0, i + 2);
        //    }
        //}

        //private static void FillFirstLineWithSignatures(int lenght)
        //{
        //    Console.SetCursorPosition(2, 0);
        //    for (int i = 0; i < lenght; i++)
        //    {
        //        Console.SetCursorPosition(2 + i * 2, 0);
        //        Console.Write(i + "|");
        //        Console.SetCursorPosition((2 * lenght) + i * 2 + 5, 0);
        //        Console.Write(i + "|");
        //    }
        //}

        //private static void FillPlayerWithVisibleShips(IPlayer player, int lineNumber)
        //{
        //    for (int i = 0; i < player.PlayArea.Cells.GetLength(1); i++)
        //    {
        //        if (player.PlayArea.Cells[lineNumber, i].State == CellState.BusyDeckNearby)
        //        {
        //            Console.Write(' ' + "|");
        //            continue;
        //        }
        //        Console.Write(ConsoleCellState.ToString(player.PlayArea.Cells[lineNumber, i]) + "|");
        //    }
        //}

        //static void FillEnemyWithInvisibleShips(IPlayer enemy, int lineNumber)
        //{
        //    for (int k = 0; k < enemy.PlayArea.Cells.GetLength(1); k++)
        //    {
        //        if ((enemy.PlayArea.Cells[lineNumber, k].State == CellState.BusyDeckNearby || enemy.PlayArea.Cells[lineNumber, k].State == CellState.BusyDeck))
        //        {
        //            Console.Write(' ' + "|");
        //            continue;
        //        }
        //        Console.Write(ConsoleCellState.ToString(enemy.PlayArea.Cells[lineNumber, k]) + "|");
        //    }
        //}
    }



}
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