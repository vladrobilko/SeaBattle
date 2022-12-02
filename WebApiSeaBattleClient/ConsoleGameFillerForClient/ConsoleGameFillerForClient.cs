using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFillerForClient
{
    public class ConsoleGameFillerForClient
    {
        public static void FillConsole(string[,] playArea1, string[,] playArea2)
        {
            Console.Clear();
            FillFirstLineWithSignatures(playArea1.GetLength(0));
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < playArea1.GetLength(0); i++)
            {
                Console.Write(i + "|");
                FillLine(playArea1, i);
                Console.Write("|" + i + "|");
                FillLine(playArea2, i);
                Console.SetCursorPosition(0, i + 2);
            }
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

        private static void FillLine(string[,] playArea, int lineNumber)
        {
            for (int i = 0; i < playArea.GetLength(1); i++)
            {               
                Console.Write(playArea[lineNumber, i] + "|");
            }
        }

    }
}
