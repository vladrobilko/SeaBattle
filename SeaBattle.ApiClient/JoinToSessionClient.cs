using System.ComponentModel.DataAnnotations;

namespace SeaBattle.ApiClientModels
{
    public class JoinToSessionClient
    {
        [Required]
        public string JoinPlayerName { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}