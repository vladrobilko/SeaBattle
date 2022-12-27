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
        public string HostPlayerName { get; set; }

        public string JoinPlayerName { get; set; } = "NoName";

        public string SessionName { get; set; }
    }
}
