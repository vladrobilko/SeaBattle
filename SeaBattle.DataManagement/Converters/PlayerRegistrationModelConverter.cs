using SeaBattle.Application.Models;
using SeaBattle.DataManagement.Models;

namespace SeaBattle.DataManagement.Converters
{
    public static class PlayerRegistrationModelConverter
    {
        public static Player ConvertToPlayer(this PlayerRegistrationModel playerRegistrationModel)
        {
            return new Player() { Name = playerRegistrationModel.NamePlayer };
        }
    }
}
