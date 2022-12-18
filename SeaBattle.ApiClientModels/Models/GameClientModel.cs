using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.ApiClientModels.Models
{
    public class GameClientModel
    {
        public string[][] ClientPlayArea { get; set; }

        public bool IsGameStarted { get; set; }

        public bool PlayerTurnToShoot { get; set; }

        public string Message { get; set; }

        public GameClientModel()
        {

        }
    }
}