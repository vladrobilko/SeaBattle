using SeaBattle.Application.Models;
using SeaBattle.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Repository.Converters
{
    public static class StartSessionDtoModelConverter
    {
        public static StartSessionModel ConvertToStartSessionModel(this StartSessionDtoModel startSessionDtoModel)
        {
            return new StartSessionModel() { NameHostPlayer = startSessionDtoModel.NameHostPlayer, NameJoinPlayer = startSessionDtoModel.NameJoinPlayer, NameSession = startSessionDtoModel.NameSession };
        }
    }
}
