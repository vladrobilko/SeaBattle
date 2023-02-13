using System.ComponentModel.DataAnnotations;

namespace SeaBattle.ApiClientModels.Models
{
    public class HostSessionClientModel
    {
        [Required]
        public string? HostPlayerName { get; set; }

        [Required]
        public string? SessionName { get; set; }
    }
}
