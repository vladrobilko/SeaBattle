namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface IPlayerRepository
    {
        void SaveNewPlayerOrThrowExeption(string name);

        bool IsPlayerRegistered(string name);
    }
}