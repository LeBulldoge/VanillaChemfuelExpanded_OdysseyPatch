using System.Linq;
using HarmonyLib;
using PipeSystem;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace VanillaChemfuelExpanded_OdysseyPatch
{
    [HarmonyPatch(typeof(Building_GravEngine), nameof(Building_GravEngine.ConsumeFuel))]
    public class Building_GravEngine_ConsumeFuel
    {
        public static bool Prefix(Building_GravEngine __instance, PlanetTile tile)
        {
            float cost;
            if (!GravshipUtility.TryGetPathFuelCost(__instance.Map.Tile, tile, out cost, out _))
            {
                Log.Error($"Failed to get the fuel cost from tile ({__instance.Map.Tile}) to {tile}.");
            }
            else
            {
                __instance.TryGetComp(out CompResourceTrader pipeComp);

                pipeComp.PipeNet.DrawAmongStorage(cost, pipeComp.PipeNet.storages);

                var ticksGame = GenTicks.TicksGame;
                var launchInfo = __instance.launchInfo;
                var launchCooldown =
                    (int)GravshipUtility.LaunchCooldownFromQuality(launchInfo != null ? launchInfo.quality : 1f);
                __instance.cooldownCompleteTick = ticksGame + launchCooldown;
            }

            return false;
        }
    }

    [HarmonyPatch(typeof(Building_GravEngine), nameof(Building_GravEngine.MaxFuel), MethodType.Getter)]
    public class Building_GravEngine_MaxFuel
    {
        public static bool Prefix(Building_GravEngine __instance, ref float __result)
        {
            __instance.TryGetComp(out CompResourceTrader comp);

            var maxCapacity =
                comp.PipeNet.storages.Sum(compResourceStorage => compResourceStorage.Props.storageCapacity);

            __result = maxCapacity;

            return false;
        }
    }

    [HarmonyPatch(typeof(Building_GravEngine), nameof(Building_GravEngine.TotalFuel), MethodType.Getter)]
    public class Building_GravEngine_TotalFuel
    {
        public static bool Prefix(Building_GravEngine __instance, ref float __result)
        {
            __instance.TryGetComp(out CompResourceTrader comp);

            __result = comp.PipeNet.Stored;

            return false;
        }
    }
}