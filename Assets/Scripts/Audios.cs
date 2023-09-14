using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEditor;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void OnMouseDown()
    {
        if (audioSource && audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
