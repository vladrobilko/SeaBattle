using SeaBattle.Application;
using SeaBattle.infrastructure.Interfaces;
using SeaBattle.infrastructure.Models;
using SeaBattleApi.Models;
using SeaBattleApi.Services.Intefaces;
using System.Collections.Generic;

namespace SeaBattleApi.Services
{
    public class PlayerModelService : IPlayerModelService
    {
        IPlayerDtoRepository _db;

        public PlayerModelService(IPlayerDtoRepository db)
        {
            _db = db;
        }

        public void Create(string name)
        {
            _db.Create(name);
        }

        public PlayerModel Get(string name)
        {
            var playerDto = _db.Get(name);
            return playerDto.ConvertToPlayerModel();
        }

        public List<PlayerModel> GetAll()
        {
            var listPlayerDto = _db.GetAll();
            return listPlayerDto.ConvertToListPlayerModel();
        }
    }
}
