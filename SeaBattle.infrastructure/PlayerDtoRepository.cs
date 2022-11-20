using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.infrastructure.Interfaces;
using SeaBattle.infrastructure.Models;

namespace SeaBattle.infrastructure
{
    internal class PlayerDtoRepository : IPlayerDtoRepository
    {
        private readonly List<PlayerDto> _players;

        public void Create(string name)
        {
            var player = new PlayerDto() { Name = name };
            _players.Add(player);
        }

        public PlayerDtoRepository()
        {
            _players = new List<PlayerDto>();
        }

        public List<PlayerDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public PlayerDto Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
