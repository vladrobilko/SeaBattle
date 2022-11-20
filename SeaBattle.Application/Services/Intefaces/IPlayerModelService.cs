using System;
using SeaBattleApi.Models;

namespace SeaBattleApi.Services.Intefaces
{
    public interface IPlayerModelService
    {
        void Create(string name);

        PlayerModel Get(string name);

        List<PlayerModel> GetAll();
    }
}
