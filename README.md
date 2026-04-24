# S1RealisticBulletProofVest

A Schedule I mod that makes bulletproof vests actually resist bullets and mitigate damage.

## Description

This mod adds realistic damage mitigation to the bulletproof vest in Schedule I. When you wear a vest in either the Top or Outerwear clothing slot, bullet and melee damage will be reduced by 50%.

## Features

- **Damage Mitigation**: Reduces incoming damage by 50% when wearing a vest
- **Vest Detection**: Automatically detects vests in Top or Outerwear clothing slots

## How It Works

### Harmony Patching

The mod uses Harmony to patch the `PlayerHealth.RpcLogic___TakeDamage_3505310624` method. When damage is about to be applied to a player:

1. The patch checks if the player has a vest equipped (Top or Outerwear slot)
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
Log damage reduction to console
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

Built DLLs are automatically copied to the game's Mods folder (configured in csproj).

## Configuration

You can modify the damage reduction percentage in `Integrations/HarmonyPatches.cs`:

```csharp
float damageReduction = damage * 0.5f; // Change 0.5f to your desired percentage
```

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
