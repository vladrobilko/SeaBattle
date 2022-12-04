using System;
using SeaBattle;

namespace ConsoleSeaBattle
{
    partial class Program
    {        
        static void Main(string[] args)
        {
            var PlayerVsBot = new SeaBattleGameConsole(new PlayerConsole(new FillerRandom()), new PlayerEasyBot(new FillerRandom()));
            Console.WriteLine(PlayerVsBot.Start());
        }
    }
}