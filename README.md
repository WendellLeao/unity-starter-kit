# Unity Starter Kit

One-click installer for a curated set of Unity service packages, plus a few editor tools and utility extensions.

## Installation

Add the package via the Unity Package Manager using a git URL:

```
https://github.com/WendellLeao/unity-starter-kit.git
```

To pin a specific version, append `#v1.0.0` (or any tag) to the URL.

## Usage

1. Open `Tools/WendellLeao/Install Dependencies`.
2. Toggle which packages you want (or use **All**/**None**) and click **Install Selected**.

It installs whichever of these you pick:

- [UniTask](https://github.com/Cysharp/UniTask)
- [WendellLeao.ServiceLocator](https://github.com/WendellLeao/service-locator)
- [WendellLeao.EventService](https://github.com/WendellLeao/event-service)
- [WendellLeao.Pooling](https://github.com/WendellLeao/pooling-service)
- [WendellLeao.Save](https://github.com/WendellLeao/save-service)
- [WendellLeao.Screen](https://github.com/WendellLeao/screen-service)
- [WendellLeao.Audio](https://github.com/WendellLeao/audio-service)
- [WendellLeao.SceneBootstrap](https://github.com/WendellLeao/scene-bootstrap)
- [WendellLeao.SceneSwitcher](https://github.com/WendellLeao/scene-switcher)

The kit also ships a small set of shared utilities (`PathUtility`, `MathUtility`, `PlayerPrefsUtility`, `ScenesUtility`), a `PersistentObject` component that calls `DontDestroyOnLoad` on itself in `Awake` for whenever you just need to keep a random GameObject alive across scenes, and extension methods for `GameObject`, `List<T>` and `Transform`.

## Architecture guide

This starter kit is built for the default folder, namespace, scene, and lifecycle architecture in [WendellLeao/skills](https://github.com/WendellLeao/skills), under [`unity-clean-architecture`](https://github.com/WendellLeao/skills/tree/master/unity-clean-architecture): it's the paved path a brand-new project follows once the services above are installed.

It ships as a ready-to-use, standalone Claude Code Skill; copy that folder into your own `~/.claude/skills/` and it triggers automatically whenever Claude Code scaffolds a new Unity project. Any other agent (Cursor, Codex, Copilot) can be pointed at the same file from whatever instruction file it reads.
