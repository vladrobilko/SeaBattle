using SeaBattle.Application.Models;
using SeaBattle.Repository.Models;

namespace SeaBattle.Application.Converters
{
    public static class HostSessionDtoConverter
    {
        public static HostSessionModel ConvertToHostSessionModel(this HostSessionDtoModel hostSessionDtoModel)
        {
            return new HostSessionModel() { NameHostPlayer = hostSessionDtoModel.NameHostPlayer, NameSession = hostSessionDtoModel.NameSession };
        }

        public static List<HostSessionModel> ConvertToListHostSessionModel(this List<HostSessionDtoModel> hostSessionDtoModels)
        {
            return hostSessionDtoModels
                .Select(ConvertToHostSessionModel)
                .ToList();
        }
    }
}
