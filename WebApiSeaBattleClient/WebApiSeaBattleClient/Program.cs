using SeaBattle.ApiClientModels.Models;
using System.Net.Http.Json;

class Program
{
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
            "\n[F4]  - Start game" +
            "\n[Esc] - EXIT");
        Console.WriteLine("____________________________");
        Console.ResetColor();
    }

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
                await JoinToSession("https://localhost:7109/api/Session/JoinToSession", "Igor", "SeaBattle");//это не то что то ????
            }

            else if (key == ConsoleKey.F4)
            {
                await StartGame("https://localhost:7109/api/SeaBattleGame/StartGame", "Vasya", "SeaBattle");
            }//   /api/SeaBattleGame/StartGame
        }
    }

    private static readonly HttpClient client = new HttpClient();

    private static async Task CreatePlayer(string path, string playerName)
    {
        using HttpResponseMessage response = await client.PostAsJsonAsync(path, playerName);
        Console.WriteLine($"Status code: {response.StatusCode}. Api exception message: {response.Content.ReadAsStringAsync().Result}");
    }

    private static async Task HostNewSession(string path, string namePlayer, string namesession)
    {
        var newSession = new HostSessionClientModel() { HostPlayerName = namePlayer, SessionName = namesession };
        using HttpResponseMessage response = await client.PostAsJsonAsync(path, newSession);
        Console.WriteLine($"Status code: {response.StatusCode}. Api exception message: {response.Content.ReadAsStringAsync().Result}");
    }

    private static async Task GetAllSession(string path)
    {
        using HttpResponseMessage response = await client.GetAsync(path);
        var jsonMes = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Status code: {response.StatusCode}, Sessions informations + {jsonMes} ." +
            $" \nApi exception message: {response.Content.ReadAsStringAsync().Result}");
    }

    private static async Task JoinToSession(string path, string namePlayer, string namesession)
    {
        var join = new JoinSessionClientModel() { JoinPlayerName = namePlayer, SessionName = namesession };
        using HttpResponseMessage response = await client.PostAsJsonAsync(path, join);
        Console.WriteLine($"Status code: {response.StatusCode}. Api exception message: {response.Content.ReadAsStringAsync().Result}");
    }

    private static async Task StartGame(string path, string namePlayer, string namesession)
    {
        var newSession = new HostSessionClientModel() { HostPlayerName = namePlayer, SessionName = namesession };

        using HttpResponseMessage response = await client.PostAsJsonAsync(path, newSession);

        Console.WriteLine($"Status code: {response.StatusCode}. Api exception message: {response.Content.ReadAsStringAsync().Result}");
        //string[,] playArea = await response.Content.();
    }
}
