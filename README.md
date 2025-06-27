# 🦊 Fox Hop

**Fox Hop** is a 2D side-scrolling platformer game developed in Unity. You control a fox that can run, jump, shoot fireballs, and explore charming pixel environments while avoiding traps and defeating enemies. Featuring responsive controls, smooth animations, AI enemies, a dynamic camera system, and multiple levels — *Fox Hop* is built for fun and challenge.

---

## 🎮 Features

### 🕹️ Movement
- Player-controlled horizontal movement using Rigidbody2D
- Distinct **ground** and **wall jumping** with gravity tuning
- Directional flipping and animation transitions
- Jump and movement mechanics enabled via `PlayerMovement.cs`

### 🔥 Shooting
- Fireball attack using **object pooling** for performance
- Attack logic triggered on mouse input (`GetMouseButton(0)`)
- Cooldown mechanics for balanced gameplay
- Fireball direction matches fox facing and position
- Uses `FindFireball()` to select available fireball from the pool

### 🎞️ Animation
- Animator Controller with states: `Idle`, `Run`, `Jump`, `Attack`, `Get Hurt`, `Die`
- Transitions designed for smooth and reactive gameplay
- "Any State" transitions for jumping and attacks
- Visual feedback on damage and death through animations

### 🖼️ Graphics
- 🎨 **Asset packs used**:
  - [Sunny Land](https://assetstore.unity.com/packages/2d/environments/sunny-land-103349) – vibrant terrain and tiles
  - [Knight Sprite Sheet Free](https://craftpix.net/freebies/free-pixel-art-knight-sprites/) – medieval-style enemies
  - [Pixel Adventure 1](https://ansimuz.itch.io/pixel-adventure-1) – unique pixel props and environmental variety
- Carefully curated to ensure consistency in theme and tone

### 🎥 Camera
- Dynamic camera follow using `CameraController.cs`
- Anticipatory "look ahead" logic for smooth navigation
- Adjustable parameters: `aheadDistance`, `cameraSpeed`
- Real-time tracking based on player velocity

### ❤️ Health System
- `Health.cs` and `HPBAR.cs` manage health logic and UI
- Damage triggers animation and reduces health
- Character death disables movement and enemy patrol logic
- Respawn and full health handled via `Respawn1.cs`

### 🛡️ Enemy AI
- `EnemyPatrol.cs` controls back-and-forth patrol between boundaries
- `KnightEnemy.cs` handles detection and attack behavior
- Configurable patrol speed and wait time
- Adds realism and dynamic challenge to each level

---

## 🔧 Technologies Used

- **Unity Engine (C#)**
- **Rigidbody2D**, **Animator**, and **Collider Components**
- Object Pooling for optimized projectile management
- Custom Scripts for AI, Camera, Health, and Input Systems

---

## 🧠 Development Insights

### Key Learnings:
- 🎯 Player movement and state transition fine-tuning
- ⚙️ Shooting mechanics and projectile object pooling
- 🎨 Level design with modular pixel assets
- 🤖 AI patrol logic for enemy behavior
- 🎥 Camera smoothing and look-ahead implementation

### Challenges Overcome:
- Complex animation transitions (e.g., run → jump → attack)
- Smooth and responsive camera logic
- Ensuring visual consistency across different asset packs

### Useful Practices:
- Use of `[SerializeField]` to expose private variables in Unity Inspector  
  [Unity Forum Reference](https://discussions.unity.com/t/when-to-use-serializefield-and-why/506330)
- Modular script design for ease of testing and debugging
- Balancing gameplay through cooldowns, damage logic, and hit animations

---

## 📦 Assets & References

| Purpose       | Link |
|---------------|------|
| SerializeField Guide | [Unity Forum](https://discussions.unity.com/t/when-to-use-serializefield-and-why/506330) |
| Acorn Art | [Freepik Pixel Acorn](https://img.freepik.com/premium-vector/pixel-art-acorn-game-asset-design_466450-1990.jpg) |
| Tiles Tutorial | [YouTube Video](https://youtu.be/RVU9qdYL240?si=sHeNGHWYgAsdb2Ai) |
| Game Dev Channel | [PandemoniumGameDev](https://www.youtube.com/@PandemoniumGameDev) |

---

## 🙌 Special Thanks

Big thanks to **[PandemoniumGameDev](https://www.youtube.com/@PandemoniumGameDev)** on YouTube for tutorials and insights into Unity controls, tilemaps, and general best practices. Their channel was a major resource throughout development.

---

## 🏁 Final Thoughts

Building *Fox Hop* was an exciting and fulfilling learning experience. From mastering animation states to building a working AI patrol system, I’ve gained valuable knowledge in Unity development, optimization, and creative design. Every obstacle helped sharpen my skills — and I look forward to expanding on this project and building even more dynamic games in the future.

---

