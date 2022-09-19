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
            var PlayerVsBot = new SeaBattleGameConsole(new PlayerConsole(new FillerRandom()),new PlayerEasyBot(new FillerRandom()));
            
            Console.WriteLine(PlayerVsBot.Start());

            // проблемы - не заполняется кораблями единичными



            //var player = new PlayerConsole(new FillerRandom());
            //var bot = new PlayerEasyBot(new FillerRandom());
            //SeaBattleGame seaBattlePlayerVsBot = new SeaBattleGame(player, bot);
            //Console.WriteLine(seaBattlePlayerVsBot.Start());



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