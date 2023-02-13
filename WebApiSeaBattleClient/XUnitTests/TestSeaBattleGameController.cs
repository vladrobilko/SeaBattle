using SeaBattle.ApiClientModels.Models;
using System.Net.Http.Json;
using Xunit;
using Newtonsoft.Json;

namespace XUnitTests
{
    public class TestSeaBattleGameController
    {
        string pathGetPlayArea = "https://localhost:7109/api/SeaBattleGame/GetPlayArea";
        string pathChangePlayArea = "https://localhost:7109/api/SeaBattleGame/ChangePlayArea";
        string pathGetGameModel = "https://localhost:7109/api/SeaBattleGame/GetGameModel";
        string pathShoot = "https://localhost:7109/api/SeaBattleGame/Shoot";

        [Fact]
        public async Task TestA_PostGetPlayArea_GetPlayArea_ReturnPlayAreaNotNull()
        {
            //pre
            var client = new HttpClient();
            var clientInfoModel = new InfoPlayerClientModel() { PlayerName = "TestA", SessionName = "TestA" };            
            //act
            var response = await client.PostAsJsonAsync(pathGetPlayArea, clientInfoModel);
            var json = await response.Content.ReadAsStringAsync();
            var gameArea = JsonConvert.DeserializeObject<GameAreaClientModel>(json);
            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(gameArea);
        }

        [Fact]
        public async Task TestB_PostChangePlayArea_GetNewPlayArea_ReturnPlayAreaNotNull()
        {
            //pre
            var client = new HttpClient();
            var clientInfoModel = new InfoPlayerClientModel() { PlayerName = "TestB", SessionName = "TestB" };
            //act
            var response = await client.PostAsJsonAsync(pathChangePlayArea, clientInfoModel);
            var json = await response.Content.ReadAsStringAsync();
            var gameArea = JsonConvert.DeserializeObject<GameAreaClientModel>(json);
            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(gameArea);
        }
                
        //[Fact] - переделать так как переделал метод в контроллере
        //public async Task TestC_PostReadyToStartGame_ReadyToStartGame_ReturnGameClientModelNotNull()
        //{
        //    //pre
        //    var client = new HttpClient();
        //    var clientInfoModel = new PlayerClientInfoModel() { PlayerName = "TestC", SessionName = "TestC" };
        //    //act
        //    var response = await client.PostAsJsonAsync(pathReadyToStartGame, clientInfoModel);
        //    var json = await response.Content.ReadAsStringAsync();
        //    var gameArea = JsonConvert.DeserializeObject<GameClientModel>(json);
        //    //assert
        //    Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        //    Assert.NotNull(gameArea);
        //}

        [Fact]
        public async Task TestD_PostGetGameModel_GetGameModel_ReturnGameClientModelNotNull()
        {
            //pre
            var client = new HttpClient();
            var clientInfoModel = new InfoPlayerClientModel() { PlayerName = "TestD", SessionName = "TestD" };
            //act
            var response = await client.PostAsJsonAsync(pathGetGameModel, clientInfoModel);
            var json = await response.Content.ReadAsStringAsync();
            var gameArea = JsonConvert.DeserializeObject<GameClientStateModel>(json);
            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(gameArea);
        }

        [Fact]
        public async Task TestE_PostShoot_PlayerShoot_ReturnGameClientModelNotNull()
        {
            //pre
            var client = new HttpClient();
            var clientShootModel = new ShootClientModel()
            {
                PlayerName = "TestE",
                NameSession = "TestE",
                ShootCoordinateX = 1,
                ShootCoordinateY = 2
            };
            //act
            var response = await client.PostAsJsonAsync(pathShoot, clientShootModel);
            var json = await response.Content.ReadAsStringAsync();
            var gameArea = JsonConvert.DeserializeObject<GameClientStateModel>(json);
            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(gameArea);
        }
    }
}