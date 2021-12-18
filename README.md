# Batteryno
![Nuget](https://img.shields.io/nuget/v/Batteryno)

An easy to use C# power library for linux.

# Getting battery percentage

```csharp
using Batteryno;

Battery myBattery = Power.GetBatteries().FirstOrDefault();

Console.WriteLine($"Battery percentage: {myBattery.Capacity}%");
```

You can also find an example [here](Batteryno.Example/Program.cs).

## Why did you name it Batteryno?
![](https://i.imgur.com/8qpYNN6.png)
