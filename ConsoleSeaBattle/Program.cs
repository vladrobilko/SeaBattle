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
            var PlayerVsBot = new SeaBattleGameConsole(new PlayerConsole(new FillerRandom()), new PlayerEasyBot(new FillerRandom()));
            Console.WriteLine(PlayerVsBot.Start());


            //seaBattlePlayerVsBot.OnPlayerHit += OnPlayerHit1;
            //seaBattlePlayerVsBot.OnPlayerHit += OnPlayerHit2;

            //seaBattlePlayerVsBot.onPlayerHit2 += OnPlayerHit1;
            //seaBattlePlayerVsBot.OnPlayerHit2 += OnPlayerHit2;
            //seaBattlePlayerVsBot.OnPlayerHit2.Invoke();
            List<int> list = new List<int>();

            Foo<string>();
            
        }

        static T Foo<T>()
        {
            return default(T);
        }

        public static void OnPlayerHit1(string palyerName)
        {
            
        }

        public static void OnPlayerHit2(string palyerName)
        {

        }
    }
}