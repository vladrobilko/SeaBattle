using System.ComponentModel.DataAnnotations;

namespace SeaBattle.Repository.Models
{
    public class SessionDtoModel
    {
        [Required]
        public string HostPlayerName { get; set; }
        [Required]
        public string JoinPlayerName { get; set; } = "NoName";
        [Required]
        public string SessionName { get; set; }
    }
}