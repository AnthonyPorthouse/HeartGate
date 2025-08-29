using System.Collections;
using StardewValley;

namespace HeartGate;

public class HeartGate
{
    private String Name { get; set; }

    private Dictionary<uint, String> GateEvents { get; } = new();

    public Boolean HasHeartGate(uint heartSteps)
    {
        return GateEvents.ContainsKey(heartSteps);
    }
    
    public String GetHeartGateEvent(uint heartSteps)
    {
        return GateEvents[heartSteps];
    }
}