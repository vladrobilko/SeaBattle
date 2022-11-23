using System.ComponentModel.DataAnnotations;

namespace SeaBattle.infrastructure.Models
{
    public class JoinToSessionDtoModel
    {
        [Required]
        public string JoinPlayerName { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}
