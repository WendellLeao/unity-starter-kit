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

The kit also ships a **Scene Loader** window (`Tools/WendellLeao/Scene Loader`) for quick scene-switching, plus a small set of shared utilities (`PathUtility`, `MathUtility`, `PlayerPrefsUtility`, `ScenesUtility`) and extension methods for `GameObject`, `List<T>` and `Transform`.
