using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.DataManagement.Converters
{
    public static class MinutesConverter
    {
        public static int ToMilliseconds(this int minutes)
        {
            return minutes * 60000;
        }
    }
}
