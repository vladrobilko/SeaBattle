using SeaBattle.infrastructure.Interfaces;
using SeaBattle.infrastructure.Models;

namespace SeaBattle.infrastructure
{
    public class NewSessionDtoRepository : INewSessionDtoRepository
    {
        private readonly List<NewSessionDto> _newsessions;

        public NewSessionDtoRepository()
        {
            _newsessions = new List<NewSessionDto>();
        }

        public void Create(NewSessionDto newSessionDto)
        {
            _newsessions.Add(newSessionDto);
        }

        public NewSessionDto Get(string sessionName)
        {
            return _newsessions.SingleOrDefault(p => p.SessionName == sessionName);
        }

        public List<NewSessionDto> GetAll()
        {
            return _newsessions;
        }
    }
}
