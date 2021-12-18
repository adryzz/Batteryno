using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Batteryno
{
    public static class Power
    {
        private const string CLASS_PATH = "/sys/class/power_supply/";
        public static IEnumerable<Battery> GetConnectedBatteries()
        {
            List<Battery> batteries = new List<Battery>();
            IEnumerable<string> bats = Directory.EnumerateDirectories(CLASS_PATH, "BAT*");
            foreach (string battery in bats)
            {
                batteries.Add(new Battery(battery));
            }
            return batteries;
        }
    }
}