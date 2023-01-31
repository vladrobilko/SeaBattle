using Newtonsoft.Json;

namespace SeaBattle.DataManagement.Converters
{
    public static class ShipConverter
    {
        public static string ToJson(this List<Cell> cells)
        {
            var listCellJson = new List<CellDto>();
            foreach (var cell in cells)
            {
                if (cell != null)
                {
                    listCellJson.Add(new CellDto() { IsDead = false, Y = cell.Point.Y, X = cell.Point.X });
                }
                else
                {
                    listCellJson.Add(new CellDto() { IsDead = true });
                }
            }

            return JsonConvert.SerializeObject(listCellJson);
        }
    }
}
