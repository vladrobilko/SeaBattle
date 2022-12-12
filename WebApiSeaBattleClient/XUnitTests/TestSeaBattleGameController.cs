using SeaBattle.ApiClientModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
        public async Task TestGetPlayArea_smth_smth(string name)
        {
            //pre
            var client = new PlayerClientInfoModel();
            //act
            //assert
        }
    }
}
