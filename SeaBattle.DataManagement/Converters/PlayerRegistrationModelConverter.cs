using SeaBattle.Application.Models;
using SeaBattle.DataManagement.Models;

namespace SeaBattle.DataManagement.Converters
{
    public static class PlayerRegistrationModelConverter
    {
        public static PlayerDto ConvertToPlayer(this PlayerRegistrationModel playerRegistrationModel)
        {
            return new PlayerDto() { Name = playerRegistrationModel.NamePlayer };
        }
    }
}
