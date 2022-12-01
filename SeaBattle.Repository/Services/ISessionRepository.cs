using SeaBattle.Repository.Models;

namespace SeaBattle.Repository.Services
{
    public interface ISessionRepository
    {
        void AddNewSessionOrThrowExeption(string hostPlayerName, string sessionName);

        void AddToStartsSessionsOrThrowExeption(string joinPlayerName, string sessionName);

        List<SessionDtoModel> GetAllFreeSessions();

        //StartGame или игра сессия будет содержать игру
        //нужна проверка есть ли такая сессия 
    }
}