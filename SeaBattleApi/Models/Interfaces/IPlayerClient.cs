using SeaBattle;

namespace SeaBattleApi.Models.Interfaces
{
    public interface IPlayerClient : IPlayer
    {
        public string ID { get; set; }
        public string TimeAdding { get; set; }
    }
}
