using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using SeaBattle;
using System;
using System.IO;
using System.Numerics;
using Microsoft.VisualBasic;

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
                await CreatePlayer("https://localhost:7109/api/SeaBattleGame/Login", "Vasya");
            }
            else if (key == ConsoleKey.F1)
            {
                await GetPlayerInformation("https://localhost:7109/api/SeaBattleGame/GetPlayerInfo");
            }

            else if (key == ConsoleKey.F2)
            {
                await GetNameGame("https://localhost:7109/api/SeaBattleGame/GameName");
            }    
        }
        Environment.Exit(0);
    }
    private static readonly HttpClient client = new HttpClient();

    private static PlayerClientService _player;

    private static async Task CreatePlayer(string path, string playerName)
    {
        using HttpResponseMessage response = await client.PostAsJsonAsync(path, new PlayerClientService() { Name = playerName });
        Console.WriteLine($"Status code: {response.StatusCode}");
    }

    private static async Task GetPlayerInformation(string path)
    {
        using HttpResponseMessage response = await client.GetAsync(path);
        _player = await response.Content.ReadFromJsonAsync<PlayerClientService>();
        if (_player != null)
        {
            Console.WriteLine($"Name: {_player.Name}, ID: {_player.ID}, time adding: {_player.TimeAdding}");
            return;
        }
        Console.WriteLine($"The player isn't created. Error: {response.StatusCode}");
    }

    private static async Task GetNameGame(string path)
    {
        using HttpResponseMessage response = await client.GetAsync(path);
        var jsonMes = await response.Content.ReadAsStringAsync();
        Console.WriteLine("The name of the game:" + jsonMes);
    }

    private static void Information()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("____________________________");
        Console.WriteLine(
            "[Enter] - Register a player (Once after the server starts)" +
            "\n[F1]  - Player's name, id and registration time" +
            "\n[F2]  - The name of the game" +
            "\n[Esc] - EXIT");
        Console.WriteLine("____________________________");
        Console.ResetColor();
    }
}
