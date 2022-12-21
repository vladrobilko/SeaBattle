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

        public async Task<bool> IsStatusCodeOKAfterRegisterPlayer(string name)
        {
            var response = await _client.PostAsJsonAsync(pathPostRegisterPlayer, name);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<List<HostSessionClientModel>> GetAllWaitingSessions()
        {
            var response = await _client.GetAsync(pathGetGetAllWaitingSessions);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return null;
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

        public async Task<GameAreaClientModel> GetPlayArea(InfoPlayerClientModel infoPlayerClientModel)
        {
            var response = await _client.PostAsJsonAsync(pathPostGetPlayArea, infoPlayerClientModel);
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

        public async Task PostReadyToStartGame(InfoPlayerClientModel infoPlayerClientModel)
        {
            var response = await _client.PostAsJsonAsync(pathPostReadyToStartGame, infoPlayerClientModel);
        }

        public async Task<GameClientModel> GetGameModel(InfoPlayerClientModel infoPlayerClientModel)
        {
            var response = await _client.PostAsJsonAsync(pathPostGetGameModel, infoPlayerClientModel);
            var json = await response.Content.ReadAsStringAsync();
            var gameModel = JsonConvert.DeserializeObject<GameClientModel>(json);
            return gameModel;
        }

        public async Task<GameClientModel> Shoot(ShootPlayerClientModel shootPlayerClientModel)
        {
            throw new NotImplementedException();
        }
    }
}
