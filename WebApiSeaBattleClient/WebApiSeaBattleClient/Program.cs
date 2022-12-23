using ConsoleGameFillerForClient;
using ConsoleGameForClient;
using Newtonsoft.Json;
using SeaBattle.ApiClientModels.Models;
using System.Net.Http.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var consoleGameSeaBattle = new ConsoleGameSeaBattle();
        await consoleGameSeaBattle.Start();

        Console.ReadLine();
    }
}
