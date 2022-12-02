﻿using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Intefaces;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;

namespace SeaBattle.Application.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _db;

        public SessionService(ISessionRepository newSessionDtoRepository)
        {
            _db = newSessionDtoRepository;
        }

        public void CreateNewSession(NewSessionClientModel newSessionClient)
        {
            _db.AddNewSessionOrThrowExeption(newSessionClient.HostPlayerName, newSessionClient.SessionName);
        }

        public List<NewSessionModel> GetAllNewSessions()
        {
            return _db.
                GetAllFreeSessions();
        }

        public void JoinToSession(JoinToSessionClientModel joinSessionClient)
        {
            _db.AddToStartsSessionsOrThrowExeption(joinSessionClient.JoinPlayerName, joinSessionClient.SessionName);
        }
    }
}
