using SeaBattleApi.Models.Interfaces;

namespace SeaBattleApi.Models
{
    public class SeaBattleGameSession : ISeaBattleGameSession
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public bool IsStarted { get; set; }
        public PlayerClient PlayerHost { get; set; }
        public PlayerClient PlayerJoin { get; set; }
    }
}
