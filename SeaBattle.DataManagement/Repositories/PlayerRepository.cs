using SeaBattle.Application.Models;
using SeaBattle.Application.Services.Interfaces.RepositoryServices;
using SeaBattle.DataManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _context.Players.Add(new Player() { Name = playerRegistrationModel.NamePlayer});//тут конвертер должен быть
            _context.SaveChanges();
        }
    }
}
