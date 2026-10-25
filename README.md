# S1RealisticBulletProofVest

A Schedule I mod that makes bulletproof vests actually resist bullets and mitigate damage.

## Description

This mod reduces incoming damage when the game's Tactical Vest (`tacticalvest`) is equipped in the Outerwear slot. Merely carrying a vest, or wearing unrelated clothing, does not grant protection. The original damage hook is unchanged, so bullet and melee damage are both reduced by 50% by default.

## Features

- **Damage Mitigation**: Reduces incoming damage by 50% when wearing a vest
- **Vest Detection**: Checks the equipped Outerwear item's ID, not just whether a clothing slot is occupied

## How It Works

### Harmony Patching

The mod uses Harmony to patch the `PlayerHealth.RpcLogic___TakeDamage_3505310624` method. When damage is about to be applied to a player:

1. The patch checks if the Tactical Vest is equipped in the Outerwear slot
2. If a vest is detected, it reduces the damage by 50%
3. The modified damage value is passed to the original method

### Key Files

| File | Purpose |
|------|---------|
| `Core.cs` | Main mod entry point, initializes Harmony patches |
| `Integrations/HarmonyPatches.cs` | Contains the damage mitigation logic |
| `Utils/Constants.cs` | Mod configuration and constants |

### Code Flow

```
Player takes damage
    ↓
Harmony prefix intercepts TakeDamage
    ↓
Check if player has vest equipped
    ↓
If vest: reduce damage by 50%
    ↓
Original method processes reduced damage
```

## Building

### Prerequisites

- .NET SDK
- Visual Studio (recommended) or VS Code
- Schedule I game installed (Mono or IL2CPP version)

### Build Commands

**For Mono version (Schedule I_alternate):**
```bash
dotnet build --configuration Mono
```

**For IL2CPP version (Schedule I):**
```bash
dotnet build --configuration Il2cpp
```

### Output

To build against a game installed outside the default Steam location, pass `-p:GamePath="path/to/Schedule I"`. The build does not launch or close the game by default. Close the game, back up the previous DLL and copy the new DLL from `bin/Il2cpp/netstandard2.1/` into the game's `Mods` folder, replacing the old version (never load both copies).

## Configuration

Set `DamageReductionPercent` under `[S1RealisticBulletProofVest]` in `UserData/MelonPreferences.cfg` while the game is closed (50 by default).

## Contributing

Contributions are welcome! Here's how you can help:

1. **Fork the repository**
2. **Create a feature branch** (`git checkout -b feature/amazing-feature`)
3. **Commit your changes** (`git commit -m 'Add amazing feature'`)
4. **Push to the branch** (`git push origin feature/amazing-feature`)
5. **Open a Pull Request**

## License

Distributed under the MIT License.

## Acknowledgments

- [MelonLoader](https://melonwiki.xyz/) - Mod loader for Unity games
- [Harmony](https://harmony.pardeike.net/) - Patching library
- [S1API](https://ifbars.github.io/S1API/) - Schedule I modding API
