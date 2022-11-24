using SeaBattle.ApiClientModels;
using SeaBattle.Repository.Models;
using SeaBattleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Converters
{
    public static class NewSessionClientConverter
    {
        public static NewSessionModel ConvertToNewSessionModel(this NewSessionClientModel newSessionClient)
        {           
            return new NewSessionModel { HostPlayerName = newSessionClient.HostPlayerName, SessionName = newSessionClient.SessionName};
        }

        public static NewSessionDtoModel ConvertToNewSessionDto(this NewSessionClientModel newSessionClient)
        {
            return new NewSessionDtoModel { HostPlayerName = newSessionClient.HostPlayerName, SessionName = newSessionClient.SessionName };
        }
    }
}
