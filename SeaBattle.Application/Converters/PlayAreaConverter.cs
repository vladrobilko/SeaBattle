namespace SeaBattle.Application.Converters
{
    public static class PlayAreaConverter
    {
        public static string[][] ToStringsForClient(this PlayArea playArea)
        {
            var playAreaString = new string[playArea.Height][];

            for (var i = 0; i < playArea.Height; i++)
            {
                playAreaString[i] = new string[playArea.Width];
                for (var j = 0; j < playArea.Width; j++)
                {
                    playAreaString[i][j] = playArea.Cells[i,j].State.ToStringForInfoWithoutBusyDeckNear();
                }
            }

            return playAreaString;
        }

        public static string[][] ToStringsForClientEnemyPlayArea(this PlayArea playArea)
        {
            var playAreaString = new string[playArea.Height][];

            for (var i = 0; i < playArea.Height; i++)
            {
                playAreaString[i] = new string[playArea.Width];
                for (var j = 0; j < playArea.Width; j++)
                {
                    if (playArea.Cells[i, j].State == CellState.BusyDeckNearby || playArea.Cells[i, j].State == CellState.BusyDeck)
                    {
                        playAreaString[i][j] = " ";
                        continue;                   
                    }
                    playAreaString[i][j] = playArea.Cells[i, j].State.ToStringForInfoWithoutBusyDeckNear();
                }
            }

            return playAreaString;
        }

        public static string ToString(this PlayArea playArea)
        {
            return string.Join("", playArea.Select(p => p.State.ToStringWithAllCell()));
        }
    }
}
