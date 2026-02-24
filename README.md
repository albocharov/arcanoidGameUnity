# Arcanoid Game (Unity)

A color-matching Arcanoid (Breakout-style) game built with Unity 2022.3.

## About

Classic brick-breaking gameplay with a twist: the ball and bricks each have a **color** (red or blue). A ball can only destroy a brick of the **same color**. The ball changes color when it bounces off the platform, so timing and platform positioning are key.

The game features 5 hand-crafted levels, a health system, power-up boosters, and escalating ball speed to keep the challenge growing.

## Features

- 🎮 **5 levels** + Main Menu scene
- 🎨 **Color-matching mechanic** — only same-colored ball/brick pairs destroy each other
- 🏓 **Responsive platform** — controlled by mouse or keyboard
- ❤️ **Health system** — lose a life when all balls fall; game over at zero health
- ⚡ **Escalating speed** — ball speed increases with each brick destroyed (clamped 15–25 units/s)
- 🎁 **Boosters** — randomly drop from destroyed bricks:
  - **+1 Ball** — spawns one extra ball
  - **+3 Balls** — spawns three extra balls
  - **×3 Multiply** — triples all currently active balls
- 🔊 **Sound effects** — brick hits, wall bounces, damage, bonuses, win/lose jingles, and background soundtrack

## Controls

| Input | Action |
|-------|--------|
| **Left Mouse Button** (hold & move) | Move platform |
| **Left Mouse Button** (release) | Launch ball |
| **Arrow Keys / WASD / Gamepad** | Move platform |
| Moving platform | Automatically launches ball |

## Getting Started

### Prerequisites

- [Unity 2022.3.13f1](https://unity.com/releases/editor/whats-new/2022.3.13) (or a compatible 2022.3.x LTS version)

### Running the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/albocharov/arcanoidGameUnity.git
   ```
2. Open **Unity Hub** and click **Add project from disk**, then select the cloned folder.
3. Open the **MainMenu** scene (`Assets/Scenes/MainMenu.unity`).
4. Press **Play** in the Unity Editor, or build the project via **File → Build Settings**.

## Project Structure

```
Assets/
├── Prefabs/          # Ball, Brick, Booster prefabs and the Sounds collection
├── Scenes/           # MainMenu + 5 game levels
├── Scripts/          # All C# game scripts
│   ├── Ball.cs               # Ball physics and color logic
│   ├── Brick.cs              # Brick destruction and color-matching
│   ├── Booster.cs            # Base booster class
│   ├── BoosterPlus.cs        # +N balls booster
│   ├── BoosterMultiply.cs    # ×N balls booster
│   ├── DeathZone.cs          # Detects ball falling out of play
│   ├── GameManager.cs        # Core game state, health, win/lose
│   ├── PlatformMovement.cs   # Player platform input handling
│   ├── SoundsBaseCollection.cs # Centralised audio references
│   ├── UIManager.cs          # HUD and menu panels
│   ├── UIDefaultFunctions.cs # Common UI button actions
│   └── TextAnim.cs           # Animated text helper
├── Physic/           # Physics materials
├── Sound/            # Audio clips
├── Textures/         # Sprites and materials
└── Settings/         # URP render pipeline settings
```

## Dependencies

- **Unity 2022.3 LTS** with the Universal Render Pipeline (URP)
- **TextMesh Pro** — in-game UI text
- **UniTask** ([Cysharp/UniTask](https://github.com/Cysharp/UniTask)) — async/await helpers
- **Unity Input System** — cross-platform platform movement

## License

This project is licensed under the [MIT License](LICENSE).  
Copyright © 2024 Alexander Bocharov
