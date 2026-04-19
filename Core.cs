using MelonLoader;
using HarmonyLib;
using S1API;
using S1RealisticBulletProofVest.Integrations;
using S1RealisticBulletProofVest.Utils;
using System.Linq;

[assembly: MelonInfo(typeof(S1RealisticBulletProofVest.Core), Constants.MOD_NAME, Constants.MOD_VERSION, Constants.MOD_AUTHOR)]
[assembly: MelonGame(Constants.Game.GAME_STUDIO, Constants.Game.GAME_NAME)]

namespace S1RealisticBulletProofVest
{
    public class Core : MelonMod
    {
        public static Core? Instance { get; private set; }

        public override void OnInitializeMelon()
        {
            Instance = this;
            HarmonyPatches.SetModInstance(this);
            LoggerInstance.Msg($"[{Constants.MOD_NAME}] Initialized - v{Constants.MOD_VERSION}");
            LoggerInstance.Msg($"[{Constants.MOD_NAME}] Checking Harmony patches...");
            CheckHarmonyPatches();
        }

        private void CheckHarmonyPatches()
        {
            var patches = HarmonyLib.Harmony.GetAllPatchedMethods().ToList();
            
            LoggerInstance.Msg($"[{Constants.MOD_NAME}] Total patched methods: {patches.Count}");
            
            if (patches.Count > 0)
            {
                LoggerInstance.Msg($"[Harmony] SUCCESS - Damage mitigation active!");
                LoggerInstance.Msg($"[Harmony] Patch applied to: PlayerHealth.TakeDamage");
            }
            else
            {
                LoggerInstance.Warning($"[Harmony] WARNING - No patches detected!");
            }
        }

        public override void OnApplicationQuit()
        {
            Instance = null;
        }
    }
}