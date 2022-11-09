using System;
using SeaBattleApi.Models.Interfaces;

namespace SeaBattleApi.Services.Intefaces
{
    public interface IPlayerClientService
    {
        void Add(string name);
        IPlayerClient GetById(string id);
        List<IPlayerClient> GetAll();
    }
}
