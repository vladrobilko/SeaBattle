using Newtonsoft.Json;

namespace SeaBattle.DataManagement.Converters
{
    public static class ShipConverter
    {
        public static string ConvertToJson(this List<Cell> cells)
        {
            var listCellJson = new List<CellJson>();
            foreach (var cell in cells)
            {
                if (cell != null)
                {
                    listCellJson.Add(new CellJson() { IsDead = false, Y = cell.Point.Y, X = cell.Point.X });
                }
                else
                {
                    listCellJson.Add(new CellJson() { IsDead = true });
                }
            }

            return JsonConvert.SerializeObject(listCellJson);
        }
    }
}
