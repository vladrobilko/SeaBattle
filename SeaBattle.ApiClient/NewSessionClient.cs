using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.ApiClientModels
{
    public class NewSessionClient
    {
        [Required]
        public string HostPlayerName { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}
