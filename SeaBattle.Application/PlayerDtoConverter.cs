using SeaBattle.infrastructure.Models;
using SeaBattleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application
{
    public static class PlayerDtoConverter
    {
        public static PlayerModel ConvertToPlayerModel(this PlayerDto playerDto)
        {
            return new PlayerModel() { Name = playerDto.Name };
        }

        public static List<PlayerModel> ConvertToListPlayerModel(this List<PlayerDto> listPlayerDto)
        {
            var listPM = listPlayerDto
                .Select(x => new PlayerModel() { Name = x.Name })
                .ToList();
            return listPM;
        }
    }
}
