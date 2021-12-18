using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Batteryno
{
    public static class Power
    {
        private const string CLASS_PATH = "/sys/class/power_supply/";
        public static IEnumerable<Battery> GetBatteries()
        {
            List<Battery> batteries = new List<Battery>();
            IEnumerable<string> bats = Directory.EnumerateDirectories(CLASS_PATH, "BAT*");
            foreach (string battery in bats)
            {
                batteries.Add(new Battery(battery));
            }
            return batteries;
        }

        public static PowerSupply GetPowerSupply()
        {
            string path = Path.Combine(CLASS_PATH, "AC");
            if (Directory.Exists(path))
                return new PowerSupply(path);

            throw new NotSupportedException("The current machine does not support power monitoring");
        }
    }
}