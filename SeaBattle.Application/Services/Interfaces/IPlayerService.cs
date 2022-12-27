using SeaBattle.ApiClientModels.Models;

namespace SeaBattle.Api.Controllers
{
    public interface IPlayerService
    {
        void CreateNewPlayer(PlayerRegistrationClientModel playerRegistrationClientModel);
    }
}