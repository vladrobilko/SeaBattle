using Newtonsoft.Json;
using SeaBattle.ApiClientModels.Models;
using System.Net.Http.Json;

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

        public async Task<bool> IsStatusCodeOKAfterPostRegisterPlayer(PlayerRegistrationClientModel playerRegistrationClientModel)
        {
            var responseRegisterPlayer = await _client.PostAsJsonAsync(pathPostRegisterPlayer, playerRegistrationClientModel);

            return responseRegisterPlayer.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<List<HostSessionClientModel>> GetAllWaitingSessionsOrNull()
        {
            var responseGetAllSessions = await _client.GetAsync(pathGetGetAllWaitingSessions);

            if (responseGetAllSessions.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return null;

            var json = await responseGetAllSessions.Content.ReadAsStringAsync();
            var listWaitingSessions = JsonConvert.DeserializeObject<List<HostSessionClientModel>>(json);

            return listWaitingSessions;
        }

        public async Task<bool> IsStatusCodeOKAfterPostHostSessionPlayer(string playerHostName, string sessionName)
        {
            var responseHostSession = await _client.PostAsJsonAsync(pathPostHostSession,
                    new HostSessionClientModel()
                    {
                        HostPlayerName = playerHostName,
                        SessionName = sessionName
                    });

            return responseHostSession.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<GameAreaClientModel> GetPlayAreaOrNull(InfoPlayerClientModel infoPlayerClientModel)
        {
            var responseGetPlayArea = await _client.PostAsJsonAsync(pathPostGetPlayArea, infoPlayerClientModel);

            if (responseGetPlayArea.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            var json = await responseGetPlayArea.Content.ReadAsStringAsync();
            var gameArea = JsonConvert.DeserializeObject<GameAreaClientModel>(json);

            return gameArea;
        }

        public async Task<bool> IsStatusCodeOKAfterPostJoinSessionPlayer(string playerHostName, string sessionName)
        {
            var responseJoinSession = await _client.PostAsJsonAsync(pathPostJoinSession,
                new JoinSessionClientModel()
                {
                    NameJoinPlayer = playerHostName,
                    NameSession = sessionName
                });

            return responseJoinSession.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<bool> IsStatusCodeOKAfterPostReadyToStartGame(InfoPlayerClientModel infoPlayerClientModel)
        {
            var responseReadyToStartGame = await _client.PostAsJsonAsync(pathPostReadyToStartGame, infoPlayerClientModel);

            return responseReadyToStartGame.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<GameClientStateModel> GetGameModelOrNull(InfoPlayerClientModel infoPlayerClientModel)
        {
            var responseGetGameModel = await _client.PostAsJsonAsync(pathPostGetGameModel, infoPlayerClientModel);

            if (responseGetGameModel.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return null;
            }

            var json = await responseGetGameModel.Content.ReadAsStringAsync();
            var gameModel = JsonConvert.DeserializeObject<GameClientStateModel>(json);

            return gameModel;
        }

        public async Task<bool> IsStatusCodeOKAfterPostShoot(ShootClientModel shootPlayerClientModel)
        {
            var responseShoot = await _client.PostAsJsonAsync(pathPostShoot, shootPlayerClientModel);

            return responseShoot.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}