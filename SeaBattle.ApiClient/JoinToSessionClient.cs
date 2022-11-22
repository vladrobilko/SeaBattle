using System.ComponentModel.DataAnnotations;

namespace SeaBattle.ApiClientModels
{
    public class JoinToSessionClient
    {
        [Required]
        public string Player { get; set; }
        [Required]
        public string SessionName { get; set; }
    }
}