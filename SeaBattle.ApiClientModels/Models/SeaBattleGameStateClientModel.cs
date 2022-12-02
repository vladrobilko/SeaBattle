using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.ApiClientModels.Models
{
    public class SeaBattleGameStateClientModel
    {
        public string[,] ClientGameArea { get; set; }
        public string[,] EnemyGameArea { get; set; }
        public string MessageToClient { get; set; }
    }
}