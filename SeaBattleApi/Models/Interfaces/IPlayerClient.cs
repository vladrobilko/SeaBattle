using SeaBattle;

namespace SeaBattleApi.Models.Interfaces
{
    public interface IPlayerClient : IPlayer
    {
        public string ID { get; }
        public string TimeAdding { get; }
    }
}
