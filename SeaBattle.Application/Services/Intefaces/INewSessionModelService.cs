using SeaBattle.ApiClientModels;
using SeaBattleApi.Models;

namespace SeaBattle.Application.Services.Intefaces
{
    public interface INewSessionModelService
    {
        void NewSession(NewSessionClient newSessionClient);

        NewSessionModel GetSession(string idSession);

        List<NewSessionModel> GetAll();
    }
}