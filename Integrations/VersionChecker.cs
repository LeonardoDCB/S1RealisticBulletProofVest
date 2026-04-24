using System;
using System.Reflection;
using System.Text;
using MelonLoader;
using S1RealisticBulletProofVest.Utils;

namespace S1RealisticBulletProofVest.Integrations
{
    internal static class VersionChecker
    {
        private const string PROBLEMATIC_VERSION = "0.7.1.0";
        private const string RECOMMENDED_STABLE = "0.7.2";
        private const string RECOMMENDED_NIGHTLY = "0.7.2-nightly";

        public static void Check()
        {
            var version = GetMelonLoaderVersion();
            if (string.IsNullOrEmpty(version))
            {
                MelonLogger.Warning("[VersionChecker] Could not determine MelonLoader version!");
                return;
            }

            if (version == PROBLEMATIC_VERSION)
            {
                ShowWarning(version);
            }
            else if (IsProblematicVersion(version))
            {
                MelonLogger.Warning($"[VersionChecker] Warning: Near problematic version {PROBLEMATIC_VERSION}");
                MelonLogger.Warning($"[VersionChecker] Recommended: {RECOMMENDED_STABLE} or {RECOMMENDED_NIGHTLY}");
            }
        }

        private static string GetMelonLoaderVersion()
        {
            try
            {
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    var name = assembly.GetName().Name;
                    if (name == "MelonLoader" || name == "MelonLoader.Core")
                    {
                        return assembly.GetName().Version?.ToString();
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        private static bool IsProblematicVersion(string version)
        {
            return version.StartsWith("0.7.1") && version != PROBLEMATIC_VERSION;
        }

        private static void ShowWarning(string detectedVersion)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("╔════════════════════════════════════════════════════════════════════════╗");
            sb.AppendLine("║                   !!! WARNING !!!                              ║");
            sb.AppendLine("╠════════════════════════════════════════════════════════════════════════╣");
            sb.AppendLine($"║  MelonLoader Version: {detectedVersion,-14}                       ║");
            sb.AppendLine("║  This version has known critical issues.                            ║");
            sb.AppendLine("╠════════════════════════════════════════════════════════════════════════╣");
            sb.AppendLine("║  Recommended:                                                   ║");
            sb.AppendLine($"║    ► {RECOMMENDED_STABLE,-20} (Stable)                      ║");
            sb.AppendLine($"║    ► {RECOMMENDED_NIGHTLY,-20} (Nightly)                    ║");
            sb.AppendLine("║  Download: melonwiki.xyz/#/?id=automated-installation           ║");
            sb.AppendLine("╚════════════════════════════════════════════════════════════════════════╝");

            MelonLogger.Error(sb.ToString());
            MelonLogger.Error($"Update: github.com/LavaGang/MelonLoader/releases");
        }
    }
}