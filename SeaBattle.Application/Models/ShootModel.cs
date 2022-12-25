using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Application.Models
{
    public class ShootModel
    {
        public int ShootCoordinateY { get; set; }

        public int ShootCoordinateX { get; set; }

        public string PlayerName { get; set; }

        public string SessionName { get; set; }

        public ShootModel(int shootCoordinateY, int shootCoordinateX, string playerName, string sessionName)
        {
            ShootCoordinateY = shootCoordinateY;
            ShootCoordinateX = shootCoordinateX;
            PlayerName = playerName;
            SessionName = sessionName;
        }
    }
}
