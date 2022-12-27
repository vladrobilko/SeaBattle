﻿using SeaBattle.Application.Models;
using SeaBattle.Repository.Models;

namespace SeaBattle.Application.Converters
{
    public static class NewSessionDtoConverter
    {
        public static HostSessionModel ConvertToNewSessionModel(this SessionDtoModel newSessionDto)
        {
            return new HostSessionModel() { HostPlayerName = newSessionDto.HostPlayerName, SessionName = newSessionDto.SessionName };
        }

        public static List<HostSessionModel> ConvertToListSessionModel(this List<SessionDtoModel> newSessionDto)
        {
            return newSessionDto
                .Select(ConvertToNewSessionModel)
                .ToList();
        }

        public static SessionModel ConvertToSessionModel(this SessionDtoModel SessionDto)
        {
            return new SessionModel()
            {
                HostPlayerName = SessionDto.HostPlayerName,
                JoinPlayerName = SessionDto.JoinPlayerName,
                SessionName = SessionDto.SessionName
            };
        }
    }
}
