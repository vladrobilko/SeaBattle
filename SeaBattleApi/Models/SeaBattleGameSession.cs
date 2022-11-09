using SeaBattleApi.Models.Interfaces;

namespace SeaBattleApi.Models
{
    public class SeaBattleGameSession : ISeaBattleGameSession
    {
        public string ID { get; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public bool IsStarted { get; set; }
        public IPlayerClient PlayerHost { get; set; }
        public IPlayerClient PlayerJoin { get; set; }
    }
}
