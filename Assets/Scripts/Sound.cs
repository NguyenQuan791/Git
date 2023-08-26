using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource aus;
    public AudioClip clip;

    private void OnMouseDown()
    {
        if(aus && clip)
        {
            aus.PlayOneShot(clip);
        }       
    }
}
