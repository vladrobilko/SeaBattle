using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.infrastructure.Models
{
    public class NewSessionDto
    {
        [Required]
        public string HostPlayerName { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}
