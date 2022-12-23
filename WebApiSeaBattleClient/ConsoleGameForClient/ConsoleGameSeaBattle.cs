using ConsoleGameFillerForClient;
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

        public void Start()
        {
            Console.WriteLine("Online Game sea battle.");
            RegisterPlayerAndSetClientModelsAsync();
            var listWaitingSessions = _requestHelper.GetAllWaitingSessionsOrThrowException().Result;
            ChooseHostOrJoinSession(listWaitingSessions);
            ChoosePlayAreaAndReadyToGame();
            var gameClientModel = WaitingStartGame();
            PlayGame(gameClientModel);
        }

        private void PlayGame(GameClientModel gameClientModel)
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


        private void RegisterPlayerAndSetClientModelsAsync()
        {
            Console.WriteLine("Write the name, and press enter for registration.");
            string namePlayer = Console.ReadLine();
            if (_requestHelper.IsStatusCodeOKAfterRegisterPlayer(namePlayer).Result)
            {
                SetNameInClientsModels(namePlayer);
                Console.WriteLine($"You registered. Your name is {_infoPlayerClientModel.PlayerName}.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The player is not registered. Try again\n");
            Console.ResetColor();
            RegisterPlayerAndSetClientModelsAsync();
        }

        private void ChooseHostOrJoinSession(List<HostSessionClientModel> listWaitingSessions)
        {
            if (listWaitingSessions == null)
            {
                Console.WriteLine("No waiting sessions found");
                HostSession();
                return;
            }
            Console.WriteLine("Available sessions to join: ");
            listWaitingSessions.ForEach(i => Console.Write($"\tName host: {i.HostPlayerName}, Name Session: {i.SessionName}\n"));
            Console.WriteLine("\nWrite the session name to connect, or something else to host");
            string message = Console.ReadLine();
            if (listWaitingSessions.SingleOrDefault(p => p.SessionName == message) == null)
            {
                HostSession();
                return;
            }
            JoinSession(message);
        }

        private void HostSession()
        {
            Console.WriteLine("\nWrite new host name to start the session");
            string message = Console.ReadLine();
            if (_requestHelper.IsStatusCodeOKAfterHostSessionPlayer(_infoPlayerClientModel.PlayerName, message).Result)
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
            HostSession();
        }

        private void JoinSession(string nameSession)
        {
            if (_requestHelper.IsStatusCodeOKAfterJoinSessionPlayer(_infoPlayerClientModel.PlayerName, nameSession).Result)
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
            JoinSession(nameSession);
        }

        private void ChoosePlayAreaAndReadyToGame()
        {
            Console.Clear();
            var key = new ConsoleKey();
            while (key != ConsoleKey.Enter)
            {
                var gameArea = _requestHelper.GetPlayAreaOrThrowException(_infoPlayerClientModel).Result;
                ConsoleGameFiller.FillConsolePlayerAreaOnly(gameArea.ClientPlayArea);
                Console.WriteLine("Press enter to use this play area, another button is change");
                key = Console.ReadKey().Key;
                Console.Clear();
            }
            _requestHelper.PostReadyToStartGameOrThrowException(_infoPlayerClientModel);
            Console.WriteLine("You're ready to the game, waiting enemy");
        }

        private GameClientModel WaitingStartGame()
        {
            Task.Delay(3000);
            var gameArea = _requestHelper.GetGameModelOrThrowException(_infoPlayerClientModel).Result;
            while (!gameArea.IsGameOn)
            {
                Task.Delay(3000);
                gameArea = _requestHelper.GetGameModelOrThrowException(_infoPlayerClientModel).Result;
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