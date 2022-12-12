using SeaBattle.ApiClientModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace XUnitTests
{
    public class TestSessionController
    {
        [Fact]
        public async Task TestGetAllWaitingSessions_GetSessions_ReturnStatusCodeOk()
        {
            //pre
            HttpClient client = new HttpClient();
            string path = "https://localhost:7109/api/Session/GetAllWaitingSessions";
            //act
            using HttpResponseMessage response = await client.GetAsync(path);
            //assert
            Assert.Equal(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task TestGetAllWaitingSessions_GetSessions_ReturnListHostSessionClientModel()
        {
            //pre
            HttpClient client = new HttpClient();
            string path = "https://localhost:7109/api/Session/GetAllWaitingSessions";
            var list = new List<HostSessionClientModel>();
            //act
            using HttpResponseMessage response = await client.GetAsync(path);
            var json = await response.Content.ReadFromJsonAsync<List<HostSessionClientModel>>();
            //assert
            Assert.Equal(list.GetType(), json.GetType());
        }
    }
}
