using Newtonsoft.Json;
using SeaBattle.ApiClientModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameForClient
{
    public class RequestToSeaBattleApiHelper
    {
        private HttpClient _client = new HttpClient();

        private string pathPostRegisterPlayer = "https://localhost:7109/api/Player/Register";
        
        private string pathGetGetAllWaitingSessions = "https://localhost:7109/api/Session/GetAllWaitingSessions";
        private string pathPostHostSession = "https://localhost:7109/api/Session/HostSession";
        private string pathPostJoinSession = "https://localhost:7109/api/Session/JoinSession";

        private string pathPostGetPlayArea = "https://localhost:7109/api/SeaBattleGame/GetPlayArea";
        private string pathPostReadyToStartGame = "https://localhost:7109/api/SeaBattleGame/ReadyToStartGame";
        private string pathPostGetGameModel = "https://localhost:7109/api/SeaBattleGame/GetGameModel";
        private string pathPostShoot = "https://localhost:7109/api/SeaBattleGame/Shoot";

        public async Task HostGameAndReadyToStartForTest()
        {
            string namePlayer = "TestPlayer";
            string nameSession = "TestSession";
            //host
            var response1 = await _client.PostAsJsonAsync("https://localhost:7109/api/Player/Register", new PlayerRegistrationClientModel() { NamePlayer = namePlayer});
            if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new NullReferenceException("Error");
            }

            var response2 = await _client.PostAsJsonAsync("https://localhost:7109/api/Session/HostSession",
                new HostSessionClientModel()
                {
                    HostPlayerName = namePlayer,
                    SessionName = nameSession
                });
            if (response2.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new NullReferenceException("Error");
            }
            //get play area
            var response3 = await _client.PostAsJsonAsync("https://localhost:7109/api/SeaBattleGame/GetPlayArea", new InfoPlayerClientModel() { PlayerName = "TestPlayer", SessionName = "TestSession" });
            if (response3.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new NullReferenceException("Error");
            }
            //ready to start
            var response4 = await _client.PostAsJsonAsync("https://localhost:7109/api/SeaBattleGame/ReadyToStartGame",
                new InfoPlayerClientModel() { PlayerName = "TestPlayer", SessionName = "TestSession" });
            if (response4.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new NullReferenceException("Error");
            }
        }

        public async Task<bool> IsStatusCodeOKAfterRegisterPlayer(PlayerRegistrationClientModel playerRegistrationClientModel)
        {
            var response = await _client.PostAsJsonAsync(pathPostRegisterPlayer, playerRegistrationClientModel);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<List<HostSessionClientModel>> GetAllWaitingSessionsOrThrowException()
        {
            var response = await _client.GetAsync(pathGetGetAllWaitingSessions);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new Exception("Error");
            var json = await response.Content.ReadAsStringAsync();
            var listWaitingSessions = JsonConvert.DeserializeObject<List<HostSessionClientModel>>(json);
            return listWaitingSessions;
        }

        public async Task<bool> IsStatusCodeOKAfterHostSessionPlayer(string playerHostName,string sessionName)
        {
            var response = await _client.PostAsJsonAsync(pathPostHostSession,
                    new HostSessionClientModel()
                    {
                        HostPlayerName = playerHostName,
                        SessionName = sessionName
                    });
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<GameAreaClientModel> GetPlayAreaOrThrowException(InfoPlayerClientModel infoPlayerClientModel)
        {
            var response = await _client.PostAsJsonAsync(pathPostGetPlayArea, infoPlayerClientModel);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception("Error");
            }
            var json = await response.Content.ReadAsStringAsync();
            var gameArea = JsonConvert.DeserializeObject<GameAreaClientModel>(json);
            return gameArea;
        }

        public async Task<bool> IsStatusCodeOKAfterJoinSessionPlayer(string playerHostName, string sessionName)
        {
            var response = await _client.PostAsJsonAsync(pathPostJoinSession,
                new JoinSessionClientModel()
                {
                    JoinPlayerName = playerHostName,
                    SessionName = sessionName
                });
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task PostReadyToStartGameOrThrowException(InfoPlayerClientModel infoPlayerClientModel)
        {
            var response = await _client.PostAsJsonAsync(pathPostReadyToStartGame, infoPlayerClientModel);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception("Error");
            }
        }

        public async Task<GameClientStateModel> GetGameModelOrThrowException(InfoPlayerClientModel infoPlayerClientModel)
        {
            var response = await _client.PostAsJsonAsync(pathPostGetGameModel, infoPlayerClientModel);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception("Error");
            }
            var json = await response.Content.ReadAsStringAsync();
            var gameModel = JsonConvert.DeserializeObject<GameClientStateModel>(json);
            return gameModel;
        }

        public async Task<bool> IsStatusCodeOKAfterShoot(ShootPlayerClientModel shootPlayerClientModel)
        {
            var response = await _client.PostAsJsonAsync(pathPostShoot, shootPlayerClientModel);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
