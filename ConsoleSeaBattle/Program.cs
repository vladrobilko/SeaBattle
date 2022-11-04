using System;
using System.Collections.Generic;
using SeaBattle;
using System.Linq;

namespace ConsoleSeaBattle
{
    partial class Program
    {
        
        static void Main(string[] args)
        {

            var PlayerVsBot = new SeaBattleGameConsole(new PlayerConsole(new FillerRandom()), new PlayerEasyBot(new FillerRandom()));
            Console.WriteLine(PlayerVsBot.Start());

            //Linq

            //IEnumerable
            // [] List 

            //Enumerable.Range(1, 10);
            //Enumerable.Repeat(100, 5);

            //var array = new int[] { 1, 6, 1 , 19, -1 , -2, 2, 3, 5 };
            //array.Contains(1);
            
            //array.Any(x => x == 1);
            //array.Any(x => x == 11);
            ////array.ForEach(x => todo());
            //var newArray = array.Skip(3).Take(2).ToArray();
            

            //var array2 = array.Where(x => x > 0).Select(elem => elem.ToString()).ToArray();
            

            ////foreach (string arg in args)




            ////seaBattlePlayerVsBot.OnPlayerHit += OnPlayerHit1;
            ////seaBattlePlayerVsBot.OnPlayerHit += OnPlayerHit2;

            ////seaBattlePlayerVsBot.onPlayerHit2 += OnPlayerHit1;
            ////seaBattlePlayerVsBot.OnPlayerHit2 += OnPlayerHit2;
            ////seaBattlePlayerVsBot.OnPlayerHit2.Invoke();
            //List<int> list = new List<int>();

            //Foo<string>();
            
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