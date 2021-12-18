using System;
using System.IO;

namespace Batteryno
{
    public class PowerSupply
    {
        /// <summary>
        /// The path of the power supply
        /// </summary>
        public string PowerSupplyPath { get; }
        
        /// <summary>
        /// The type of power supply
        /// </summary>
        public PowerSourceType Type { get; protected set; }
        
        /// <summary>
        /// Whether the power source is connected or not
        /// </summary>
        public bool Online { get; protected set; }

        internal PowerSupply(string path)
        {
            PowerSupplyPath = path;
            refresh();
        }

        public virtual void Refresh()
        {
            if (!Directory.Exists(PowerSupplyPath))
            {
                throw new InvalidOperationException("The specified power supply isn't present in the system");
            }
            refresh();
        }

        private void refresh()
        {
            Type = Enum.Parse<PowerSourceType>(File.ReadAllText(Path.Combine(PowerSupplyPath, "type")));
            Online = int.Parse(File.ReadAllText(Path.Combine(PowerSupplyPath, "online"))) != 0;
        }
    }
}