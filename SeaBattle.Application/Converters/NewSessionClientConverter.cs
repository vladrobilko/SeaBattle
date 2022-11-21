using SeaBattle.ApiClientModels;
using SeaBattle.infrastructure.Models;
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
        public static NewSessionModel ConvertToNewSessionModel(this NewSessionClient newSessionClient)
        {           
            return new NewSessionModel { HostPlayerName = newSessionClient.HostPlayerName, SessionName = newSessionClient.SessionName};
        }

        public static NewSessionDto ConvertToNewSessionDto(this NewSessionClient newSessionClient)
        {
            return new NewSessionDto { HostPlayerName = newSessionClient.HostPlayerName, SessionName = newSessionClient.SessionName };
        }
    }
}
