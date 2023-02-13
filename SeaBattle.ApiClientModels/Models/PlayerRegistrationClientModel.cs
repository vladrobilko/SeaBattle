using System.ComponentModel.DataAnnotations;

namespace SeaBattle.ApiClientModels.Models
{
    public class PlayerRegistrationClientModel
    {
        [Required]
        public string? NamePlayer { get; set; }
    }
}
