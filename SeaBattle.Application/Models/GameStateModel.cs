using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Models
{
    public class GameStateModel
    {
        public IPlayer Player1 { get; set; }

        public IPlayer Player2 { get; set; }

        public string NameSession { get; set; }

        public string NamePlayerTurn { get; set; }

        public bool IsGameOn { get; set; }

        public string GameMessage { get; set; }

        public GameStateModel(IPlayer player1, IPlayer player2, string nameSession, string namePlayerTurn, bool isGameOn, string gameMessage)
        {
            Player1 = player1;
            Player2 = player2;
            NameSession = nameSession;
            NamePlayerTurn = namePlayerTurn;
            IsGameOn = isGameOn;
            GameMessage = gameMessage;
        }
    }
}
