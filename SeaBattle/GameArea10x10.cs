using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{

    public class GameArea10x10
    {
        int[][] sqare10x10;

        static Random rnd = new Random();
        public GameArea10x10()
        {
            int[][] arrrey = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                arrrey[i] = new int[10];
            }
            this.sqare10x10 = arrrey;
        }

        public void FillGameArea()
        {
            int a = rnd.Next(10);
            int b = rnd.Next(10);
            this.sqare10x10[a][b] = 1;
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void CreatShip(int a)
        {

        }


    }
}
