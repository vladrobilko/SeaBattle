﻿using SeaBattle.ApiClientModels;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Services.Intefaces;
using SeaBattle.infrastructure;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services
{
    public class SessionService : ISessionService
    {
        ISessionRepository _db;

        public SessionService(ISessionRepository newSessionDtoRepository)
        {
            _db = newSessionDtoRepository;
        }
        public void CreateNewPlayer(string name)
        {
            _db.AddNewPlayer(name);
        }

        public void CreateNewSession(NewSessionClient newSessionClient)
        {
            _db.AddNewSession(newSessionClient.ConvertToNewSessionDto());
        }

        public List<NewSessionModel> GetAllNewSessions()
        {
            return _db.
                GetAllFreeSessions().
                ConvertToListSessionModel();
        }

        public bool IsJoinToSession(JoinToSessionClient joinSessionClient)
        {
            if (_db.GetFreeSession(joinSessionClient.SessionName) != null)
            {
                _db.AddToStartsSessions(joinSessionClient.ConvertToJoinToSessionDto());
                return true;
            }
            return false;
        }
    }
}