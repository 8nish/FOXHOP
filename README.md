🦊 Fox Hop
Fox Hop is a 2D side-scrolling platformer game developed in Unity. In this game, you control a fox that can run, jump, shoot fireballs, and explore vibrant pixel environments while avoiding traps and defeating enemies. The game features responsive controls, smooth animations, AI enemies, a dynamic camera system, and multiple levels designed to provide fun and challenge.

🎮 Features
🕹️ Movement
Horizontal movement based on player input

Ground and wall jumping with distinct physics and gravity

Directional facing and animation transitions based on input

Rigidbody2D, Animator, and BoxCollider2D integration

🔥 Shooting
Fireball projectile system using object pooling for efficiency

Attack cooldown mechanics to ensure balanced combat

Animated attack sequences and directional shooting

🎞️ Animation
Animator controller with state transitions for:
Idle, Run, Jump, Attack, Get Hurt, and Die

Smooth transitions using Unity's "Any State" mechanism

Visual feedback animations for damage and death events

🖼️ Graphics
Assets from:

Sunny Land – vibrant and charming environment tiles

Knight Sprite Sheet Free – medieval-themed enemies

Pixel Adventure 1 – additional props and diversity in visuals

Carefully chosen pixel art assets to build a coherent world

🎥 Camera
Dynamic camera system using a CameraController script

Smooth follow mechanics with look-ahead and anticipation

Adjustable speed and distance parameters for cinematic feel

❤️ Health System
Fully functional health logic using Health and HPBAR scripts

Damage detection, animation triggers, and respawn logic

UI-based health display to reflect current player status

🛡️ Enemy AI
EnemyPatrol script to handle enemy movement between boundaries

KnightEnemy for combat behavior

Adjustable patrol speed and wait time

Enhances realism and interaction in game environments

🔧 Technologies Used
Unity with C#

Animator Controller and Rigidbody2D

Object Pooling for optimized shooting

Pixel Art assets and environment design

✍️ Development Insights
Working on Fox Hop gave me hands-on experience across all facets of game development, including:

Designing fluid player controls and animations

Implementing combat systems and attack feedback

Building interactive environments with strategic asset selection

Handling enemy AI and patrol logic for immersive challenges

Integrating serialization ([SerializeField]) for better inspector control

I overcame significant challenges in:

Character animation transitions (especially between running, jumping, and attacking)

Building a responsive camera system that enhances the gameplay experience

Creating a visually cohesive pixel art world from multiple asset sources

🧠 Lessons Learned
Understanding and applying SerializeField to expose private variables in Unity Inspector

Using object pooling to optimize performance with frequent object instantiation

Designing modular scripts for movement, shooting, health, and enemy AI

Leveraging tutorials and community forums to troubleshoot and iterate

🎨 Assets & References
Sunny Land Pack

Knight Sprite Sheet Free

Pixel Adventure 1

SerializeField Unity Forum

Acorn Game Asset

Tiles Tutorial (YouTube)

Pandemonium Game Dev Channel

🙌 Special Thanks
Huge thanks to the PandemoniumGameDev channel for insightful tutorials on Unity controls and mechanics. Their content helped me navigate many development hurdles and inspired key systems in Fox Hop.

🏁 Final Thoughts
Fox Hop has been a rewarding journey from idea to execution. It strengthened my understanding of Unity development, asset integration, animation systems, and real-time gameplay logic. I’m proud of what I’ve built and excited to apply these lessons in future game projects.

Let me know if you'd like to turn this into a GitHub project with badges, images/gifs of gameplay, or a license section.
