
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
    /// Battery capacity (percentage)
    /// </summary>
    public int Capacity => _capacity;
    private int _capacity;

    public CapacityLevel CapacityLevel => _capacityLevel;
    private CapacityLevel _capacityLevel;
    
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
    }
}