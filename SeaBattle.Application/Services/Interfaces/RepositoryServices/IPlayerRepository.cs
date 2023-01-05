using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface IPlayerRepository
    {
        void SaveNewPlayer(PlayerRegistrationModel playerRegistrationModel);

        bool IsPlayerRegistered(string name);
    }
}