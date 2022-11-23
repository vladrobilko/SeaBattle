using SeaBattle.ApiClientModels;
using SeaBattleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Converters
{
    public static class PlayerModelConverter
    {
        public static PlayerClientModel ConvertToPlayerClient(this PlayerModel playerClient)
        {
            return new PlayerClientModel() { Name = playerClient.Name };
        }
    }
}
