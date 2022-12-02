namespace SeaBattle.Application.Services.Interfaces.RepositoryServices
{
    public interface IPlayerRepository
    {
        void AddNewPlayerOrThrowExeption(string name);
    }
}