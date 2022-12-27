using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.ApiClientModels.Models
{
    public class PlayerRegistrationClientModel
    {
        [Required]
        public string NamePlayer { get; set; }

        public PlayerRegistrationClientModel() { }
    }
}
