using NUnit.Framework;
using SeaBattle;
using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Converters;
using SeaBattleApi.Models;

namespace TestSeaBattleGameService
{
    public class TestGetPlayArea
    {
        [Test]
        [Repeat(100)]
        public void TestGetPlayArea_GetPlayAreaInClientModel_ReturnNotNull()
        {
            //pre
            var client = new InfoPlayerClientModel() { PlayerName = "123", SessionName = "123" };
            var playerModel = new PlayerModel(new FillerRandom(), client.PlayerName);
            var result = new string[10][];
            //act
            playerModel.FillShips();
            result = playerModel.GetPlayArea().ConvertToArrayString();
            //assert
            foreach (var item in result)
            {
                Assert.NotNull(item);
            }
        }
    }
}