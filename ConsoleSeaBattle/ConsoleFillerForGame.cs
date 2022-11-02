using System;
using SeaBattle;

namespace ConsoleSeaBattle
{

    public class ConsoleFillerForGame
    {

        public static void FillConsole(IPlayer player, IPlayer enemy)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            FillFirstLineWithSignatures(player.GetPlayArea().Cells.GetLength(0));
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < player.GetPlayArea().Cells.GetLength(0); i++)
            {
                Console.Write(i + "|");
                FillPlayerWithVisibleShips(player, i);
                Console.Write("|" + i + "|");
                FillEnemyWithInvisibleShips(enemy, i);
                Console.SetCursorPosition(0, i + 2);
            }
            Console.ResetColor();
        }

        private static void FillFirstLineWithSignatures(int lenght)
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

        private static void FillPlayerWithVisibleShips(IPlayer player, int lineNumber)
        {
            for (int i = 0; i < player.GetPlayArea().Cells.GetLength(1); i++)
            {
                if (player.GetPlayArea().Cells[lineNumber, i].State == CellState.BusyDeckNearby)
                {
                    Console.Write(' ' + "|");
                    continue;
                }
                Console.Write(CellStateConsole.ToString(player.GetPlayArea().Cells[lineNumber, i]) + "|");
            }
        }

        static void FillEnemyWithInvisibleShips(IPlayer enemy, int lineNumber)
        {
            for (int k = 0; k < enemy.GetPlayArea().Cells.GetLength(1); k++)
            {
                if ((enemy.GetPlayArea().Cells[lineNumber, k].State == CellState.BusyDeckNearby || enemy.GetPlayArea().Cells[lineNumber, k].State == CellState.BusyDeck))
                {
                    Console.Write(' ' + "|");
                    continue;
                }
                //enemy.GetPlayArea().Cells[lineNumber, k].ToString2();
                Console.Write(CellStateConsole.ToString(enemy.GetPlayArea().Cells[lineNumber, k]) + "|");
            }
        }
    }
}