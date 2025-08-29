using StardewModdingAPI;
using HarmonyLib;
using StardewModdingAPI.Events;

namespace HeartGate;

public class ModEntry : Mod
{

    /// <summary>
    /// Mod entrypoint
    /// </summary>
    /// <param name="helper"></param>
    public override void Entry(IModHelper helper)
    {
        // Wire up i18n
        I18n.Init(helper.Translation);
        
        var harmony = new Harmony(this.ModManifest.UniqueID);
        HeartGatePatches.Initialize(harmony, Monitor, helper);
    }

    private void OnGameLaunched(object sender, GameLaunchedEventArgs e)
    {
        var contentPatcherApi = this.Helper.ModRegistry.GetApi<ContentPatcher.IContentPatcherAPI>("Pathoschild.ContentPatcher");
        
        // TODO: Register content patcher tokens for formatting events for heart gates
    }
}