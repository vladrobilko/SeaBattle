using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.DataManagement.Models;
using SeaBattleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.DataManagement.Repositories
{
    public class SeaBattleGameRepositoty : ISeaBattleGameRepository
    {
        private readonly SeabattleContext _context;

        public SeaBattleGameRepositoty(SeabattleContext context)
        {
            _context = context;
        }

        public PlayerSeaBattleStateModel GetConfirmedPlayerStateModelByNameOrNull(string name)
        {
            throw new NotImplementedException();
        }

        public GameState GetGameStateModelByNameSession(string nameSession)
        {
            throw new NotImplementedException();
        }

        public ShootModel GetLastShootModelOrNullByName(string namePlayer)
        {
            throw new NotImplementedException();
        }

        public void ResaveGameStateDtoModel(GameState gameStateModel, string NameSession)
        {
            throw new NotImplementedException();
        }

        public void ResaveValidShoot(ShootModel shootModel)
        {
            throw new NotImplementedException();
        }

        public void SavePlayerStateModelOrResaveToChangePlayArea(PlayerSeaBattleStateModel playerModel)
        {
            throw new NotImplementedException();
        }
    }
}
