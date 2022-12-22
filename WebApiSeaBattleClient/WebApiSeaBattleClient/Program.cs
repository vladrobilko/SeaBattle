using ConsoleGameFillerForClient;
using ConsoleGameForClient;
using Newtonsoft.Json;
using SeaBattle.ApiClientModels.Models;
using System.Net.Http.Json;

class Program
{
    private static async Task HostGameAndReadyToStartForTest()
    {
        var client = new HttpClient();
        string namePlayer = "TestPlayer";
        string nameSession = "TestSession";
        //host
        await client.PostAsJsonAsync("https://localhost:7109/api/Player/Register", namePlayer);

        await client.PostAsJsonAsync("https://localhost:7109/api/Session/HostSession",
            new HostSessionClientModel()
            {
                HostPlayerName = namePlayer,
                SessionName = nameSession
            });
        //get play area
        await client.PostAsJsonAsync("https://localhost:7109/api/SeaBattleGame/GetPlayArea", new InfoPlayerClientModel() { PlayerName = "TestPlayer", SessionName = "TestSession" });
        //ready to start
        await client.PostAsJsonAsync("https://localhost:7109/api/SeaBattleGame/ReadyToStartGame", new InfoPlayerClientModel() { PlayerName = "TestPlayer", SessionName = "TestSession" });
    }

    static async Task Main(string[] args)
    {
        await HostGameAndReadyToStartForTest();
        var consoleGameSeaBattle = new ConsoleGameSeaBattle();
        consoleGameSeaBattle.Start();

        Console.ReadLine();
    }
}
