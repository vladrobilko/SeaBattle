using ConsoleGameFillerForClient;
using ConsoleGameForClient;
using SeaBattle.ApiClientModels.Models;
using System.Net.Http.Json;

class Program
{
    private static async Task Host2GamesForPlayerSeeHostGames()
    {
        var client = new HttpClient();
        string namePlayer1 = "Player1";
        string nameSession1 = "SessionPlayer1";
        string namePlayer2 = "Player2";
        string nameSession2 = "SessionPlayer2";

        await client.PostAsJsonAsync("https://localhost:7109/api/Player/Register", namePlayer1);
        await client.PostAsJsonAsync("https://localhost:7109/api/Player/Register", namePlayer2);

        await client.PostAsJsonAsync("https://localhost:7109/api/Session/HostSession",
            new HostSessionClientModel()
            {
                HostPlayerName = namePlayer1,
                SessionName = nameSession1
            });

        await client.PostAsJsonAsync("https://localhost:7109/api/Session/HostSession",
             new HostSessionClientModel()
             {
                 HostPlayerName = namePlayer2,
                 SessionName = nameSession2
             });
    }

    static async Task Main(string[] args)
    {
        await Host2GamesForPlayerSeeHostGames();
        var consoleGameSeaBattle = new ConsoleGameSeaBattle();
        consoleGameSeaBattle.Start();

        Console.ReadLine();
    }
}
