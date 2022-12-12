using System.Net.Http.Json;
using Xunit;

namespace XUnitTests
{
    public class TestPlayerController
    {
        [Theory]
        [InlineData("Vanya")]
        [InlineData("Petya")]
        [InlineData("Alyosha")]
        public async Task TestGetRegister_RegisterPlayer_ReturnStatusCodeOk(string name)
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
        public async Task TestGetRegister_RegisterSameNamePlayer_ReturnStatusCodeBadRequest()
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