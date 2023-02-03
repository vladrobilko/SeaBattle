using SeaBattle.ApiClientModels.Models;

namespace SeaBattle.Api.Controllers
{
    public interface IPlayerService
    {
        void CreatePlayer(PlayerRegistrationClientModel playerRegistrationClientModel);
    }
}