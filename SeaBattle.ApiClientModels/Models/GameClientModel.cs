using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.ApiClientModels.Models
{
    public class GameClientStateModel
    {
        public string[][] ClientPlayArea { get; set; }

        public string[][] EnemyPlayArea { get; set; }

        public bool IsGameOn { get; set; }

        public string NamePlayerTurn { get; set; }

        public string Message { get; set; }

        public GameClientStateModel()
        {

        }
    }
}