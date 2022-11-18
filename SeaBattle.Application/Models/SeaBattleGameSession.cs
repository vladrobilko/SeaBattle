
namespace SeaBattleApi.Models
{
    public class SeaBattleGameSession
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public bool IsStarted { get; set; }
        public PlayerClientModel PlayerHost { get; set; }
        public PlayerClientModel PlayerJoin { get; set; }
    }
}
