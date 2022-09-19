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

        public Cell[,] Cells { get; set; }        

        public PlayArea(int height = 10, int width = 10)
        {
            this.Height = height;
            this.Width = width;
            this.Cells = new Cell[height, width];
            FillArrayWithCell(height, width);
        }

        public PlayArea(PlayArea playArea)
        {
            Height = playArea.Height;
            Width = playArea.Width;
            Cells = playArea.Cells;
        }

        private void FillArrayWithCell(int height, int width)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Cells[i, j] = new Cell(i, j);
                }
            }
        }
    }




}
