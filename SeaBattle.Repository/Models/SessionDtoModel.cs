﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Repository.Models
{
    public class SessionDtoModel
    {
        [Required]
        public string HostPlayerName { get; set; }// может должен быть класс?
        [Required]
        public string JoinPlayerName { get; set; } = "NoName";// может должен быть класс?
        [Required]
        public string SessionName { get; set; }
    }
}