using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.DataManagement.Models
{
    public partial class CellDto
    {
        public long Id { get; set; }

        public long IdShip { get; set; }

        public long CoordinateY { get; set; }

        public long CoordinateX { get; set; }

        public bool IsDead { get; set; }

        public virtual ShipDto IdShipNavigation { get; set; }
    }
}
