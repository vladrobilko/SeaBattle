using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;

namespace SeaBattle.Application.Converters
{
    public static class HostSessionModelConverter
    {
        public static HostSessionClientModel ConvertToNewSessionClient(this HostSessionModel newSessionModel)
        {
            return new HostSessionClientModel() { HostPlayerName = newSessionModel.NameHostPlayer, SessionName = newSessionModel.NameSession };
        }

        public static List<HostSessionClientModel> ConvertToListHostSessionClientModel(this List<HostSessionModel> newSessionClients)
        {
            return newSessionClients
                .Select(ConvertToNewSessionClient)
                .ToList();
        }
    }
}
