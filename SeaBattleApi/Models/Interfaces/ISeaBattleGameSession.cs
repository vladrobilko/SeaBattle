namespace SeaBattleApi.Models.Interfaces
{
    public interface ISeaBattleGameSession
    {
        string ID { get; }
        string Name { get; set; }
        bool IsStarted { get; set; }
        IPlayerClient PlayerHost { get; set; }
        IPlayerClient PlayerJoin { get; set; }
    }
}
