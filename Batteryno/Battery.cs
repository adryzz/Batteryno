
using System;
using System.IO;
using Batteryno;

public class Battery
{
    /// <summary>
    /// The path of the battery.
    /// </summary>
    public string BatteryPath { get; }
    
    /// <summary>
    /// The battery capacity (percentage)
    /// </summary>
    public int Capacity => int.Parse(readValue(Path.Combine(BatteryPath, "capacity")));

    /// <summary>
    /// The battery capacity level
    /// </summary>
    public CapacityLevel CapacityLevel => Enum.Parse<CapacityLevel>(readValue(Path.Combine(BatteryPath, "capacity_level")));

    /// <summary>
    /// The battery energy when full (uWh)
    /// </summary>
    public long FullEnergy => long.Parse(readValue(Path.Combine(BatteryPath, "energy_full")));

    /// <summary>
    /// The battery energy when full and new (uWh)
    /// </summary>
    public long FullDesignEnergy => long.Parse(readValue(Path.Combine(BatteryPath, "energy_full_design")));

    /// <summary>
    /// The battery energy (uWh)
    /// </summary>
    public long Energy => long.Parse(readValue(Path.Combine(BatteryPath, "energy_now")));
    
    /// <summary>
    /// The battery voltage (uV)
    /// </summary>
    public long Voltage => long.Parse(readValue(Path.Combine(BatteryPath, "voltage_now")));
    
    /// <summary>
    /// The minimum battery voltage (uV)
    /// </summary>
    public long MinimumVoltage => long.Parse(readValue(Path.Combine(BatteryPath, "voltage_min_design")));
    
    /// <summary>
    /// The number of charge cycles that happened
    /// </summary>
    public int ChargeCycles => int.Parse(readValue(Path.Combine(BatteryPath, "cycle_count")));
    
    /// <summary>
    /// The status of the battery
    /// </summary>
    public BatteryStatus Status => Enum.Parse<BatteryStatus>(readValue(Path.Combine(BatteryPath, "status")));
    
    /// <summary>
    /// The type of battery
    /// </summary>
    public PowerSourceType Type => Enum.Parse<PowerSourceType>(readValue(Path.Combine(BatteryPath, "type")));
    
    /// <summary>
    /// The type of battery
    /// </summary>
    public BatteryTechnology Technology => parseTechnology(readValue(Path.Combine(BatteryPath, "technology")));
    
    /// <summary>
    /// The battery manufacturer
    /// </summary>
    public string Manufacturer => readValue(Path.Combine(BatteryPath, "manufacturer")).ReplaceLineEndings("");
    
    /// <summary>
    /// The battery's model name
    /// </summary>
    public string ModelName => readValue(Path.Combine(BatteryPath, "model_name").ReplaceLineEndings(""));
    
    /// <summary>
    /// The battery's serial number
    /// </summary>
    public string SerialNumber => readValue(Path.Combine(BatteryPath, "serial_number").ReplaceLineEndings(""));
    
    /// <summary>
    /// Whether the battery is present or not
    /// </summary>
    /// <remarks>
    /// Should always be true on most systems
    /// </remarks>
    public bool Present => int.Parse(readValue(Path.Combine(BatteryPath, "present"))) != 0;

    internal Battery(string path)
    {
        if (!Directory.Exists(path))
        {
            throw new InvalidOperationException("The specified battery isn't present in the system");
        }
        BatteryPath = path;
    }

    private BatteryTechnology parseTechnology(string technology)
    {
        switch (technology.ReplaceLineEndings(""))
        {
            case "Li-ion":
                return BatteryTechnology.LithiumIon;
        }

        return BatteryTechnology.Unknown;
    }

    private string readValue(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            throw new InvalidOperationException("The specified battery isn't present in the system");
        }
    }
}