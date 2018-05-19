using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class CustomBuild
{
    public static void BuildAndroid()
    {
        BuildPlayerOptions options = new BuildPlayerOptions();

        options.locationPathName = Application.dataPath;
        options.options = BuildOptions.AcceptExternalModificationsToPlayer;
        options.scenes = GetScenes();
        options.target = BuildTarget.Android;
        options.targetGroup = BuildTargetGroup.Android;
        
        BuildPipeline.BuildPlayer(options);
    }
    
    private static string[] GetScenes()
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