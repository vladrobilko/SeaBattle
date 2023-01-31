using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;

namespace SeaBattle.Application.Converters
{
    public static class JoinSessionClientModelConverter
    {
        public static JoinSessionModel ToJoinSessionModel(this JoinSessionClientModel joinSessionClientModel)
        {
            return new JoinSessionModel()
            { 
                NameJoinPlayer = joinSessionClientModel.NameJoinPlayer,
                NameSession = joinSessionClientModel.NameSession 
            };
        }
    }
}
