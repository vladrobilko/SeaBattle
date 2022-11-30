using SeaBattle.Api.Controllers;
using SeaBattle.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ISeaBattleRepository _db;

        public PlayerService(ISeaBattleRepository seaBattleRepository)
        {
            _db = seaBattleRepository;
        }

        public void CreateNewPlayer(string name)
        {
            _db.AddNewPlayerOrThrowExeption(name);
        }
    }
}