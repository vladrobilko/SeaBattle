using SeaBattle.Application.Models;

namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface IPlayerRepository
    {
        void Create(PlayerRegistrationModel playerRegistrationModel);
    }
}