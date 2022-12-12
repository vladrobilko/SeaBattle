using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;

namespace SeaBattle.Application.Converters
{
    public static class NewSessionModelConverter
    {
        public static HostSessionClientModel ConvertToNewSessionClient(this NewSessionModel newSessionModel)
        {
            return new HostSessionClientModel() { HostPlayerName = newSessionModel.HostPlayerName, SessionName = newSessionModel.SessionName };
        }

        public static List<HostSessionClientModel> ConvertToListHostSessionClientModel(this List<NewSessionModel> newSessionClients)
        {
            return newSessionClients
                .Select(ConvertToNewSessionClient)
                .ToList();
        }
    }
}
