using System.Linq;
using WendellLeao.StarterKit;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using PackageInfo = UnityEditor.PackageManager.PackageInfo;

namespace WendellLeao.StarterKit.Editor.DependenciesImporter
{
    public sealed class DependenciesImporterWindow : EditorWindow
    {
        private const float MinWindowWidth = 420f;
        private const float MinWindowHeight = 320f;

        private static readonly (string PackageId, string GitUrl, string DisplayName)[] Dependencies =
        {
            ("com.wendellleao.servicelocator", "https://github.com/WendellLeao/service-locator.git", "Service Locator"),
            ("com.wendellleao.eventservice", "https://github.com/WendellLeao/event-service.git", "Event Service"),
            ("com.wendellleao.poolingservice", "https://github.com/WendellLeao/pooling-service.git", "Pooling Service"),
            ("com.wendellleao.saveservice", "https://github.com/WendellLeao/save-service.git", "Save Service"),
            ("com.wendellleao.screenservice", "https://github.com/WendellLeao/screen-service.git", "Screen Service"),
            ("com.wendellleao.audioservice", "https://github.com/WendellLeao/audio-service.git", "Audio Service"),
            ("com.wendellleao.scenebootstrap", "https://github.com/WendellLeao/scene-bootstrap.git", "Scene Bootstrap"),
            ("com.cysharp.unitask", "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask", "UniTask")
        };

        private (string PackageId, string GitUrl, string DisplayName, bool Selected)[] _entries;
        private Vector2 _scrollPosition;
        private AddAndRemoveRequest _installRequest;

        [MenuItem(PathUtility.ToolsPath + "/Install Dependencies")]
        public static void ShowWindow()
        {
            DependenciesImporterWindow window = GetWindow<DependenciesImporterWindow>();

            window.SetupWindow();
        }

        public void SetupWindow()
        {
            titleContent = new GUIContent("Starter Kit Dependencies");

            minSize = new Vector2(MinWindowWidth, MinWindowHeight);

            RefreshEntries();

            Focus();
        }

        private void OnGUI()
        {
            GUIStyle titleStyle = new GUIStyle(EditorStyles.boldLabel)
            {
                fontSize = 13,
                wordWrap = true
            };

            GUILayout.Space(10f);

            if (_entries == null || _entries.Length == 0)
            {
                EditorGUILayout.LabelField("All Unity Starter Kit dependencies are installed.", titleStyle);

                return;
            }

            EditorGUILayout.LabelField("Select which Unity Starter Kit packages to install:", titleStyle);

            GUILayout.Space(8f);

            DrawDependencyList();

            GUILayout.Space(8f);

            DrawFooter();
        }

        private void Update()
        {
            if (_installRequest == null || !_installRequest.IsCompleted)
            {
                return;
            }

            if (_installRequest.Status == StatusCode.Failure && _installRequest.Error != null)
            {
                Debug.LogError(_installRequest.Error.message);
            }

            _installRequest = null;

            RefreshEntries();

            Repaint();
        }

        private void DrawDependencyList()
        {
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition, EditorStyles.helpBox);

            for (int i = 0; i < _entries.Length; i++)
            {
                var entry = _entries[i];

                entry.Selected = EditorGUILayout.ToggleLeft(entry.DisplayName, entry.Selected);

                _entries[i] = entry;
            }

            EditorGUILayout.EndScrollView();
        }

        private void DrawFooter()
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("All", EditorStyles.miniButton, GUILayout.Width(50f)))
            {
                SetAllSelected(true);
            }

            if (GUILayout.Button("None", EditorStyles.miniButton, GUILayout.Width(50f)))
            {
                SetAllSelected(false);
            }

            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Cancel", GUILayout.Width(80f)))
            {
                Close();
            }

            bool hasSelection = _entries.Any(entry => entry.Selected);

            GUI.enabled = hasSelection && _installRequest == null;

            if (GUILayout.Button(_installRequest == null ? "Install Selected" : "Installing...", GUILayout.Width(110f)))
            {
                InstallSelectedDependencies();
            }

            GUI.enabled = true;

            EditorGUILayout.EndHorizontal();

            GUILayout.Space(10f);
        }

        private void InstallSelectedDependencies()
        {
            string[] packagesToAdd = _entries
                .Where(entry => entry.Selected)
                .Select(entry => entry.GitUrl)
                .ToArray();

            if (packagesToAdd.Length == 0)
            {
                return;
            }

            _installRequest = Client.AddAndRemove(packagesToAdd);
        }

        private void RefreshEntries()
        {
            (string PackageId, string GitUrl, string DisplayName)[] missingDependencies = GetMissingDependencies();

            _entries = missingDependencies
                .Select(dependency => (dependency.PackageId, dependency.GitUrl, dependency.DisplayName, Selected: true))
                .ToArray();
        }

        internal static (string PackageId, string GitUrl, string DisplayName)[] GetMissingDependencies()
        {
            PackageInfo[] registeredPackages = PackageInfo.GetAllRegisteredPackages();

            return Dependencies
                .Where(dependency => registeredPackages.All(package => package.name != dependency.PackageId))
                .ToArray();
        }

        private void SetAllSelected(bool selected)
        {
            for (int i = 0; i < _entries.Length; i++)
            {
                var entry = _entries[i];

                entry.Selected = selected;

                _entries[i] = entry;
            }
        }
    }
}
