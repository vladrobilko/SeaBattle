using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.ApiClientModels
{
    public class SessionClientModel
    {
        [Required]
        public string HostPlayerName { get; set; }
        [Required]
        public string JoinPlayerName { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}
