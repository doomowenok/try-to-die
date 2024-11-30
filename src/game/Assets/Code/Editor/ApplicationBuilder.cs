using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirenix.Utilities;
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Code.Editor
{
    public static class ApplicationBuilder
    {
        [MenuItem("Build/List active scenes")]
        public static void ListActiveScenes()
        {
            StringBuilder scenes = new StringBuilder();
            GetActiveScenes().ForEach(sceneName => scenes.Append(sceneName).Append("\n"));
            Debug.Log(scenes.ToString());
        }
        
        [MenuItem("Build/Build MacOS (Development)")]
        public static void BuildApplicationForMacOSDevelopment()
        {
            string[] scenes = GetActiveScenes().ToArray();
            
            BuildPlayerOptions buildOptions = new BuildPlayerOptions
            {
                scenes = scenes,
                locationPathName = "Builds/MacOS/Game.app",
                target = BuildTarget.StandaloneOSX,
                options = BuildOptions.Development,
            };

            BuildAddressables();
            
            BuildReport report = BuildPipeline.BuildPlayer(buildOptions);
            BuildSummary summary = report.summary;

            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log($"Build succeeded: {summary.totalSize} bytes.");
            }

            if (summary.result == BuildResult.Failed)
            {
                Debug.LogError("Build failed.");
            }
        }
        
        private static void BuildAddressables()
        {
            AddressableAssetSettings settings = AddressableAssetSettingsDefaultObject.Settings;

            if (settings == null)
            {
                Debug.LogError("Addressable Asset Settings not found. Please check your Addressable setup.");
                return;
            }
            
            AddressableAssetSettings.CleanPlayerContent();
            Debug.Log("Addressables content cleaned.");
            
            AddressableAssetSettings.BuildPlayerContent();
            
            Debug.Log("Addressables build complete.");
        }

        private static IEnumerable<string> GetActiveScenes()
        {
            return EditorBuildSettings.scenes
                .Where(scene => scene.enabled)
                .Select(scene => scene.path);
        }
    }
}