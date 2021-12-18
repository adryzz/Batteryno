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
            IEnumerable<string> bats = Directory.EnumerateDirectories(CLASS_PATH).Where(x => x.StartsWith("BAT"));
            Console.WriteLine($"Found {bats.Count()} batteries");
            Console.ReadLine();
            return batteries;
        }
    }
}