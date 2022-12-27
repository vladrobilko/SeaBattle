using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Converters
{
    public static class ShootPlayerClientModelConverter
    {
        public static ShootModel ConvertToShootModel(this ShootPlayerClientModel shootPlayerClientModel)
        {
            return new ShootModel(
                shootPlayerClientModel.ShootCoordinateY, shootPlayerClientModel.ShootCoordinateX,
                shootPlayerClientModel.PlayerName, shootPlayerClientModel.NameSession);
        }
    }
}
