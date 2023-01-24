using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.DataManagement.Models
{
    public partial class Ship
    {
        public long Id { get; set; }

        public long IdPlayarea { get; set; }

        public long Length { get; set; }

        public virtual Playarea IdPlayareaNavigation { get; set; }

        public virtual ICollection<Cell> Cells { get; } = new List<Cell>();
    }
}
