using HarmonyLib;
using PipeSystem;
using Verse;

namespace VanillaChemfuelExpanded_OdysseyPatch
{
    [HarmonyPatch(typeof(CompResourceStorage), nameof(CompResourceStorage.PostExposeData))]
    public class CompResourceStorage_PostExposeData
    {
        public static void Postfix(CompResourceStorage __instance)
        {
            if (__instance.AmountStored != 0)
                return;

            var fuel = 0.0f;
            Scribe_Values.Look(ref fuel, "fuel");

            __instance.AddResource(fuel);
        }
    }
}