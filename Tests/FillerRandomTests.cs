using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using SeaBattle;

namespace Tests
{
    public class FillerRandomTests
    {
        List<ShipConfige> origConf = new List<ShipConfige>()
            { new ShipConfige(1, 4), new ShipConfige(2, 3), new ShipConfige(3, 2), new ShipConfige(4, 1) };

        [Test]        
        [TestCase(10, 10)]
        [Repeat(100)]
        [Timeout(1000)]
        public void TestFillRandomPlayArea_FillPlayArea_ReturnEqual(int playAreaHigth, int playAreaWidth)
        {
            var playArea = new PlayArea(playAreaHigth, playAreaWidth);
            var fill = new FillerRandom();            

            int countDecsMustBe = CountDecksInPlayAreaMustBe(origConf);
            fill.FillShips(playArea.Cells, ShipsCreator.CreatShips(origConf));
            int countDecks = CountDecksInPlayArea(playArea.Cells);

            Assert.AreEqual(countDecks, countDecsMustBe);
        }

        private int CountDecksInPlayArea(Cell[,] cells)
        {
            int countDecks = 0;
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j].State == CellState.BusyDeck)
                    {
                        countDecks++;
                    }
                }
            }
            return countDecks;
        }

        private int CountDecksInPlayAreaMustBe(List<ShipConfige> shipConfiges)
        {
            int countDecsMusBe = 0;
            foreach (var item in shipConfiges)
            {
                countDecsMusBe += item.CountShip * item.LengthShip;
            }
            return countDecsMusBe;
        }
    }
}
