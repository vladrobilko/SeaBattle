using System;
using SeaBattleApi.Models;

namespace SeaBattleApi.Services.Intefaces
{
    public interface IPlayerClientService
    {
        void Add(string name);
        PlayerClientModel GetByName(string name);
        List<PlayerClientModel> GetAll();
    }
}
