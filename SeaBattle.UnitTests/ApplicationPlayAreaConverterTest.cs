using Microsoft.Extensions.Options;
using SeaBattle.Application.Converters;
using System.Linq;
using System.Text;

namespace SeaBattle.UnitTests
{
    public class ApplicationPlayAreaConverterTest
    {
        private string ConvertPlayAreaToString(PlayArea playArea)
        {
            var stringPlayArea = "";
            for (int i = 0; i < playArea.Height; i++)
            {
                for (int j = 0; j < playArea.Width; j++)
                {
                    stringPlayArea += playArea.Cells[i, j].State.ToStringWithAllCell();
                }
            }
            return stringPlayArea;
        }

        [Test]
        public void TestLinq2DArrayToString_Convert2DArrayToString_ReturnEqual()
        {
            //Prep
            var player = new PlayerEasyBot(new FillerRandom());
            player.FillShips();
            var playArea = player.GetPlayArea();
            //Act
            var stringPlayArea = ConvertPlayAreaToString(playArea);

            string playAreaStringLinq = string.Join("",
                Enumerable.Range(0, 10)
                .SelectMany(i => Enumerable.Range(0, 10)
                    .Select(j => playArea.Cells[i, j].State.ToStringWithAllCell())));
            //Test
            Assert.AreEqual(stringPlayArea, playAreaStringLinq);
        }

        [Test]
        public void TestLinq2DArrayToStringWithEnumerator_Convert2DArrayToString_ReturnEqual()
        {
            //Prep
            var player = new PlayerEasyBot(new FillerRandom());
            player.FillShips();
            var playArea = player.GetPlayArea();
            //Act
            var stringPlayArea = ConvertPlayAreaToString(playArea);

            var enumerStr =  new StringBuilder("");

            var stringi = string.Join("", playArea.Select(p => p.State.ToStringWithAllCell()));

            //Test
            Assert.AreEqual(stringPlayArea, stringi);
        }
    }
}