using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;

public class LoadAssetBundles : MonoBehaviour
{
    public Transform parentTransform;
    private void Start()
    {
        var myLoadedAssetBundle
            = AssetBundle.LoadFromFile("Assets/AssetBundles/uis").LoadAllAssets();
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        foreach (var assetBundle in myLoadedAssetBundle)
        {
            var type = assetBundle.GetType();
            if (type.ToString().Contains("GameObject"))
            {
                Debug.Log(assetBundle.GetType());
                var prefab = assetBundle;
                if (!prefab)
                {
                    return;
                }
                Instantiate(prefab, parentTransform);
            }
        }
    }
}
