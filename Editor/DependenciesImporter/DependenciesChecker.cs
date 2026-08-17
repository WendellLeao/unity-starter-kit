using UnityEditor;
using UnityEngine;

namespace WendellLeao.StarterKit.Editor.DependenciesImporter
{
    [InitializeOnLoad]
    public static class DependenciesChecker
    {
        static DependenciesChecker()
        {
            (string PackageId, string GitUrl, string DisplayName)[] missingDependencies = DependenciesImporterWindow.GetMissingDependencies();

            if (missingDependencies.Length == 0)
            {
                return;
            }

            Debug.LogWarning($"Unity Starter Kit is missing {missingDependencies.Length} dependency package(s). Open Tools/WendellLeao/Install Dependencies to install them.");
        }
    }
}
