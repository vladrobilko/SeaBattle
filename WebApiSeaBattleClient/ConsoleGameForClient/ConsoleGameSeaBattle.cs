﻿using SeaBattle.ApiClientModels.Models;

namespace ConsoleGameForClient
{
    public class ConsoleGameSeaBattle
    {
        private readonly RequestToSeaBattleApiHelper _requestHelper;

        private readonly InfoPlayerClientModel _infoPlayerClientModel;

        private readonly ShootClientModel _shootPlayerClientModel;

        private readonly TimeSpan _delayToViewInfo = TimeSpan.FromSeconds(3);

        public ConsoleGameSeaBattle()
        {
            _infoPlayerClientModel = new InfoPlayerClientModel();
            _shootPlayerClientModel = new ShootClientModel();
            _requestHelper = new RequestToSeaBattleApiHelper();
        }

        public async Task Start()
        {
            Console.SetWindowSize(60, 20);
            Console.WriteLine("Online Game sea battle.");

            await RegisterPlayer();

            await ChooseHostOrJoinSession();

            await ChoosePlayArea();

            await PreparingToGame();

            var gameModel = await WaitingStartGame();

            await PlayGame(gameModel);
        }

        private async Task RegisterPlayer()
        {
            Console.WriteLine("Write the name, and press enter for registration.");
            var namePlayer = Console.ReadLine();

            var registrationModel = new PlayerRegistrationClientModel() { NamePlayer = namePlayer };

            if (await _requestHelper.IsStatusCodeOkAfterPostRegisterPlayer(registrationModel))
            {
                SetNameInClientsModels(namePlayer);

                Console.Clear();
                Console.WriteLine($"You registered. Your name is {_infoPlayerClientModel.PlayerName}.");

                return;
            }

            Console.WriteLine("The player is not registered. Try again\n");
            await RegisterPlayer();
        }

        private async Task ChooseHostOrJoinSession()
        {
            var key = new ConsoleKey();

            while (key != ConsoleKey.F1 && key != ConsoleKey.F2)
            {
                Console.WriteLine("Press F1 to host session, press F2 to join session.");
                key = Console.ReadKey().Key;

                if (key == ConsoleKey.F1)
                {
                    await HostSession();
                }

                else if (key == ConsoleKey.F2)
                {
                    await JoinSession();
                }
            }
        }

        private async Task HostSession()
        {
            Console.WriteLine("Host Session.\n Write new host name to start the session");
            string? sessionName = Console.ReadLine();

            if (await _requestHelper.IsStatusCodeOkAfterPostHostSessionPlayer(_infoPlayerClientModel.PlayerName, sessionName))
            {
                SetNameSessionInClientsModels(sessionName);

                Console.Clear();
                Console.WriteLine("The session was created." +
                    $"\n Your name of session: {sessionName}." +
                    $"\n Your name: {_infoPlayerClientModel.PlayerName}");

                return;
            }

            Console.WriteLine("Error. Try again.");
            await HostSession();
        }

        private async Task JoinSession()
        {
            var listWaitingSessions = _requestHelper.GetAllWaitingSessionsOrNull()?.Result;

            if (listWaitingSessions != null)
            {
                Console.WriteLine("Available sessions to join: ");
                listWaitingSessions.ForEach(i => Console.Write($"\tName host: {i?.HostPlayerName}, Name Session: {i?.SessionName}\n"));

                Console.WriteLine(
                    "\nWrite the session name to connect." +
                    "\nOr press another button to return back and host game");
                string? sessionName = Console.ReadLine();

                if (await _requestHelper.IsStatusCodeOkAfterPostJoinSessionPlayer(_infoPlayerClientModel.PlayerName, sessionName))
                {
                    SetNameSessionInClientsModels(sessionName);

                    Console.Clear();
                    Console.WriteLine("You have connected to the session." +
                        $"\n Your name of session: <<{sessionName}>>." +
                        $"\n Your name: <<{_infoPlayerClientModel.PlayerName}>>");
                }

                else
                {
                    await ChooseHostOrJoinSession();
                }
            }
            else
            {
                Console.WriteLine("Free session not found. Press enter to return to choice.");
                Console.ReadKey();
                Console.Clear();
                await ChooseHostOrJoinSession();
            }
        }

        private async Task ChoosePlayArea()
        {
            await Task.Delay(_delayToViewInfo);
            Console.Clear();

            var key = new ConsoleKey();

            while (key != ConsoleKey.Enter)
            {
                var gameArea = await _requestHelper.GetPlayAreaOrNull(_infoPlayerClientModel);

                if (gameArea == null)
                {
                    await CloseConsoleWithDelay();
                }

                ConsoleGameFiller.FillConsolePlayerAreaOnly(gameArea?.ClientPlayArea);

                Console.WriteLine("Press enter to use this play area, another button is change");
                key = Console.ReadKey().Key;
                Console.Clear();
            }
        }

        private async Task PreparingToGame()
        {
            if (await _requestHelper.IsStatusCodeOkAfterPostReadyToStartGame(_infoPlayerClientModel))
            {
                Console.WriteLine("You're ready to the game, waiting enemy");
            }

            else
            {
                await CloseConsoleWithDelay();
            }
        }

        private async Task<GameClientStateModel?> WaitingStartGame()
        {
            GameClientStateModel? gameModel;

            do
            {
                await Task.Delay(_delayToViewInfo);
                gameModel = await _requestHelper.GetGameModelOrNull(_infoPlayerClientModel);
            } while (gameModel == null || !gameModel.IsGameOn);

            if (gameModel.ClientPlayArea == null)
            {
                await CloseConsoleWithDelay(gameModel.Message);
            }

            Console.WriteLine("The game has started");
            await Task.Delay(_delayToViewInfo);

            return gameModel;
        }

        private async Task PlayGame(GameClientStateModel? gameClientModel)
        {
            while (gameClientModel!.IsGameOn)
            {
                await ViewGameInConsole();
                gameClientModel = await _requestHelper.GetGameModelOrNull(_infoPlayerClientModel);
                if (gameClientModel!.NamePlayerTurn == _infoPlayerClientModel.PlayerName)
                {
                    await Shoot();
                }

                if (gameClientModel.NamePlayerTurn != _infoPlayerClientModel.PlayerName)
                {
                    await Task.Delay(_delayToViewInfo);
                }
            }

            Console.Clear();
            Console.WriteLine($"Game ended.\n {gameClientModel.Message}");
            await Task.Delay(_delayToViewInfo);
        }

        private async Task Shoot()
        {
            var shootModel = FillShootModelForSend();

            var isShootResultValid = await _requestHelper.IsStatusCodeOkAfterPostShoot(shootModel);

            while (!isShootResultValid)
            {
                var gameClientStateModel = await _requestHelper.GetGameModelOrNull(_infoPlayerClientModel);

                Console.WriteLine(gameClientStateModel?.Message);

                if (!gameClientStateModel!.IsGameOn)
                {
                    return;
                }

                shootModel = FillShootModelForSend();

                isShootResultValid = await _requestHelper.IsStatusCodeOkAfterPostShoot(shootModel);
            }
        }

        private async Task ViewGameInConsole()
        {
            var gameClientStateModel = await _requestHelper.GetGameModelOrNull(_infoPlayerClientModel);
            Console.Clear();
            ConsoleGameFiller.FillConsolePlayerAreaAndEnemyArea(gameClientStateModel?.ClientPlayArea,
                gameClientStateModel?.EnemyPlayArea);
            Console.WriteLine(gameClientStateModel?.Message);
        }

        private ShootClientModel FillShootModelForSend()
        {
            try
            {
                Console.WriteLine("Enter the first coordinate");
                var coordinateY = int.Parse(Console.ReadLine() ?? string.Empty);

                Console.WriteLine("Enter the second coordinate");
                var coordinateX = int.Parse(Console.ReadLine() ?? string.Empty);

                if (coordinateY > 9 || coordinateY < 0 || coordinateX > 9 || coordinateX < 0)
                {
                    throw new Exception();
                }

                var shootModel = new ShootClientModel()
                {
                    PlayerName = _infoPlayerClientModel.PlayerName,
                    NameSession = _infoPlayerClientModel.SessionName,
                    ShootCoordinateY = coordinateY,
                    ShootCoordinateX = coordinateX
                };

                return shootModel;
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect input, enter again.");
                return FillShootModelForSend();
            }
        }

        private void SetNameInClientsModels(string? namePlayer)
        {
            _infoPlayerClientModel.PlayerName = namePlayer;
            _shootPlayerClientModel.PlayerName = namePlayer;
        }

        private void SetNameSessionInClientsModels(string? nameSession)
        {
            _infoPlayerClientModel.SessionName = nameSession;
            _shootPlayerClientModel.NameSession = nameSession;
        }

        private async Task CloseConsoleWithDelay()
        {
            Console.Clear();
            Console.WriteLine("Server error. Please, restart application.");
            await Task.Delay(_delayToViewInfo);
            Environment.Exit(0);
        }

        private async Task CloseConsoleWithDelay(string? gameMessage)
        {
            Console.Clear();
            Console.WriteLine(gameMessage);
            await Task.Delay(_delayToViewInfo);
            Environment.Exit(0);
        }
    }
}