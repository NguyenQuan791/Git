using System;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateAssetBundles 
{
    public static string assetBundleDirectoryPath = "Assets/AssetBundles/";
    [MenuItem("/Assets/Create Assets Bundles")]
    private static void BuildAllAssetBundles()
    {
        try
        {
            if (!Directory.Exists(assetBundleDirectoryPath))
            {
                Directory.CreateDirectory(assetBundleDirectoryPath);
            }

            BuildPipeline.BuildAssetBundles(assetBundleDirectoryPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);

            Debug.Log("OK");

        }
        catch (Exception e) 
        { 
            Debug.LogException(e);
        }
    }
}
