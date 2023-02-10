using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.DataManagement.Converters;
using SeaBattle.DataManagement.Models;

namespace SeaBattle.DataManagement.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly SeabattleContext _context;

        public PlayerRepository(SeabattleContext context)
        {
            _context = context;
        }

        public void Create(PlayerRegistrationModel playerRegistrationModel)
        {
            _context.Players.Add(PlayerRegistrationModelConverter.ToPlayerDto(playerRegistrationModel));
            _context.SaveChanges();
        }
    }
}