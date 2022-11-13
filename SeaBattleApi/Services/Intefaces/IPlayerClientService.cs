using System;
using SeaBattleApi.Models;
using SeaBattleApi.Models.Interfaces;

namespace SeaBattleApi.Services.Intefaces
{
    public interface IPlayerClientService
    {
        void Add(string name);
        PlayerClient GetById(string id);
        PlayerClient GetByName(string name);
        List<PlayerClient> GetAll();
    }
}
