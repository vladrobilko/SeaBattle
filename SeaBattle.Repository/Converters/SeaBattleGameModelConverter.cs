using SeaBattle.Application.Models;
using SeaBattle.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Repository.Converters
{
    public static class SeaBattleGameModelConverter
    {
        public static SeaBattleGameDtoModel ConvertToSeaBattleGameDtoModel(this SeaBattleGameModel model)
        {
            //logic
            return new SeaBattleGameDtoModel();
        }
    }
}
