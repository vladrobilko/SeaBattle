using SeaBattle.Application.Models;
using SeaBattle.Repository.Models;

namespace SeaBattle.Repository.Converters
{
    public static class HostSessionModelConverter
    {
        public static HostSessionDtoModel ConvertToHostSessionDtoModel(this HostSessionModel hostSessionModel)
        {
            return new HostSessionDtoModel()
            {
                NameHostPlayer = hostSessionModel.NameHostPlayer,
                NameSession = hostSessionModel.NameSession
            };
        }
    }
}
