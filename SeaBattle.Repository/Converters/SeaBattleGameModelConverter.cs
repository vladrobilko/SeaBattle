using SeaBattle.Application.Models;
using SeaBattle.Repository.Models;

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
