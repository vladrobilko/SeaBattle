using SeaBattle.ApiClientModels.Models;
using System.Net.Http.Json;
using Xunit;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace XUnitTests
{
    public class TestSeaBattleGameController
    {
        string pathGetPlayArea = "https://localhost:7109/api/SeaBattleGame/GetPlayArea";
        string pathChangePlayArea = "https://localhost:7109/api/SeaBattleGame/ChangePlayArea";
        string pathReadyToStartGame = "https://localhost:7109/api/SeaBattleGame/ReadyToStartGame";
        string pathGetGameModel = "https://localhost:7109/api/SeaBattleGame/GetGameModel";
        string pathShoot = "https://localhost:7109/api/SeaBattleGame/Shoot";
        string pathEndGame = "https://localhost:7109/api/SeaBattleGame/EndGame";

        [Fact]
        public async Task TestGetPlayArea_smth_smth()
        {
            //pre
            var client = new HttpClient();
            var clientInfoModel = new PlayerClientInfoModel() { PlayerName = "asd", SessionName = "asdd"};            
            //act
            var response = await client.PostAsJsonAsync(pathGetPlayArea, clientInfoModel);
            var json = await response.Content.ReadAsStringAsync();
            var gameArea = JsonConvert.DeserializeObject<GameAreaClientModel>(json);
            //assert
            Assert.NotNull(gameArea);
        }
    }
}
//act
//var response = await client.PostAsJsonAsync(pathGetPlayArea, clientInfoModel);
//var gameModel = await response.Content.ReadFromJsonAsync<String>();
//var deser = JsonConvert.DeserializeObject<string[][]>(gameModel);