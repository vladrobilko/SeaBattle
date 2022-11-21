using SeaBattle.infrastructure.Models;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Converters
{
    public static class PlayerDtoConverter
    {
        public static PlayerModel ConvertToPlayerModel(this PlayerDto playerDto)
        {
            return new PlayerModel() { Name = playerDto.Name };
        }

        public static List<PlayerModel> ConvertToListPlayerModel(this List<PlayerDto> listPlayerDto)
        {
            return listPlayerDto
                .Select(x => new PlayerModel() { Name = x.Name })
                .ToList();
        }
    }
}
