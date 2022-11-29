
using SeaBattle.Repository.Models;

namespace SeaBattle.Repository
{
    public interface ISeaBattleRepository
    {
        void AddNewPlayer(string name);

        PlayerDtoModel GetPlayer(string playerName);

        void AddNewSession(string hostPlayerName, string sessionName);

        void AddToStartsSessionsOrThrowExeption(string joinPlayerName, string sessionName);

        List<SessionDtoModel> GetAllFreeSessions();

        SessionDtoModel GetFreeSession(string sessionName);

        //StartGame или игра сессия будет содержать игру
        //нужна проверка есть ли такая сессия 
    }
}