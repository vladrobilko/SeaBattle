namespace ConsoleGameForClient
{
    public class ConsoleGameFiller
    {
        public static void FillConsolePlayerAreaAndEnemyArea(string[][]? playAreaPlayer, string[][]? playAreaEnemy)
        {
            FillFirstLineWithSignatures(playAreaPlayer!.Length);

            Console.SetCursorPosition(0, 1);

            for (var i = 0; i < playAreaPlayer.Length; i++)
            {
                Console.Write(i + "|");
                FillHorizontalLine(playAreaPlayer, i);

                Console.Write("|" + i + "|");
                FillHorizontalLine(playAreaEnemy, i);

                Console.SetCursorPosition(0, i + 2);
            }
        }

        public static void FillConsolePlayerAreaOnly(string[][]? playArea)
        {
            FillFirstLineWithSignaturesForOnePlayer(playArea?.Length);

            Console.SetCursorPosition(0, 1);

            for (var i = 0; i < playArea?.Length; i++)
            {
                Console.Write(i + "|");
                FillHorizontalLine(playArea, i);

                Console.SetCursorPosition(0, i + 2);
            }
        }

        private static void FillFirstLineWithSignatures(int length)
        {
            Console.SetCursorPosition(2, 0);

            for (var i = 0; i < length; i++)
            {
                Console.SetCursorPosition(2 + i * 2, 0);
                Console.Write(i + "|");

                Console.SetCursorPosition((2 * length) + i * 2 + 5, 0);
                Console.Write(i + "|");
            }
        }

        private static void FillFirstLineWithSignaturesForOnePlayer(int? length)
        {
            Console.SetCursorPosition(2, 0);

            for (var i = 0; i < length; i++)
            {
                Console.SetCursorPosition(2 + i * 2, 0);
                Console.Write(i + "|");
            }
        }

        private static void FillHorizontalLine(string[][]? playArea, int lineNumber)
        {
            for (var i = 0; i < playArea?.Length; i++)
            {
                Console.Write(playArea?[lineNumber][i] + "|");
            }
        }

    }
}
