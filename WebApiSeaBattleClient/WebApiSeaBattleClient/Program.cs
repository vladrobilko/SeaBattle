using ConsoleGameForClient;

namespace WebApiSeaBattleClient;

class Program
{
    static async Task Main()
    {
        await new ConsoleGameSeaBattle().Start();
    }
}