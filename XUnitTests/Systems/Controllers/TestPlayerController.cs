using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SeaBattle.Api.Controllers;
using Xunit;

namespace XUnitTests.Systems.Controllers
{
    public class TestPlayerController
    {
        [Fact]
        public void RegisterPlayer_Success_ReturnsStatusCode200()
        {
            //pre
            var mockPlayerService = new Mock<IPlayerService>();
            var sut = new PlayerController(mockPlayerService.Object);
            //act
            var result = (OkResult)sut.Register("Vanya");
            //assert
            result.StatusCode.
                Should().
                Be(200);
        }

    }
}