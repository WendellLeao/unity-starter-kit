# Changelog

## [1.1.0] - 2026-08-17

### Changed

- Scene Loader moved out into its own standalone package ([WendellLeao.SceneLoader](https://github.com/WendellLeao/scene-loader)) and added as an installable dependency in the Dependencies Importer.
- Scene Loader: replaced the standalone `Tools/WendellLeao/Scene Loader` window with a searchable popup opened from a ▾ arrow next to the scene entry in the Hierarchy window. Supports favoriting scenes, a loaded/unloaded indicator, and per-scene Open Single/Open Additive/Ping in Project actions.

### Removed

- The bundled `Editor/SceneLoader/` code (`SceneHierarchyDropdown`, `SceneSearchPopup`, `SceneCatalog`, `SceneFavorites`, `SceneEntry`).
- `SceneLoaderWindow` and its `Tools/WendellLeao/Scene Loader` menu item.

## [1.0.0] - 2026-08-16

### Added

- Dependencies Importer: checklist window to install any of the curated service packages (`Tools/WendellLeao/Install Dependencies`).
- Scene Loader window (`Tools/WendellLeao/Scene Loader`).
- Utility classes: `PathUtility`, `MathUtility`, `PlayerPrefsUtility`, `ScenesUtility`.
- Extension methods for `GameObject`, `List<T>` and `Transform`.
