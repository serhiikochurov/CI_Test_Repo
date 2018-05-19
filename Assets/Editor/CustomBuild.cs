using System;
using System.Collections.Generic;
using UnityEditor;

public class CustomBuild
{
    public static void BuildAndroidStudioProject()
    {
        BuildPlayerOptions options = new BuildPlayerOptions
        {
            locationPathName = Environment.GetEnvironmentVariable("CI_ANDROID_STUDIO_BUILD_PATH"),
            scenes = GetScenes(),
            target = BuildTarget.Android,
            options = BuildOptions.AcceptExternalModificationsToPlayer
        };
        
        BuildPipeline.BuildPlayer(options);
    }
    
    static string[] GetScenes()
    {
        var projectScenes = EditorBuildSettings.scenes;
        List<string> scenesToBuild = new List<string>();
        for (int i = 0; i < projectScenes.Length; i++)
        {
            if (projectScenes[i].enabled) {
                scenesToBuild.Add(projectScenes[i].path);
            }
        }
        return scenesToBuild.ToArray();
    }
}