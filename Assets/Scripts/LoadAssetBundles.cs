<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
using System;
=======
>>>>>>> 7096988c3f59170432ecc0d0437a7ad994ddc8d0
=======
>>>>>>> origin/main
=======
>>>>>>> origin/main
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
using UnityEngine.Assertions;

public class LoadAssetBundles : MonoBehaviour
{
    public Transform Parent;
    void Start()
    {
        var myLoadedAssetBundle
            = AssetBundle.LoadFromFile("Assets/AssetBundles/uis").LoadAllAssets();
=======
=======
>>>>>>> origin/main
=======
>>>>>>> origin/main

public class LoadAssetBundles : MonoBehaviour
{
    private void Start()
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/pagesassetbundles");
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 7096988c3f59170432ecc0d0437a7ad994ddc8d0
=======
>>>>>>> origin/main
=======
>>>>>>> origin/main
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        foreach(var assetBundle in myLoadedAssetBundle)
        {
            var type=assetBundle.GetType();
            if (type.ToString().Contains("GameObject"))
            {
                Debug.Log(assetBundle.GetType());
                var prefab = assetBundle;
                if (!prefab)
                {
                    return;
                }
                Instantiate(prefab, Parent);
            }
        }
=======
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("pagesassetbundles");
        Instantiate(prefab);
>>>>>>> 7096988c3f59170432ecc0d0437a7ad994ddc8d0
=======
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("pagesassetbundles");
        Instantiate(prefab);
>>>>>>> origin/main
=======
        var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("pagesassetbundles");
        Instantiate(prefab);
>>>>>>> origin/main
    }
}
