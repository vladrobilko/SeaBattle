using System.ComponentModel.DataAnnotations;

namespace SeaBattle.ApiClientModels.Models
{
    public class JoinSessionClientModel
    {
        [Required]
        public string NameJoinPlayer { get; set; }

        [Required]
        public string NameSession { get; set; }
    }
}