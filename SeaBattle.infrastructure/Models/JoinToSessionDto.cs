using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.infrastructure.Models
{
    internal class JoinToSessionDto
    {
        [Required]
        public string Player { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}
