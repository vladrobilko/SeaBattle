using System.Collections.Generic;

namespace SeaBattle
{
    public class Ship
    {
        public List<Cell> _decks { get; set; }

        public int Length { get; set; }

        public Ship(int length)
        {
            _decks = new List<Cell>();
            Length = length;
        }

        public void PutDeck(int Y, int X)
        {
            _decks.Add(new Cell(Y, X));
        }
    }
}