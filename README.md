# Batteryno

An easy to use C# power library for linux.

# Getting battery percentage

```csharp
using Batteryno;

Battery myBattery = Power.GetBatteries().FirstOrDefault();

Console.WriteLine($"Battery percentage: {myBattery.Capacity}%");
```

You can also find an example [here](Batteryno.Example/Program.cs).
