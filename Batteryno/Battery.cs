
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
    public int Capacity { get; protected set; }

    /// <summary>
    /// The battery capacity level
    /// </summary>
    public CapacityLevel CapacityLevel { get; protected set; }

    /// <summary>
    /// The battery energy when full (uWh)
    /// </summary>
    public long FullEnergy { get; protected set; }

    /// <summary>
    /// The battery energy when full and new (uWh)
    /// </summary>
    public long FullDesignEnergy { get; protected set; }

    /// <summary>
    /// The battery energy (uWh)
    /// </summary>
    public long Energy { get; protected set; }
    
    /// <summary>
    /// The battery voltage (uV)
    /// </summary>
    public long Voltage { get; protected set; }
    
    /// <summary>
    /// The minimum battery voltage (uV)
    /// </summary>
    public long MinimumVoltage { get; protected set; }
    
    /// <summary>
    /// The number of charge cycles that happened
    /// </summary>
    public int ChargeCycles { get; protected set; }
    
    /// <summary>
    /// The status of the battery
    /// </summary>
    public BatteryStatus Status { get; protected set; }
    
    /// <summary>
    /// The type of battery
    /// </summary>
    public BatteryType Type { get; protected set; }
    
    /// <summary>
    /// The type of battery
    /// </summary>
    public BatteryTechnology Technology { get; protected set; }
    
    /// <summary>
    /// The battery manufacturer
    /// </summary>
    public string Manufacturer { get; protected set; }
    
    /// <summary>
    /// The battery's model name
    /// </summary>
    public string ModelName { get; protected set; }
    
    /// <summary>
    /// The battery's serial number
    /// </summary>
    public string SerialNumber { get; protected set; }
    
    /// <summary>
    /// Whether the battery is present or not
    /// </summary>
    /// <remarks>
    /// Should always be true on most systems
    /// </remarks>
    public bool Present { get; protected set; }

    internal Battery(string path)
    {
        BatteryPath = path;
        refresh();
    }

    public void Refresh()
    {
        if (!Directory.Exists(BatteryPath))
        {
            throw new InvalidOperationException("The specified battery isn't present in the system");
        }
        refresh();
    }

    protected virtual void refresh()
    {
        Capacity = int.Parse(File.ReadAllText(Path.Combine(BatteryPath, "capacity")));
        CapacityLevel = Enum.Parse<CapacityLevel>(File.ReadAllText(Path.Combine(BatteryPath, "capacity_level")));
        FullEnergy = long.Parse(File.ReadAllText(Path.Combine(BatteryPath, "energy_full")));
        FullDesignEnergy = long.Parse(File.ReadAllText(Path.Combine(BatteryPath, "energy_full_design")));
        Energy = long.Parse(File.ReadAllText(Path.Combine(BatteryPath, "energy_now")));
        Voltage = long.Parse(File.ReadAllText(Path.Combine(BatteryPath, "voltage_now")));
        MinimumVoltage = long.Parse(File.ReadAllText(Path.Combine(BatteryPath, "voltage_min_design")));
        ChargeCycles = int.Parse(File.ReadAllText(Path.Combine(BatteryPath, "cycle_count")));
        Status = Enum.Parse<BatteryStatus>(File.ReadAllText(Path.Combine(BatteryPath, "status")));
        Type = Enum.Parse<BatteryType>(File.ReadAllText(Path.Combine(BatteryPath, "type")));
        //Technology = Enum.Parse<BatteryTechnology>(convertTechnology(File.ReadAllText(Path.Combine(BatteryPath, "technology"))));
        Manufacturer = File.ReadAllText(Path.Combine(BatteryPath, "manufacturer"));
        ModelName = File.ReadAllText(Path.Combine(BatteryPath, "model_name"));
        SerialNumber = File.ReadAllText(Path.Combine(BatteryPath, "serial_number"));
        Present = bool.Parse(File.ReadAllText(Path.Combine(BatteryPath, "present")));
    }

    private string convertTechnology(string technology)
    {
        switch (technology)
        {
            case "Li-ion":
                return "Li_ion";
        }

        return technology;
    }
}