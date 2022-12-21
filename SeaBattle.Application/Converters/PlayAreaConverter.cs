using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Converters
{
    public static class PlayAreaConverter
    {
        public static string[][] ConvertToArrayString(this PlayArea playArea)
        {
            string[][] arr = new string[playArea.Height][];
            for (int i = 0; i < playArea.Height; i++)
            {
                arr[i] = new string[playArea.Width];
                for (int j = 0; j < playArea.Width; j++)
                {
                    arr[i][j] = playArea.Cells[i,j].State.ToStringForInfo();
                }
            }
            return arr;
        }
    }
}
