using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public AudioSource Aus;
    public AudioClip Auc;

    private void OnMouseDown()
    {
        Debug.Log(Aus);
        if (Aus && Auc)
        {
            Debug.Log(Auc);
            Aus.PlayOneShot(Auc);
        }
    }
}
