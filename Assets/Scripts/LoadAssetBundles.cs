using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    private void Start()
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/pagesassetbundles");
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("pagesassetbundles");
        Instantiate(prefab);
    }
}
