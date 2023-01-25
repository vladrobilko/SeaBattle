using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.DataManagement.Models
{
    public partial class ShipDto
    {
        public long Id { get; set; }

        public long IdPlayarea { get; set; }

        public long Length { get; set; }

        public string DecksJson { get; set; }

        public virtual PlayareaDto IdPlayareaNavigation { get; set; }
    }
}
