namespace SeaBattleApi.Models.Interfaces
{
    public interface ISeaBattleGameSession
    {
        string ID { get; }
        string Name { get; set; }
        bool IsStarted { get; set; }
        PlayerClient PlayerHost { get; set; }
        PlayerClient PlayerJoin { get; set; }
    }
}
