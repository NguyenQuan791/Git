using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamBilnks : Singleton<SpamBilnks>
{
    public GameObject[] blinks;
    public List<int> blinked;
    public int blinking;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        blinking = 0;
    }

    public void Blink()
    {
        if (blinking < blinks.Length)
        {
            for (int i = 0; i < blinks.Length-1; i++)
            {
                if (i == blinking && !blinked.Contains(i))
                {
                    blinks[i].gameObject.SetActive(true);
                }
                else
                {
                    blinks[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < blinks.Length - 1; i++)
            {
                blinks[i].gameObject.SetActive(false);
            }
        }
    }

    public void NextBlink()
    {
        if (blinking < blinks.Length)
        {
            for (int i = 0; i < blinks.Length - 1; i++)
            {
                if (!blinked.Contains(i))
                {
                    blinking = i;
                    break;
                }
            }
            Blink();
        }
    }
}
