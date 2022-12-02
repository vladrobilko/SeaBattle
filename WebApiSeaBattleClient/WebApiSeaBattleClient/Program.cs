using SeaBattle.ApiClientModels;
using System.IO;
using System.Net.Http.Json;

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
                await CreatePlayer("https://localhost:7109/api/Player/RegisterNewPlayer", "Vasya");
            }
            else if (key == ConsoleKey.M)
            {
                await CreatePlayer("https://localhost:7109/api/Player/RegisterNewPlayer", "Igor");
            }
            else if (key == ConsoleKey.F1)
            {
                await HostNewSession("https://localhost:7109/api/Session/StartNewSession", "Vasya", "SeaBattle");
            }

            else if (key == ConsoleKey.F2)
            {
                await GetAllSession("https://localhost:7109/api/Session/GetAllWaitingSessions");
            }

            else if (key == ConsoleKey.F3)
            {
                await JoinToSession("https://localhost:7109/api/Session/JoinToSession", "Vasya", "SeaBattle");
            }

            else if (key == ConsoleKey.F4)
            {
                await StartGame("https://localhost:7109/api/Session/StartGame");

            }
        }
    }

    private static readonly HttpClient client = new HttpClient();

    private static async Task CreatePlayer(string path, string playerName)
    {
        using HttpResponseMessage response = await client.PostAsJsonAsync(path, playerName);
        Console.WriteLine($"Status code: {response.StatusCode}");
    }

    private static async Task HostNewSession(string path, string namePlayer, string namesession)
    {
        var newSession = new NewSessionClientModel() { HostPlayerName = namePlayer, SessionName = namesession };
        using HttpResponseMessage response = await client.PostAsJsonAsync(path, newSession);
        Console.WriteLine(response.StatusCode);
    }

    private static async Task GetAllSession(string path)
    {
        using HttpResponseMessage response = await client.GetAsync(path);
        var jsonMes = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Isessions informations" + jsonMes);
    }

    private static async Task JoinToSession(string path, string namePlayer, string namesession)
    {
        var join = new JoinToSessionClientModel() { JoinPlayerName = namePlayer, SessionName = namesession };
        using HttpResponseMessage response = await client.PostAsJsonAsync(path, join);
        Console.WriteLine(response.StatusCode);
    }


    private static async Task StartGame(string path)
    {
        using HttpResponseMessage response = await client.GetAsync(path);
        //string[,] playArea = await response.Content.();
    }



    private static void Information()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("____________________________");
        Console.WriteLine(
            "[Enter] - Register first player Vasya (Once after the server starts)" +
            "\n[M] - Register second player Igor (Once after the server starts)" +
            "\n[F1]  - Host a session" +
            "\n[F2]  - Get free sessions" +
            "\n[F3]  - join to session" +
            "\n[F3]  - Start game" +
            "\n[Esc] - EXIT");
        Console.WriteLine("____________________________");
        Console.ResetColor();
    }
}