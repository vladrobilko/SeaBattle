using ConsoleGameForClient;

class Program
{
    static async Task Main(string[] args)
    {
        var consoleGameSeaBattle = new ConsoleGameSeaBattle();
        await consoleGameSeaBattle.Start();
    }
}
