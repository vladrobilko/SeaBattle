using System.ComponentModel.DataAnnotations;

namespace SeaBattleApi.Models
{
    public class JoinToSessionModel
    {
        [Required]
        public string JoinPlayerName { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}
