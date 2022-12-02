using System.ComponentModel.DataAnnotations;

namespace SeaBattle.Application.Models
{
    public class NewSessionModel
    {
        [Required]
        public string HostPlayerName { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}
