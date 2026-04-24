using System;
using MelonLoader;
using S1RealisticBulletProofVest.Utils;

namespace S1RealisticBulletProofVest.Utils
{
    public static class Preferences
    {
        private static MelonPreferences_Entry<float> _damageReductionPercent = null!;
        
        public static float DamageReductionPercent => _damageReductionPercent.Value;

        public static void Register()
        {
            var category = MelonPreferences.CreateCategory(Constants.PREFERENCES_CATEGORY, Constants.MOD_NAME);
            _damageReductionPercent = category.CreateEntry<float>(nameof(DamageReductionPercent), Constants.Defaults.DAMAGE_REDUCTION_PERCENT);
            MelonPreferences.Save();
        }

        public static float GetDamageReductionMultiplier()
        {
            return DamageReductionPercent / 100f;
        }
    }
}