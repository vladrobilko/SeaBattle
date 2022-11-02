using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using SeaBattle;


class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        await GetNameGameAsync("https://localhost:7109/api/SeaBattleGame/GameName");        
    }
    static async Task GetNameGameAsync(string path)
    {
        HttpResponseMessage response = await client.GetAsync(path);
        var jsonMes = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonMes);        
    }    
}
