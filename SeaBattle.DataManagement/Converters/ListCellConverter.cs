using Newtonsoft.Json;

namespace SeaBattle.DataManagement.Converters
{
    public static class ShipConverter
    {
        public static string ToJson(this List<Cell?> cells)
        {
            return JsonConvert.SerializeObject(cells
                .Where(c => c != null)
                .Select(c => new CellDto()
                {
                    IsDead = false,
                    Y = c!.Point.Y,
                    X = c.Point.X
                })
                .ToList());
        }
    }
}
