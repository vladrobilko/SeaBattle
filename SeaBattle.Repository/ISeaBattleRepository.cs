
using SeaBattle.Repository.Models;

namespace SeaBattle.Repository
{
    public interface ISeaBattleRepository
    {
        void AddNewPlayer(string name);

        PlayerDtoModel GetPlayer(string playerName);

        void AddNewSession(SessionDtoModel newSessionDto);//Create new session

        void AddToStartsSessions(SessionDtoModel newSessionDto);//Join to session

        List<SessionDtoModel> GetAllFreeSessions();

        SessionDtoModel GetFreeSession(string sessionName);

        //StartGame или игра сессия будет содержать игру
    }
}