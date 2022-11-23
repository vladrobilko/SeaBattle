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
        public static JoinToSessionDto ConvertToJoinToSessionDto(this JoinToSessionClient joinToSessionClient)
        {
            return new JoinToSessionDto() { JoinPlayerName = joinToSessionClient.JoinPlayerName, SessionName = joinToSessionClient.SessionName };
        }
    }
}
