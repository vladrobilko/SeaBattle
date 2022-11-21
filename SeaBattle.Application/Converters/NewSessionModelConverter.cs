using SeaBattle.ApiClientModels;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Converters
{
    public static class NewSessionModelConverter
    {
        public static NewSessionClient ConvertToNewSessionClient(this NewSessionModel newSessionModel)
        {
            return new NewSessionClient() { HostPlayerName = newSessionModel.HostPlayerName, SessionName = newSessionModel.SessionName };
        }

        public static List<NewSessionClient> ConvertToListNewSessionClient(this List<NewSessionModel> newSessionClients)
        {
            return newSessionClients
                .Select(ConvertToNewSessionClient)
                .ToList();
        }
    }
}
