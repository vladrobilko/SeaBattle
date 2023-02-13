﻿using Newtonsoft.Json;
using SeaBattle.DataManagement.Models;

namespace SeaBattle.DataManagement.Converters
{
    public static class ShipDtoConverter
    {
        public static Ship ToShip(this ShipDto shipDto)
        {
            var ship = new Ship(Convert.ToInt32(shipDto.Length));

            var decks = JsonConvert.DeserializeObject<List<CellDto>>(shipDto.DecksJson);

            decks.Where(d => !d.IsDead).ToList().ForEach(d => ship.PutDeck(d.Y,d.X));

            return ship;
        }

        public static List<Ship>? ToShips(this List<ShipDto> shipsFromDto)
        {
            return shipsFromDto.Select(p => p.ToShip()).ToList();
        }
    }
}
