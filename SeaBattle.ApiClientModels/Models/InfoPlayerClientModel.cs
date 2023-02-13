using System.ComponentModel.DataAnnotations;

namespace SeaBattle.ApiClientModels.Models
{
    public class InfoPlayerClientModel
    {
        [Required]
        public string? PlayerName { get; set; }

        [Required]
        public string? SessionName { get; set; }
    }
}
