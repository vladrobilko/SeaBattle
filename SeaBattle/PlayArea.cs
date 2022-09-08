using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace SeaBattle
{
    public class PlayArea
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public Cell[,] cells;//нужно это поле сдлеать приват, но оно много где используется

        public PlayArea(int height, int width, List<IShipsFiller> fillShips)
        {
            this.Height = height;
            this.Width = width;
            this.cells = new Cell[height, width];
            FillArrayWithCell(height, width);
            foreach (var item in fillShips)
            {
                item.FillShips(cells);
            }            
        }

        private void FillArrayWithCell(int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells[i, j] = new Cell();
                }
            }
        }

    }


}
