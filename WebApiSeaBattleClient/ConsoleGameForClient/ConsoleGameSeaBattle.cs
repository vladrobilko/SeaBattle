using ConsoleGameFillerForClient;
using Newtonsoft.Json;
using SeaBattle.ApiClientModels.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleGameForClient
{
    public class ConsoleGameSeaBattle
    {
        private HttpClient _client;

        private InfoPlayerClientModel _playerClientInfoModel;

        private ShootPlayerClientModel _playerClientShootModel;

        private string[][] _playAreaEnemy;

        public ConsoleGameSeaBattle()
        {
            _playerClientInfoModel = new InfoPlayerClientModel();
            _playerClientShootModel = new ShootPlayerClientModel();
            _client = new HttpClient();
        }

        public async Task Start()
        {
            Console.WriteLine("Online Game sea battle.");
            await RegisterPlayerAndSetClientModelsAsync();
            var listWaitingSessions = await RequestToSeaBattleApiHelper.GetAllWaitingSessions();
            await HostOrJoinSession(listWaitingSessions);
            await ChoosePlayAreaAndReadyToGame();
            var gameModel = await WaitingStartGame();
            await PlayGame(gameModel);
            Console.ReadKey();
        }

        private async Task HostOrJoinSession(List<HostSessionClientModel> listWaitingSessions)
        {
            if (listWaitingSessions == null)
            {
                Console.WriteLine("No waiting sessions found");
                Console.WriteLine("\nWrite new host name to start the session");
                string message2 = Console.ReadLine();
                await HostSession(message2);
                return;
            }
            Console.WriteLine("Available sessions to join: ");
            listWaitingSessions.ForEach(i => Console.Write($"\tName host: {i.HostPlayerName}, Name Session: {i.SessionName}\n"));
            Console.WriteLine("\nWrite the session name to connect");
            string message = Console.ReadLine();
            await JoinSession(message);
        }

        private async Task PlayGame(GameClientModel gameClientModel)
        {
            Console.WriteLine(gameClientModel.Message);
            SetEnemyArea(gameClientModel.ClientPlayArea.Length);
            if (gameClientModel.PlayerTurnToShoot == true)
            {

            }
        }

        private void SetEnemyArea(int length)
        {
            _playAreaEnemy = new string[length][];
            for (int i = 0; i < length; i++)
            {
                _playAreaEnemy[i] = new string[10] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
            }
        }

        private async Task<GameClientModel> WaitingStartGame()
        {
            var gameArea = await GetGameModelWithDelay3SecondFromServer();
            while (!gameArea.IsGameStarted)
            {
                gameArea = await GetGameModelWithDelay3SecondFromServer();
            }
            return gameArea;
        }

        private async Task<GameClientModel> GetGameModelWithDelay3SecondFromServer()
        {
            await Task.Delay(3000);
            var response = await _client.PostAsJsonAsync("https://localhost:7109/api/SeaBattleGame/GetGameModel", _playerClientInfoModel);
            var json = await response.Content.ReadAsStringAsync();
            var gameModel = JsonConvert.DeserializeObject<GameClientModel>(json);
            return gameModel;
        }

        private async Task ChoosePlayAreaAndReadyToGame()
        {
            var key = new ConsoleKey();
            while (key != ConsoleKey.Enter)
            {
                await GetPlayArea();
                Console.WriteLine(" Press enter to use this play area, another button is change");
                key = Console.ReadKey().Key;
                Console.Clear();
            }

            var response = await _client.PostAsJsonAsync("https://localhost:7109/api/SeaBattleGame/ReadyToStartGame", _playerClientInfoModel);
            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine(json);
        }

        private async Task GetPlayArea()
        {
            var key = new ConsoleKey();
            while (key != ConsoleKey.Enter)
            {
                Console.WriteLine(" Press enter to get the play arena");
                key = Console.ReadKey().Key;
                Console.Clear();
                var response = await _client.PostAsJsonAsync("https://localhost:7109/api/SeaBattleGame/GetPlayArea", _playerClientInfoModel);
                var json = await response.Content.ReadAsStringAsync();
                var gameArea = JsonConvert.DeserializeObject<GameAreaClientModel>(json);
                ConsoleGameFiller.FillConsolePlayerAreaOnly(gameArea.ClientPlayArea);
                Console.WriteLine("");
            }
        }

        private async Task RegisterPlayerAndSetClientModelsAsync()
        {
            try
            {
                Console.WriteLine("Write the name, and press enter for registration.");
                string namePlayer = Console.ReadLine();
                var response = await RequestToSeaBattleApiHelper.ResponseAfterRegisterPlayer(namePlayer);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    SetNameInClientsModels(namePlayer);
                    Console.WriteLine($"You registered. Your name is {_playerClientInfoModel.PlayerName}.");
                    return;
                }
                var json = await response.Content.ReadAsStringAsync();
                throw new Exception(json);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                await RegisterPlayerAndSetClientModelsAsync();
            }
        }

        private void SetNameInClientsModels(string namePlayer)
        {
            _playerClientInfoModel.PlayerName = namePlayer;
            _playerClientShootModel.PlayerName = namePlayer;
        }

        private async Task HostSession(string nameSession)
        {
            try
            {
                await _client.PostAsJsonAsync("https://localhost:7109/api/Session/HostSession",
                    new HostSessionClientModel()
                    {
                        HostPlayerName = _playerClientInfoModel.PlayerName,
                        SessionName = nameSession
                    });
                SetNameSessionInClientsModels(nameSession);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The session was created.\n\t Your name of session: <<{nameSession}>>." +
                    $"\n\t Your name: <<{_playerClientInfoModel.PlayerName}>>");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
        }

        private async Task JoinSession(string nameSession)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("https://localhost:7109/api/Session/JoinSession",
                    new JoinSessionClientModel()
                    {
                        JoinPlayerName = _playerClientInfoModel.PlayerName,
                        SessionName = nameSession
                    });
                SetNameSessionInClientsModels(nameSession);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You have connected to the session.\n\t Your name of session: <<{nameSession}>>." +
                    $" \t Your name: <<{_playerClientInfoModel.PlayerName}>>");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
        }

        private void SetNameSessionInClientsModels(string nameSession)
        {
            _playerClientInfoModel.SessionName = nameSession;
            _playerClientShootModel.SessionName = nameSession;
        }
    }
}