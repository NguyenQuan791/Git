<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
=======
=======
>>>>>>> origin/main
=======
>>>>>>> origin/main
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
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 7096988c3f59170432ecc0d0437a7ad994ddc8d0
=======
>>>>>>> origin/main
=======
>>>>>>> origin/main
    }
}
