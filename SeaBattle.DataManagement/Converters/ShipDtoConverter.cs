using Newtonsoft.Json;
using SeaBattle.DataManagement.Models;

namespace SeaBattle.DataManagement.Converters
{
    public static class ShipDtoConverter
    {
        public static Ship ConvertToShip(this ShipDto shipDto)
        {
            var ship = new Ship(Convert.ToInt32(shipDto.Length));

            var decks = JsonConvert.DeserializeObject<List<CellDto>>(shipDto.DecksJson);

            foreach (var deck in decks)
            {
                if (deck.IsDead == false)
                {
                    ship.PutDeck(deck.Y, deck.X);
                }
            }

            return ship;
        }
        public static List<Ship> ConvertToListShip(this List<ShipDto> shipsFromDto)
        {
            var shipsDomain = new List<Ship>();

            foreach (var ship in shipsFromDto)
            {
                shipsDomain.Add(ship.ConvertToShip());
            }

            return shipsDomain;
        }
    }
}
