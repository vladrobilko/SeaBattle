using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;

namespace SeaBattle.Application.Converters
{
    public static class PlayerRegistrationClientModelConverter
    {
        public static PlayerRegistrationModel ConvertToPlayerRegistrationModel(this PlayerRegistrationClientModel playerRegistrationClientModel)
        {
            return new PlayerRegistrationModel()
            { 
                NamePlayer = playerRegistrationClientModel.NamePlayer 
            };
        }
    }
}
