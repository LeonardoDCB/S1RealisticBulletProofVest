using MelonLoader;
using HarmonyLib;
using S1API;
using S1RealisticBulletProofVest.Integrations;
using S1RealisticBulletProofVest.Utils;

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
            VersionChecker.Check();
            
            Preferences.Register();
            
            LoggerInstance.Msg($"[{Constants.MOD_NAME}] Initialized - v{Constants.MOD_VERSION}");
            LoggerInstance.Msg($"[{Constants.MOD_NAME}] Damage reduction: {Preferences.DamageReductionPercent}%");
        }

        public override void OnApplicationQuit()
        {
            Instance = null;
        }
    }
}