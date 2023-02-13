
namespace SeaBattle
{
    public static class CellStateConverter
    {
        public static string ToStringForInfoWithoutBusyDeckNear(this CellState cell)
        {
            switch (cell)
            {
                case CellState.Empty:
                    return " ";
                case CellState.BusyDeck:
                    return "#";
                case CellState.BusyDeckNearby:
                    return " ";
                case CellState.HasMiss:
                    return "*";
                case CellState.HasHit:
                    return "x";
                default: return " ";
            }
        }

        public static string ToStringWithAllCell(this CellState cell)
        {
            switch (cell)
            {
                case CellState.Empty:
                    return " ";
                case CellState.BusyDeck:
                    return "#";
                case CellState.BusyDeckNearby:
                    return "-";
                case CellState.HasMiss:
                    return "*";
                case CellState.HasHit:
                    return "x";
                default: return " ";
            }
        }
    }
}
