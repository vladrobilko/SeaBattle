using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.ApiClientModels.Models
{
    public class PlayerClientInfoModel
    {

        [Required]
        public string PlayerName { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}
