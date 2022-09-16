using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle;

namespace ConsoleSeaBattle
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var player = new ConsolePlayer(new RandomFiller());
            var bot = new EasyBotPlayer(new RandomFiller());
            SeaBattleGame seaBattlePlayerVsBot = new SeaBattleGame(player, bot); 
            Console.WriteLine(seaBattlePlayerVsBot.Start());
            //ConsoleFillerForGame.FillConsole(player, bot);

            //seaBattlePlayerVsBot.OnPlayerHit += OnPlayerHit1;
            //seaBattlePlayerVsBot.OnPlayerHit += OnPlayerHit2;

            //seaBattlePlayerVsBot.onPlayerHit2 += OnPlayerHit1;
            //seaBattlePlayerVsBot.OnPlayerHit2 += OnPlayerHit2;
            //seaBattlePlayerVsBot.OnPlayerHit2.Invoke();


        }

        public static void OnPlayerHit1(string palyerName)
        {
            
        }

        public static void OnPlayerHit2(string palyerName)
        {

        }
    }
}