using SeaBattle.ApiClientModels;
using SeaBattle.Application.Converters;
using SeaBattle.Application.Services.Intefaces;
using SeaBattle.infrastructure.Interfaces;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services
{
    public class NewSessionModelService : INewSessionModelService
    {
        INewSessionDtoRepository _db;

        public NewSessionModelService(INewSessionDtoRepository newSessionDtoRepository)
        {
            _db = newSessionDtoRepository;
        }

        public void NewSession(NewSessionClient newSessionClient)
        {
            _db.Create(newSessionClient.ConvertToNewSessionDto());
        }

        public NewSessionModel GetSession(string sessionName)
        {
            return _db
                .Get(sessionName)
                .ConvertToSessionModel();
        }

        public List<NewSessionModel> GetAll()
        {
            return _db.GetAll().ConvertToListSessionModel();
        }
    }
}
