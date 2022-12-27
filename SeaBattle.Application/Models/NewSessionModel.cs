using System.ComponentModel.DataAnnotations;

namespace SeaBattle.Application.Models
{
    public class NewSessionModel
    {
        public string HostPlayerName { get; set; }

        public string SessionName { get; set; }
    }
}
