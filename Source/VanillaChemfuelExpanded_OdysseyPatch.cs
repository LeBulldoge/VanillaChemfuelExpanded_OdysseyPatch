using HarmonyLib;
using Verse;

namespace VanillaChemfuelExpanded_OdysseyPatch
{
    [StaticConstructorOnStartup]
    public static class VanillaChemfuelExpanded_OdysseyPatch
    {
        static VanillaChemfuelExpanded_OdysseyPatch()
        {
            Log.Message("Hello, world!");
#if DEBUG
            Harmony.DEBUG = true;
#endif
            var harmony = new Harmony("Bulldog.VanillaChemfuelExpanded_OdysseyPatch");
            harmony.PatchAll();
        }
    }

    public class ModExtension : ThingComp
    {
    }
}