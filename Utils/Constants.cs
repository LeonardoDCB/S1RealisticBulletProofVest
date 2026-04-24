using System;

namespace S1RealisticBulletProofVest.Utils
{
    public static class Constants
    {
        public const string MOD_NAME = "S1RealisticBulletProofVest";
        public const string MOD_VERSION = "1.0.1";
        public const string MOD_AUTHOR = "AeroChoclate";
        public const string MOD_DESCRIPTION = "Makes the bulletproof vest actually resist bullets and mitigate damage.";

        public const string PREFERENCES_CATEGORY = "S1RealisticBulletProofVest";

        public static class Defaults
        {
            public const float DAMAGE_REDUCTION_PERCENT = 50f;
        }

        public static class Constraints
        {
            public const float MIN_DAMAGE_REDUCTION = 0f;
            public const float MAX_DAMAGE_REDUCTION = 100f;
        }

        public static class Game
        {
            public const string GAME_STUDIO = "TVGS";
            public const string GAME_NAME = "Schedule I";
        }

    }
}