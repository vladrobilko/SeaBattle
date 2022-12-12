using System.Net.Http.Json;
using Xunit;

namespace XUnitTests
{
    public class TestPlayerController
    {
        string path = "https://localhost:7109/api/Player/Register";

        [Theory]
        [InlineData("Vanya")]
        [InlineData("Petya")]
        [InlineData("Alyosha")]
        public async Task TestGetRegister_RegisterPlayer_ReturnStatusCodeOk(string name)
        {
            //pre
            var client = new HttpClient();
            //act
            using var response = await client.PostAsJsonAsync(path, name);
            //assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetRegister_RegisterSameNamePlayer_ReturnStatusCodeBadRequest()
        {
            //pre
            var client = new HttpClient();
            string name = "Petr";
            //act
            using var response1 = await client.PostAsJsonAsync(path, name);
            using var response2 = await client.PostAsJsonAsync(path, name);
            //assert
            Assert.Equal(response2.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

    }
}