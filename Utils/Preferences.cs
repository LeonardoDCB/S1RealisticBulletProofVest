using System;
using System.IO;
using MelonLoader;
using S1RealisticBulletProofVest.Utils;

namespace S1RealisticBulletProofVest.Utils
{
    public static class Preferences
    {
        private static float _damageReductionPercent = Constants.Defaults.DAMAGE_REDUCTION_PERCENT;
        
        public static float DamageReductionPercent => _damageReductionPercent;

        public static void Register()
        {
            LoadFromFile();
        }

        private static void LoadFromFile()
        {
            try
            {
                var configDir = Path.Combine(Directory.GetCurrentDirectory(), "Config");
                var configFile = Path.Combine(configDir, $"{Constants.MOD_NAME}.cfg");

                if (File.Exists(configFile))
                {
                    var lines = File.ReadAllLines(configFile);
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("DamageReductionPercent=", StringComparison.OrdinalIgnoreCase))
                        {
                            var valueStr = line.Substring("DamageReductionPercent=".Length).Trim();
                            if (float.TryParse(valueStr, out float value))
                            {
                                _damageReductionPercent = (float)Math.Round(Math.Clamp(value, Constants.Constraints.MIN_DAMAGE_REDUCTION, Constants.Constraints.MAX_DAMAGE_REDUCTION), 1);
                            }
                        }
                    }
                }
                else
                {
                    SaveToFile();
                }
            }
            catch
            {
                _damageReductionPercent = Constants.Defaults.DAMAGE_REDUCTION_PERCENT;
            }
        }

        private static void SaveToFile()
        {
            try
            {
                var configDir = Path.Combine(Directory.GetCurrentDirectory(), "Config");
                if (!Directory.Exists(configDir))
                    Directory.CreateDirectory(configDir);

                var configFile = Path.Combine(configDir, $"{Constants.MOD_NAME}.cfg");
                File.WriteAllText(configFile, $"DamageReductionPercent={_damageReductionPercent}");
            }
            catch { }
        }

        public static float GetDamageReductionMultiplier()
        {
            return _damageReductionPercent / 100f;
        }
    }
}