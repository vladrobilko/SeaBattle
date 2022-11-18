using System.ComponentModel.DataAnnotations;

namespace SeaBattleApi.Models
{
    public class NewSessionModel
    {
        [Required]
        public string HostPlayerName { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}
