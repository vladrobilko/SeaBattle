using SeaBattle.ApiClientModels.Models;

namespace SeaBattle.Application.Services.Interfaces
{
    public interface IPlayerService
    {
        void CreatePlayer(PlayerRegistrationClientModel playerRegistrationClientModel);
    }
}