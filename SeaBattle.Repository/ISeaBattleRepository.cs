
using SeaBattle.Repository.Models;

namespace SeaBattle.Repository
{
    public interface ISeaBattleRepository
    {
        void AddNewPlayerOrThrowExeption(string name);

        void AddNewSessionOrThrowExeption(string hostPlayerName, string sessionName);

        void AddToStartsSessionsOrThrowExeption(string joinPlayerName, string sessionName);

        List<SessionDtoModel> GetAllFreeSessions();

        //StartGame или игра сессия будет содержать игру
        //нужна проверка есть ли такая сессия 
    }
}