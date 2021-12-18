using System;
using System.Linq;
using Batteryno;

namespace Batteryno.Example
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var batteries = Power.GetConnectedBatteries();
            if (batteries.Count() == 0)
            {
                Console.WriteLine("No batteries found.");
            }
            else
            {
                for (int i = 0; i < batteries.Count(); i++)
                {
                    var batt = batteries.ElementAt(i);
                    Console.WriteLine($"Battery path: {batt.BatteryPath}");
                    Console.WriteLine($"Battery capacity: {batt.Capacity}%");
                    Console.WriteLine($"Battery capacity level: {batt.CapacityLevel}");
                    Console.WriteLine($"Battery energy when full: {batt.FullEnergy} uWh");
                    Console.WriteLine($"Battery energy when full and new: {batt.FullDesignEnergy} uWh");
                    Console.WriteLine($"Battery energy: {batt.Energy} uWh");
                }
            }
        }
    }
}