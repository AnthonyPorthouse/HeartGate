using System.Collections;
using StardewValley;

namespace HeartGate;

public class HeartGate
{
    private String Name { get; set; }

    private Dictionary<HeartSteps, String> GateEvents { get; } = new();

    public Boolean HasHeartGate(HeartSteps heartSteps)
    {
        return GateEvents.ContainsKey(heartSteps);
    }
    
    public String GetHeartGateEvent(HeartSteps heartSteps)
    {
        return GateEvents[heartSteps];
    }
}