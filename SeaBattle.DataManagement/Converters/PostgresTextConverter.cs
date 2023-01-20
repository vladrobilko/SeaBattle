using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.DataManagement.Converters
{
    public static class PostgresTextConverter
    {
        public static PlayArea ConvertToPlayArea(this string playAreaFromPostgers)
        {
            var playArea = new PlayArea();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    playArea.Cells[i, j].State = playAreaFromPostgers[(i * 10) + j].ConvertStringToCellState();
                }
            }

            return playArea;
        }

        private static CellState ConvertStringToCellState(this char cell)
        {
            switch (cell)
            {
                case ' ':
                    return CellState.Empty;
                case '#':
                    return CellState.BusyDeck;
                case '-':
                    return CellState.BusyDeckNearby;
                case '*':
                    return CellState.HasMiss;
                case 'x':
                    return CellState.HasHit;
                default: return CellState.Empty;
            }

        }
    }
}
