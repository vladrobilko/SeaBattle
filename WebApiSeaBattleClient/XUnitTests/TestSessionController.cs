using Newtonsoft.Json;
using SeaBattle.ApiClientModels.Models;
using System.Net.Http.Json;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace XUnitTests
{
    [TestCaseOrderer("XUnitTests.AlphabeticalOrderer", "XUnitTests")]
    public class TestSessionController
    {
        string pathGetAllSessions = "https://localhost:7109/api/Session/GetAllWaitingSessions";
        string pathRegisterPlayer = "https://localhost:7109/api/Player/Register";
        string pathHostSession = "https://localhost:7109/api/Session/HostSession";
        string pathJoinSession = "https://localhost:7109/api/Session/JoinSession";

        [Fact]
        public async Task TestA_GetAllWaitingSessions_GetSessionsWithNoAddedWaitingSessions_ReturnStatusCodeBadRequest()
        {
            //pre
            var client = new HttpClient();
            //act
            using var response = await client.GetAsync(pathGetAllSessions);
            //assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task TestB_PostHostSession_HostSession_ReturnStatusCodeOk()
        {
            //pre
            var client = new HttpClient();
            string namePlayer = "Test2";
            string nameSession = "SessionTest2";
            //act
            await client.PostAsJsonAsync(pathRegisterPlayer, namePlayer);

            using var response = await client.PostAsJsonAsync(
                pathHostSession, new HostSessionClientModel()
                {
                    HostPlayerName = namePlayer,
                    SessionName = nameSession
                });
            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestC_GetAllWaitingSessions_AddPlayerHostSessionGetSession_ReturnStatusCodeOk()
        {
            //pre
            var client = new HttpClient();
            string namePlayer = "Test3";
            string nameSession = "SessionTest3";
            //act
            await client.PostAsJsonAsync(pathRegisterPlayer, namePlayer);

            await client.PostAsJsonAsync(
                pathHostSession, new HostSessionClientModel()
                {
                    HostPlayerName = namePlayer,
                    SessionName = nameSession
                });

            var getAllSessions = await client.GetAsync(pathGetAllSessions);
            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, getAllSessions.StatusCode);
        }

        [Fact]
        public async Task TestD_PostJoinSession_JoinSession_ReturnStatusCodeOk()
        {
            //pre
            var client = new HttpClient();
            string nameHostPlayer = "Hosttest4";
            string nameJoinPlayer = "Jointest4";
            string nameSession = "Sessiontest4";
            //act
            await client.PostAsJsonAsync(pathRegisterPlayer, nameHostPlayer);
            await client.PostAsJsonAsync(pathRegisterPlayer, nameJoinPlayer);

            await client.PostAsJsonAsync(pathHostSession,
                new HostSessionClientModel()
                {
                    HostPlayerName = nameHostPlayer,
                    SessionName = nameSession
                });

            using var response = await client.PostAsJsonAsync(pathJoinSession,
                new JoinSessionClientModel()
                {
                    JoinPlayerName = nameJoinPlayer,
                    SessionName = nameSession
                });
            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task TestE_GetAllWaitingSessions_Add2HostSessionGetSession_ReturnListWaitingSessionNotNull()
        {
            //pre
            var client = new HttpClient();
            string namePlayer = "TestE";
            string nameSession = "TestE";
            string namePlayer2 = "TestE2";
            string nameSession2 = "TestE2";

            //act
            await client.PostAsJsonAsync(pathRegisterPlayer, namePlayer);
            await client.PostAsJsonAsync(pathRegisterPlayer, namePlayer2);

            await client.PostAsJsonAsync(
                pathHostSession, new HostSessionClientModel()
                {
                    HostPlayerName = namePlayer,
                    SessionName = nameSession
                });
            await client.PostAsJsonAsync(
           pathHostSession, new HostSessionClientModel()
           {
               HostPlayerName = namePlayer2,
               SessionName = nameSession2
           });

            var response = await client.GetAsync(pathGetAllSessions);
            var json = await response.Content.ReadAsStringAsync();
            var sessions = JsonConvert.DeserializeObject<List<HostSessionClientModel>>(json);
            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(sessions);
        }
    }
}
