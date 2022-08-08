using System;

namespace SeaBattle
{

    public class GameArea10x10
    {
        static Random rnd = new Random();


        public int[][] sqare10x10;//это и метод ниже свойствами сделать, или хз
        public void Area10x10()
        {
            int[][] array = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                array[i] = new int[10];
            }
            this.sqare10x10 = array;
        }

        public int[][] FillGameArea()
        {
            CreateShipLenght4(rnd.Next(9), rnd.Next(9));

            return this.sqare10x10;
        }
        public void CreateShipLenght4(int x, int y)
        {
            try
            {
                Area10x10();
                int a = x;
                int b = y;
                this.sqare10x10[a][b] = 1;
                for (int i = 0; i < 3; i++)
                {
                    ++a;
                    if (a>9||b>9)
                    {
                        break;
                    }
                    this.sqare10x10[a][b] = 1;
                }//mnmnm
            }
            catch (Exception)
            {
                try
                {
                    Area10x10();
                    int c = x;
                    int d = y;
                    this.sqare10x10[c][d] = 1;
                    for (int i = 0; i < 3; i++) this.sqare10x10[c][--d] = 1;

                }
                catch (Exception)
                {
                    try
                    {
                        Area10x10();
                        int f = x;
                        int g = y;
                        this.sqare10x10[f][g] = 1;
                        for (int i = 0; i < 3; i++) this.sqare10x10[f][++g] = 1;

                    }
                    catch (Exception)
                    {
                        Area10x10();
                        this.sqare10x10[x][y] = 1;
                        for (int i = 0; i < 3; i++) this.sqare10x10[--x][y] = 1;

                    }
                }


            }

        }

    }
}
