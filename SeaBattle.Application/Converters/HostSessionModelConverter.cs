using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;

namespace SeaBattle.Application.Converters
{
    public static class HostSessionModelConverter
    {
        public static List<HostSessionClientModel> ToHostSessionClientModels(this List<HostSessionModel> newSessionClients)
        {
            return newSessionClients
                .Select(p => new HostSessionClientModel()
                {
                    HostPlayerName = p.NameHostPlayer,
                    SessionName = p.NameSession
                })
                .ToList();
        }
    }
}
