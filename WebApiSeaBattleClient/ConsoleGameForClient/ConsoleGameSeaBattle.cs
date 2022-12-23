﻿using ConsoleGameFillerForClient;
using Newtonsoft.Json;
using SeaBattle.ApiClientModels.Models;
using System.Net.Http.Json;

namespace ConsoleGameForClient
{
    public class ConsoleGameSeaBattle
    {
        private RequestToSeaBattleApiHelper _requestHelper;

        private InfoPlayerClientModel _infoPlayerClientModel;

        private ShootPlayerClientModel _shootPlayerClientModel;

        public ConsoleGameSeaBattle()
        {
            _infoPlayerClientModel = new InfoPlayerClientModel();
            _shootPlayerClientModel = new ShootPlayerClientModel();
            _requestHelper = new RequestToSeaBattleApiHelper();
        }

        public async Task Start()
        {
            await _requestHelper.HostGameAndReadyToStartForTest(); // host player for testing 


            Console.WriteLine("Online Game sea battle.");
            await RegisterPlayerAndSetClientModelsAsync();
            var listWaitingSessions = _requestHelper.GetAllWaitingSessionsOrThrowException().Result;
            await ChooseHostOrJoinSession(listWaitingSessions);
            await ChoosePlayAreaAndReadyToGame();
            GameClientStateModel gameClientModel = await WaitingStartGame();
            await PlayGame(gameClientModel);
        }

        private async Task PlayGame(GameClientStateModel gameClientModel)
        {
            Console.Clear();
            ConsoleGameFiller.FillConsolePlayerAreaAndEnemyArea(gameClientModel.ClientPlayArea, gameClientModel.EnemyPlayArea);
            Console.WriteLine(gameClientModel.Message);
            while (true)
            {

            }
            /*
            while (gameClientModel.IsGameOn)
            {
                if (gameClientModel.IsPlayerTurnToShoot == false)
                {
                    Task.Delay(2000);
                    Console.Clear();
                    ConsoleGameFiller.FillConsolePlayerAreaAndEnemyArea(gameClientModel.ClientPlayArea, gameClientModel.EnemyPlayArea);
                    Console.WriteLine(gameClientModel.Message);
                }
                else if (gameClientModel.IsPlayerTurnToShoot)
                {
                    Console.WriteLine("Your turn to shoot.");
                    Console.WriteLine("Enter the first coordinate");
                    int coordinateY = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the second coordinate");
                    int coordinateX = int.Parse(Console.ReadLine());
                    gameClientModel = _requestHelper.Shoot(new ShootPlayerClientModel()
                    {
                        PlayerName = _infoPlayerClientModel.PlayerName,
                        SessionName = _infoPlayerClientModel.SessionName,
                        ShootCoordinateY = coordinateY,
                        ShootCoordinateX = coordinateX

                    }).Result;
                }
            }*/

            //message контроллер выдает общий для всех, то есть одно и тоже сообщение видят два игрока если делают запрос
            //метод принятия выстрела 
            //метод выстрела 
        }


        private async Task RegisterPlayerAndSetClientModelsAsync()
        {
            Console.WriteLine("Write the name, and press enter for registration.");
            string namePlayer = Console.ReadLine();
            if (await _requestHelper.IsStatusCodeOKAfterRegisterPlayer(namePlayer))
            {
                SetNameInClientsModels(namePlayer);
                Console.WriteLine($"You registered. Your name is {_infoPlayerClientModel.PlayerName}.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The player is not registered. Try again\n");
            Console.ResetColor();
            await RegisterPlayerAndSetClientModelsAsync();
        }

        private async Task ChooseHostOrJoinSession(List<HostSessionClientModel> listWaitingSessions)
        {
            if (listWaitingSessions == null)
            {
                Console.WriteLine("No waiting sessions found");
                await HostSession();
                return;
            }
            Console.WriteLine("Available sessions to join: ");
            listWaitingSessions.ForEach(i => Console.Write($"\tName host: {i.HostPlayerName}, Name Session: {i.SessionName}\n"));
            Console.WriteLine("\nWrite the session name to connect, or something else to host");
            string message = Console.ReadLine();
            if (listWaitingSessions.SingleOrDefault(p => p.SessionName == message) == null)
            {
                await HostSession();
                return;
            }
            await JoinSession(message);
        }

        private async Task HostSession()
        {
            Console.WriteLine("\nWrite new host name to start the session");
            string message = Console.ReadLine();
            if (await _requestHelper.IsStatusCodeOKAfterHostSessionPlayer(_infoPlayerClientModel.PlayerName, message))
            {
                SetNameSessionInClientsModels(message);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The session was created.\n\t Your name of session: <<{message}>>." +
                    $"\n\t Your name: <<{_infoPlayerClientModel.PlayerName}>>");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("Error.");
            await HostSession();
        }

        private async Task JoinSession(string nameSession)
        {
            if (await _requestHelper.IsStatusCodeOKAfterJoinSessionPlayer(_infoPlayerClientModel.PlayerName, nameSession))
            {
                SetNameSessionInClientsModels(nameSession);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You have connected to the session.\n\t Your name of session: <<{nameSession}>>." +
                    $" \t Your name: <<{_infoPlayerClientModel.PlayerName}>>");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("Error.");
            await JoinSession(nameSession);
        }

        private async Task ChoosePlayAreaAndReadyToGame()
        {
            Console.Clear();
            var key = new ConsoleKey();
            while (key != ConsoleKey.Enter)
            {
                var gameArea = await _requestHelper.GetPlayAreaOrThrowException(_infoPlayerClientModel);
                ConsoleGameFiller.FillConsolePlayerAreaOnly(gameArea.ClientPlayArea);
                Console.WriteLine("Press enter to use this play area, another button is change");
                key = Console.ReadKey().Key;
                Console.Clear();
            }
            await _requestHelper.PostReadyToStartGameOrThrowException(_infoPlayerClientModel);
            Console.WriteLine("You're ready to the game, waiting enemy");
        }

        private async Task<GameClientStateModel> WaitingStartGame()
        {
            Task.Delay(3000).Wait();
            var gameArea = await _requestHelper.GetGameModelOrThrowException(_infoPlayerClientModel);
            while (!gameArea.IsGameOn)
            {
                Task.Delay(3000).Wait();
                gameArea = await _requestHelper.GetGameModelOrThrowException(_infoPlayerClientModel);
            }   
            Console.WriteLine("The game has started");
            return gameArea;
        }

        private void SetNameInClientsModels(string namePlayer)
        {
            _infoPlayerClientModel.PlayerName = namePlayer;
            _shootPlayerClientModel.PlayerName = namePlayer;
        }

        private void SetNameSessionInClientsModels(string nameSession)
        {
            _infoPlayerClientModel.SessionName = nameSession;
            _shootPlayerClientModel.SessionName = nameSession;
        }
    }
}