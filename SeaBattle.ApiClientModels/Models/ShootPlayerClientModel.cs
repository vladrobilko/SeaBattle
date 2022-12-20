﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.ApiClientModels.Models
{
    public class ShootPlayerClientModel
    {
        [Required]
        public string PlayerName { get; set; }

        [Required]
        public string SessionName { get; set; }

        [Required]
        public int ShootCoordinateY { get; set; }


        [Required]
        public int ShootCoordinateX { get; set; }

        public ShootPlayerClientModel()
        {

        }
    }
}
