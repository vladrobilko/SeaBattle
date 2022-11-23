using SeaBattle.ApiClientModels;
using SeaBattle.infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Converters
{
    public static class JoinToSessionClientConverter
    {
        public static JoinToSessionDtoModel ConvertToJoinToSessionDto(this JoinToSessionClientModel joinToSessionClient)
        {
            return new JoinToSessionDtoModel() { JoinPlayerName = joinToSessionClient.JoinPlayerName, SessionName = joinToSessionClient.SessionName };
        }
    }
}
