﻿using SeaBattle.ApiClientModels.Models;
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
            HttpClient client = new HttpClient();
            //act
            using HttpResponseMessage response = await client.GetAsync(pathGetAllSessions);
            //assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task TestB_PostHostSession_HostSession_ReturnStatusCodeOk()
        {
            //pre
            HttpClient client = new HttpClient();
            string namePlayer = "Test2";
            string nameSession = "SessionTest2";
            //act
            await client.PostAsJsonAsync(pathRegisterPlayer, namePlayer);

            using HttpResponseMessage response = await client.PostAsJsonAsync(
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
            HttpClient client = new HttpClient();
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

            using HttpResponseMessage getAllSessions = await client.GetAsync(pathGetAllSessions);
            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, getAllSessions.StatusCode);
        }

        [Fact]
        public async Task TestD_PostJoinSession_JoinSession_ReturnStatusCodeOk()
        {
            //pre
            HttpClient client = new HttpClient();
            string nameHostPlayer = "Hosttest4";
            string nameJoinPlayer = "Jointest4";
            string nameSession = "Sessiontest4";
            //act
            await client.PostAsJsonAsync(pathRegisterPlayer, nameHostPlayer);

            await client.PostAsJsonAsync(
                pathHostSession, new HostSessionClientModel()
                {
                    HostPlayerName = nameHostPlayer,
                    SessionName = nameSession
                });

            using HttpResponseMessage response = await client.PostAsJsonAsync(
                pathJoinSession, new JoinSessionClientModel()
                {
                    JoinPlayerName = nameJoinPlayer,
                    SessionName = nameSession
                });
            //assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
