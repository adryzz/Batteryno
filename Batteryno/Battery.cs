
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
    public int Capacity => _capacity;
    private int _capacity;

    /// <summary>
    /// The battery capacity level
    /// </summary>
    public CapacityLevel CapacityLevel => _capacityLevel;
    private CapacityLevel _capacityLevel;

    /// <summary>
    /// The battery energy when full (uWh)
    /// </summary>
    public long FullEnergy => _fullEnergy;
    private long _fullEnergy;
    
    /// <summary>
    /// The battery energy when full and new (uWh)
    /// </summary>
    public long FullDesignEnergy => _fullDesignEnergy;
    private long _fullDesignEnergy;
    
    /// <summary>
    /// The battery energy (uWh)
    /// </summary>
    public long Energy => Energy;
    private long _energy;
    
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

    private void refresh()
    {
        _capacity = int.Parse(File.ReadAllText(Path.Combine(BatteryPath, "capacity")));
        _capacityLevel = Enum.Parse<CapacityLevel>(File.ReadAllText(Path.Combine(BatteryPath, "capacity_level")));
        _fullEnergy = long.Parse(File.ReadAllText(Path.Combine(BatteryPath, "energy_full")));
        _fullDesignEnergy = long.Parse(File.ReadAllText(Path.Combine(BatteryPath, "energy_full_design")));
        _energy = long.Parse(File.ReadAllText(Path.Combine(BatteryPath, "energy_now")));
    }
}