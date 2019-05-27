using System;
using EShopAPI.Services.Interfaces;

namespace EShopAPI.Services
{
    public class TimeService : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}