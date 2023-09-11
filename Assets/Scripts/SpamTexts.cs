using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpamTexts : MonoBehaviour
{
    public GameObject SpamText;
    public string Text;
    public Transform Parent;

    private void OnMouseDown()
    {
        if(SpamText && Text!=null && Parent)
        {
            Vector2 mose= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
            TextMeshProUGUI textSpam = SpamText.GetComponentInChildren<TextMeshProUGUI>();

            textSpam.text = Text;

            GameObject spamText= Instantiate(SpamText, mose, Quaternion.identity, Parent);

            Destroy(spamText, 2f);
        }
    }
}
