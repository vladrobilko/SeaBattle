using System.Collections.Generic;

namespace SeaBattle
{
    public class Ship
    {
        public List<Cell> Decks { get; set; }

        public int Length { get; set; }

        public Ship(int length)
        {
            Decks = new List<Cell>();
            Length = length;
        }

        public void PutDeck(int y, int x)
        {
            Decks.Add(new Cell(y, x));
        }
    }
}