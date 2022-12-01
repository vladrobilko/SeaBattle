namespace SeaBattle.Repository.Services
{
    public interface IPlayerRepository
    {
        void AddNewPlayerOrThrowExeption(string name);
    }
}