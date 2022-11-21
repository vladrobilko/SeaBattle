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
        public static PlayerClient ConvertToPlayerClient(this PlayerModel playerClient)
        {
            return new PlayerClient() { Name = playerClient.Name };
        }
    }
}
