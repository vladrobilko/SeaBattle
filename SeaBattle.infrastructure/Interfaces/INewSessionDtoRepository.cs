using SeaBattle.infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.infrastructure.Interfaces
{
    public interface INewSessionDtoRepository
    {
        void Create(NewSessionDto newSessionDto);

        List<NewSessionDto> GetAll();

        NewSessionDto Get(string sessionName);
    }
}
