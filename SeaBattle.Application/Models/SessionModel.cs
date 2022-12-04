using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Models
{
    public class SessionModel
    {
        [Required]
        public string HostPlayerName { get; set; }
        [Required]
        public string JoinPlayerName { get; set; } = "NoName";
        [Required]
        public string SessionName { get; set; }
    }
}
