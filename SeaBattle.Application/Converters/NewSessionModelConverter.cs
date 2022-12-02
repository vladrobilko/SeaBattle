using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;

namespace SeaBattle.Application.Converters
{
    public static class NewSessionModelConverter
    {
        public static NewSessionClientModel ConvertToNewSessionClient(this NewSessionModel newSessionModel)
        {
            return new NewSessionClientModel() { HostPlayerName = newSessionModel.HostPlayerName, SessionName = newSessionModel.SessionName };
        }

        public static List<NewSessionClientModel> ConvertToListNewSessionClient(this List<NewSessionModel> newSessionClients)
        {
            return newSessionClients
                .Select(ConvertToNewSessionClient)
                .ToList();
        }
    }
}
