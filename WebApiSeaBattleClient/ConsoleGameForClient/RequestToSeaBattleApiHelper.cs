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
    public static class RequestToSeaBattleApiHelper
    {
        private static HttpClient _client = new HttpClient();

        private static string pathPostRegisterPlayer = "https://localhost:7109/api/Player/Register";

        private static string pathGetGetAllWaitingSessions = "https://localhost:7109/api/Session/GetAllWaitingSessions";
        private static string pathPostHostSession = "https://localhost:7109/api/Session/HostSession";
        private static string pathPostJoinSession = "https://localhost:7109/api/Session/JoinSession";

        private static string pathPostGetPlayArea = "https://localhost:7109/api/SeaBattleGame/GetPlayArea";
        private static string pathPostChangePlayArea = "https://localhost:7109/api/SeaBattleGame/ChangePlayArea";
        private static string pathPostReadyToStartGame = "https://localhost:7109/api/SeaBattleGame/ReadyToStartGame";
        private static string pathPostGetGameModel = "https://localhost:7109/api/SeaBattleGame/GetGameModel";
        private static string pathPostShoot = "https://localhost:7109/api/SeaBattleGame/Shoot";

        public static async Task<HttpResponseMessage> ResponseAfterRegisterPlayer(string name)
        {
            return await _client.PostAsJsonAsync(pathPostRegisterPlayer, name);
        }

        public static async Task<List<HostSessionClientModel>> GetAllWaitingSessions()
        {
            var response = await _client.GetAsync(pathGetGetAllWaitingSessions);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            var listWaitingSessions = JsonConvert.DeserializeObject<List<HostSessionClientModel>>(json);
            return listWaitingSessions;
        }


    }
}
