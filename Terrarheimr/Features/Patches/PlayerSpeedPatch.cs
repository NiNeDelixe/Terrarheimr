using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terrarheimr.Features.Effects;

namespace Terrarheimr.Features.Patches
{
    [HarmonyPatch(typeof(Player), nameof(Player.GetJogSpeedFactor))] //GetRunSpeedFactor
    public static class PlayerJogSpeedPatch
    {
        private static void Postfix(Player __instance, ref float __result)
        {
            if (AgletEffect.IsEquipped)
                __result *= AgletEffect.SpeedMultiplier;
        }
    }

    [HarmonyPatch(typeof(Player), nameof(Player.GetRunSpeedFactor))]
    public static class PlayerRunSpeedPatch
    {
        private static void Postfix(Player __instance, ref float __result)
        {
            if (AgletEffect.IsEquipped)
                __result *= AgletEffect.SpeedMultiplier;
        }
    }
}
