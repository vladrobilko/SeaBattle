using System.IO;
using System.Net.Http.Json;
using System.Xml.Linq;
using SeaBattleApi.Models;
using SeaBattleApi.Models.Interfaces;

class Program
{
    static async Task Main(string[] args)
    {
        ConsoleKey key = new ConsoleKey();
        while (key != ConsoleKey.Escape)
        {
            Information();
            key = Console.ReadKey().Key;                        
            if (key == ConsoleKey.Enter)
            {
                await CreatePlayer("https://localhost:7109/api/PlayerClient/Login", "Vasya");
            }
            else if (key == ConsoleKey.F1)
            {
                await GetPlayerByName("https://localhost:7109/api/PlayerClient/GetByName","Vasya");
            }

            else if (key == ConsoleKey.F2)
            {
                CreateSession("https://localhost:7109/api/SeaBattleSession/Create", _player, "Sea Battle");
            }

            else if (key == ConsoleKey.F3)
            {
                GetAllSession("https://localhost:7109/api/SeaBattleSession/GetAll", _seaBattleGameSession.ID);
            }
        }
    }
    private static readonly HttpClient client = new HttpClient();

    private static PlayerClient _player;

    private static SeaBattleGameSession _seaBattleGameSession;

    private static async Task CreatePlayer(string path, string playerName)
    {
        using HttpResponseMessage response = await client.PostAsJsonAsync(path, playerName);
        Console.WriteLine($"Status code: {response.StatusCode}");
    }

    private static async Task GetPlayerByName(string path, string name)
    {
        using HttpResponseMessage response = await client.PostAsJsonAsync(path, name);
        _player = await response.Content.ReadFromJsonAsync<PlayerClient>();
        if (_player != null)
        {
            Console.WriteLine($"Name: {_player.Name}, ID: {_player.ID}, time adding: {_player.TimeAdding}");
            return;
        }
        Console.WriteLine($"The player isn't created. Error: {response.StatusCode}");
    }

    private static async Task CreateSession(string path, PlayerClient playerClient, string nameGame)
    {
        _seaBattleGameSession = new SeaBattleGameSession();
        _seaBattleGameSession.PlayerHost = playerClient;
        _seaBattleGameSession.Name = nameGame;
        using HttpResponseMessage response = await client.PostAsJsonAsync(path, _seaBattleGameSession);
        Console.WriteLine($"Status code: {response.StatusCode}");
    }

    private static async Task GetAllSession(string path, string idSession)
    {
        using HttpResponseMessage response = await client.PostAsJsonAsync(path, idSession);
        Console.WriteLine($"Status code: {response.StatusCode}");
    }

    private static void Information()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("____________________________");
        Console.WriteLine(
            "[Enter] - Register a player (Once after the server starts)" +
            "\n[F1]  - Player's name, id and registration time" +
            "\n[F2]  - Host a session" +
            "\n[F3]  - Get sessionы" +
            "\n[Esc] - EXIT");
        Console.WriteLine("____________________________");
        Console.ResetColor();
    }
}
//private static async Task GetNameGame(string path)
//{
//    using HttpResponseMessage response = await client.GetAsync(path);
//    var jsonMes = await response.Content.ReadAsStringAsync();
//    Console.WriteLine("The name of the game:" + jsonMes);
//}//await GetNameGame("https://localhost:7109/api/PlayerClient/GameName");