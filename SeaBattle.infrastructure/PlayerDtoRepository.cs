using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.infrastructure.Interfaces;
using SeaBattle.infrastructure.Models;

namespace SeaBattle.infrastructure
{
    public class PlayerDtoRepository : IPlayerDtoRepository
    {
        private readonly List<PlayerDto> _players;

        public PlayerDtoRepository()
        {
            _players = new List<PlayerDto>();
        }

        public void Create(string name)
        {
            var player = new PlayerDto() { Name = name };
            _players.Add(player);
        }
        public PlayerDto Get(string name)
        {
            return _players.SingleOrDefault(p => p.Name == name);
        }

        public List<PlayerDto> GetAll()
        {
            return _players;
        }
    }
}
