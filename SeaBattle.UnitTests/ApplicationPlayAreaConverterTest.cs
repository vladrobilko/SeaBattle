using SeaBattle.Application.Converters;
using System.Linq;

namespace SeaBattle.UnitTests
{
    public class ApplicationPlayAreaConverterTest
    {
        [Test]
        public void ConvertToString()
        {
            //Prep
            var player = new PlayerEasyBot(new FillerRandom());
            //Act
            player.FillShips();
            var playArea = player.GetPlayArea();
            var playAreaStringWithoutLinq = playArea.ConvertToString();

            string playAreaStringLinq = string.Join("",
                Enumerable.Range(0, 10)
                .SelectMany(i => Enumerable.Range(0, 10)
                    .Select(j => playArea.Cells[i, j].State.ToStringWithAllCell())));
            //Test
            Assert.AreEqual(playAreaStringWithoutLinq, playAreaStringLinq);
        }
    }
}