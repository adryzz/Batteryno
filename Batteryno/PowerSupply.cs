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
        public PowerSourceType Type => Enum.Parse<PowerSourceType>(readValue(Path.Combine(PowerSupplyPath, "type")));
        
        /// <summary>
        /// Whether the power source is connected or not
        /// </summary>
        public bool Online => int.Parse(readValue(Path.Combine(PowerSupplyPath, "online"))) != 0;

        internal PowerSupply(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new InvalidOperationException("The specified power supply isn't present in the system");
            }
            PowerSupplyPath = path;
        }
        
        private string readValue(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (FileNotFoundException)
            {
                throw new InvalidOperationException("The specified power supply isn't present in the system");
            }
        }
    }
}