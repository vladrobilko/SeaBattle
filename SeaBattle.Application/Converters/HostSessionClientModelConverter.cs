﻿using SeaBattle.ApiClientModels.Models;
using SeaBattle.Application.Models;

namespace SeaBattle.Application.Converters
{
    public static class HostSessionClientModelConverter
    {
        public static HostSessionModel ToHostSessionModel(this HostSessionClientModel hostSessionClientModel)
        {
            return new HostSessionModel() 
            { 
                NameHostPlayer = hostSessionClientModel.HostPlayerName, 
                NameSession = hostSessionClientModel.SessionName 
            };
        }
    }
}