using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.DataManagement.Models
{
    public partial class Cell
    {
        public long Id { get; set; }

        public long IdShip { get; set; }

        public long CoordinateY { get; set; }

        public long CoordinateX { get; set; }

        public bool IsDead { get; set; }

        public virtual Ship IdShipNavigation { get; set; }
    }
}
