using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.ApiClientModels.Models
{
    public class GameClientModel
    {
        public string[][] ClientPlayArea { get; set; }

        public string[][] EnemyPlayArea { get; set; }

        public bool IsGameOn { get; set; }

        public bool IsPlayerTurnToShoot { get; set; }

        public string Message { get; set; }

        public GameClientModel()
        {

        }
    }
}