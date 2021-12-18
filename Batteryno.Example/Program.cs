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
                    Console.WriteLine($"Battery voltage: {batt.Voltage} uV");
                    Console.WriteLine($"Battery minimum voltage: {batt.MinimumVoltage} uV");
                    Console.WriteLine($"Charge cycles: {batt.ChargeCycles}");
                    Console.WriteLine($"Status: {batt.Status}");
                    Console.WriteLine($"Battery type: {batt.Type}");
                    Console.WriteLine($"Battery technology: {batt.Technology}");
                    Console.WriteLine($"Manufacturer: {batt.Manufacturer}");
                    Console.WriteLine($"Model name: {batt.ModelName}");
                    Console.WriteLine($"Serial number: {batt.SerialNumber}");
                    Console.WriteLine($"Is present: {batt.Present}");
                }
            }
        }
    }
}