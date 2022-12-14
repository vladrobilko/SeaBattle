using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Converters
{
    public static class PlayAreaConverter
    {
        public static string[][] ConvertToArrayStringForClient(this PlayArea playArea)
        {
            string[][] playAreaString = new string[playArea.Height][];

            for (int i = 0; i < playArea.Height; i++)
            {
                playAreaString[i] = new string[playArea.Width];
                for (int j = 0; j < playArea.Width; j++)
                {
                    playAreaString[i][j] = playArea.Cells[i,j].State.ToStringForInfo();
                }
            }

            return playAreaString;
        }

        public static string[][] ConvertToArrayStringForClientEnemyPlayArea(this PlayArea playArea)
        {
            string[][] playAreaString = new string[playArea.Height][];

            for (int i = 0; i < playArea.Height; i++)
            {
                playAreaString[i] = new string[playArea.Width];
                for (int j = 0; j < playArea.Width; j++)
                {
                    if (playArea.Cells[i, j].State == CellState.BusyDeckNearby || playArea.Cells[i, j].State == CellState.BusyDeck)
                    {
                        playAreaString[i][j] = " ";
                        continue;                   
                    }
                    playAreaString[i][j] = playArea.Cells[i, j].State.ToStringForInfo();
                }
            }

            return playAreaString;
        }
    }
}
