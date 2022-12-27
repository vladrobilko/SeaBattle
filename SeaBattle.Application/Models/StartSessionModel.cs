using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Models
{
    public class StartSessionModel
    {
        public string NameHostPlayer { get; set; }

        public string NameJoinPlayer { get; set; }

        public string NameSession { get; set; }
    }
}
