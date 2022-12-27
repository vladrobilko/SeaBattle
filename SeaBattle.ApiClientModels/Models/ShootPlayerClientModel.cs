﻿using System.ComponentModel.DataAnnotations;

namespace SeaBattle.ApiClientModels.Models
{
    public class ShootPlayerClientModel
    {
        [Required]
        public int ShootCoordinateY { get; set; }

        [Required]
        public int ShootCoordinateX { get; set; }

        [Required]
        public string PlayerName { get; set; }

        [Required]
        public string NameSession { get; set; }

        public ShootPlayerClientModel() { }
    }
}
