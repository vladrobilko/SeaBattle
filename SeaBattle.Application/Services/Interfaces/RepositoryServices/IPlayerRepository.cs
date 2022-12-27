using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface IPlayerRepository
    {
        void SaveNewPlayerOrThrowExeption(PlayerRegistrationModel playerRegistrationModel);

        bool IsPlayerRegistered(string name);
    }
}