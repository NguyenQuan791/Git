using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpamTexts : MonoBehaviour
{
    public GameObject SpamText;
    public string Text;
    public Transform Parent;
    public int number;

    static GameObject isSpam;
    static Stopwatch stopwatch = new Stopwatch();

    private void OnMouseDown()
    {
        if(SpamText && Text!=null && Parent)
        {
            Vector2 mose= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
            TextMeshProUGUI textSpam = SpamText.GetComponentInChildren<TextMeshProUGUI>();

            textSpam.text = Text;
            stopwatch.Start();
            stopwatch.Restart();
            TextController.Ins.SyncText(Text);
            if (isSpam)
            {
                Destroy(isSpam);
            }

            GameObject spamText = Instantiate(SpamText, mose, Quaternion.Euler(0, 0, Random.Range(-15f, 15f)), Parent);
            isSpam = spamText;
            SpamBilnks.Ins.blinked.Add(number);
            SpamBilnks.Ins.NextBlink();
            Destroy(spamText,1.5f);
        }
    }

    private void Update()
    {
        if (stopwatch.ElapsedMilliseconds >= 1500)
        {
            TextController.Ins.SyncText("");
            stopwatch.Stop();
        }
    }
}
