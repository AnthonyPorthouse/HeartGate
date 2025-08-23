using System.Collections;
using HarmonyLib;
using StardewModdingAPI;
using StardewValley;

namespace HeartGate;

public class HeartGatePatches
{
    private static IMonitor? _monitor;
    
    public static void Initialize(Harmony harmony, IMonitor monitor, IModHelper modHelper)
    {
        _monitor = monitor;
        
        monitor.Log($"Setting up Patches for HeartGate", LogLevel.Debug);
        
        
        harmony.Patch(
            original: AccessTools.Method(typeof(Utility), nameof(Utility.GetMaximumHeartsForCharacter), new []{ typeof(Character) }),
            postfix: new HarmonyMethod(typeof(HeartGatePatches), nameof(GetMaximumHeartsForCharacter_Postfix))
        );
    }

    public static void GetMaximumHeartsForCharacter_Postfix(Character character, ref int __result)
    {
        if (character == null) return;
        
        _monitor.Log($"Checking {character.Name}");
        
        // TODO:
        // + Check if Character is in list of content patcher controlled event ids
        
        Friendship friendship;
        if (character is NPC npc && npc.datable.Value)
        {
            _monitor.Log($"Locking {npc.Name} to 1");
            
            __result = 1;
            return;
        }
    }
}