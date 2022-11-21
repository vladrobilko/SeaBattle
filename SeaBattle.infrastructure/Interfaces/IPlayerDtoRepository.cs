using SeaBattle.infrastructure.Models;

namespace SeaBattle.infrastructure.Interfaces
{
    public interface IPlayerDtoRepository
    {
        void Create(string name);

        List<PlayerDto> GetAll();

        PlayerDto Get(string name);
    }
}