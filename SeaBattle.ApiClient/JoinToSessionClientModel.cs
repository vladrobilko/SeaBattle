using System.ComponentModel.DataAnnotations;

namespace SeaBattle.ApiClientModels
{
    public class JoinToSessionClientModel
    {
        [Required]
        public string JoinPlayerName { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}