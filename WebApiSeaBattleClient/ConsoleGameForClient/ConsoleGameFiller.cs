using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFillerForClient
{
    public class ConsoleGameFiller
    {
        public static void FillConsolePlayerAreaAndEnemyArea(string[][] playArea1, string[][] playArea2)
        {
            FillFirstLineWithSignaturesFor2Players(playArea1.Length);
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < playArea1.Length; i++)
            {
                Console.Write(i + "|");
                FillLine(playArea1, i);
                Console.Write("|" + i + "|");
                FillLine(playArea2, i);
                Console.SetCursorPosition(0, i + 2);
            }
        }

        public static void FillConsolePlayerAreaOnly(string[][] playArea)
        {
            FillFirstLineWithSignaturesFor1Player(playArea.Length);
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < playArea.Length; i++)
            {
                Console.Write(i + "|");
                FillLine(playArea, i);
                Console.SetCursorPosition(0, i + 2);
            }
        }

        private static void FillFirstLineWithSignaturesFor2Players(int lenght)
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

        private static void FillFirstLineWithSignaturesFor1Player(int lenght)
        {
            Console.SetCursorPosition(2, 0);
            for (int i = 0; i < lenght; i++)
            {
                Console.SetCursorPosition(2 + i * 2, 0);
                Console.Write(i + "|");
            }
        }

        private static void FillLine(string[][] playArea, int lineNumber)
        {
            for (int i = 0; i < playArea.Length; i++)
            {
                Console.Write(playArea[lineNumber][i] + "|");
            }
        }

    }
}
