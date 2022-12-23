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
        var response1 = await client.PostAsJsonAsync("https://localhost:7109/api/Player/Register", namePlayer);
        if (response1.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            throw new NullReferenceException("Error");
        }

        var response2 = await client.PostAsJsonAsync("https://localhost:7109/api/Session/HostSession",
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
        var response3 = await client.PostAsJsonAsync("https://localhost:7109/api/SeaBattleGame/GetPlayArea", new InfoPlayerClientModel() { PlayerName = "TestPlayer", SessionName = "TestSession" });
        if (response3.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            throw new NullReferenceException("Error");
        }
        //ready to start
        var response4 =  await client.PostAsJsonAsync("https://localhost:7109/api/SeaBattleGame/ReadyToStartGame",
            new InfoPlayerClientModel() { PlayerName = "TestPlayer", SessionName = "TestSession" });
        if (response4.StatusCode == System.Net.HttpStatusCode.BadRequest)
        {
            throw new NullReferenceException("Error");
        }
    }

    static async Task Main(string[] args)
    {
        await HostGameAndReadyToStartForTest();
        var consoleGameSeaBattle = new ConsoleGameSeaBattle();
        consoleGameSeaBattle.Start();

        Console.ReadLine();
    }
}
