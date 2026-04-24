#if MONO
using ScheduleOne;
using ScheduleOne.Combat;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerScripts.Health;
using ScheduleOne.Clothing;
using UnityEngine;
#else
using Il2CppScheduleOne;
using Il2CppScheduleOne.Combat;
using Il2CppScheduleOne.PlayerScripts;
using Il2CppScheduleOne.PlayerScripts.Health;
using Il2CppScheduleOne.Clothing;
using UnityEngine;
#endif
using HarmonyLib;
using MelonLoader;
using S1RealisticBulletProofVest.Utils;

namespace S1RealisticBulletProofVest.Integrations
{
    [HarmonyPatch]
    public static class HarmonyPatches
    {
        private static Core? _modInstance;

        public static void SetModInstance(Core modInstance)
        {
            _modInstance = modInstance;
        }

        [HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.RpcLogic___TakeDamage_3505310624))]
        [HarmonyPrefix]
        private static void OnPlayerTakeDamage(PlayerHealth __instance, ref float damage)
        {
            if (__instance.Player == null)
                return;

            if (damage <= 0f)
                return;

            if (__instance.Player.Clothing == null)
                return;

            if (!IsWearingVest(__instance.Player))
                return;

            float damageReductionPercent = Preferences.GetDamageReductionMultiplier();
            float damageReduction = damage * damageReductionPercent;
            damage = Mathf.Max(0f, damage - damageReduction);
        }

        private static bool IsWearingVest(Player player)
        {
            if (player.Clothing.ClothingSlots == null)
                return false;

            if (player.Clothing.ClothingSlots.TryGetValue(EClothingSlot.Top, out var topSlot) && topSlot.Quantity > 0)
                return true;

            if (player.Clothing.ClothingSlots.TryGetValue(EClothingSlot.Outerwear, out var outerwearSlot) && outerwearSlot.Quantity > 0)
                return true;

            return false;
        }
    }
}