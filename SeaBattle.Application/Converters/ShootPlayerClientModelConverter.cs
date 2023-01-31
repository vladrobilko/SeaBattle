using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;

namespace SeaBattle.Application.Converters
{
    public static class ShootPlayerClientModelConverter
    {
        public static ShootModel ToShootModel(this ShootClientModel shootPlayerClientModel)
        {
            return new ShootModel(
                shootPlayerClientModel.ShootCoordinateY,
                shootPlayerClientModel.ShootCoordinateX,
                shootPlayerClientModel.PlayerName, 
                shootPlayerClientModel.NameSession);
        }
    }
}
