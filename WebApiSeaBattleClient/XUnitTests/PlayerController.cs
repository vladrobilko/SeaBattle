using System.Net.Http.Json;
using Xunit;

namespace XUnitTests
{
    public class PlayerController
    {
        [Theory]
        [InlineData("Vanya")]
        [InlineData("Petya")]
        [InlineData("Alyosha")]
        public async Task GetRegister_RegisterPlayer_ReturnsStatusCodeOk(string name)
        {
            //pre
            HttpClient client = new HttpClient();
            string path = "https://localhost:7109/api/Player/Register";
            //act
            using HttpResponseMessage response = await client.PostAsJsonAsync(path, name);
            //assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetRegister_RegisterSameNamePlayer_ReturnsStatusCodeBadRequest()
        {
            //pre
            HttpClient client = new HttpClient();
            string path = "https://localhost:7109/api/Player/Register";
            string name = "Petr";
            //act
            using HttpResponseMessage response1 = await client.PostAsJsonAsync(path, name);
            using HttpResponseMessage response2 = await client.PostAsJsonAsync(path, name);
            //assert
            Assert.Equal(response2.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

    }
}