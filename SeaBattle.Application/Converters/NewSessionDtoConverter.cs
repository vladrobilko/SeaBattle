using SeaBattle.infrastructure.Models;
using SeaBattleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SeaBattle.Application.Converters
{
    public static class NewSessionDtoConverter
    {
        public static NewSessionModel ConvertToSessionModel(this NewSessionDto newSessionDto)
        {
            return new NewSessionModel() { HostPlayerName = newSessionDto.HostPlayerName, SessionName = newSessionDto.SessionName };
        }

        public static List<NewSessionModel> ConvertToListSessionModel(this List<NewSessionDto> newSessionDto)
        {
            return newSessionDto
                .Select(ConvertToSessionModel)
                .ToList();
        }
    }
}
