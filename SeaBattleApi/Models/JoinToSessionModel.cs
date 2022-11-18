using System.ComponentModel.DataAnnotations;

namespace SeaBattleApi.Models
{
    public class JoinToSessionModel
    {
        [Required]
        public string Player { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}
