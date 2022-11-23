using System.ComponentModel.DataAnnotations;

namespace SeaBattle.infrastructure.Models
{
    public class JoinToSessionDto
    {
        [Required]
        public string JoinPlayerName { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}
