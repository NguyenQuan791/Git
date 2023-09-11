using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public string text;
    public TextMeshProUGUI textPrefab;
    public GameObject textOver;

    TextMeshProUGUI[] texts;
    string[] chars;
    float times;
    string jsonString = @"[{""e"": 900,""s"": 0,""te"": 3,""ts"": 0,""w"": ""Hey,""},{""e"": 1090,""s"": 900,""te"": 6,""ts"": 5,""w"": ""do""},{""e"": 1300,""s"": 1090,""te"": 10,""ts"": 8,""w"": ""you""},{""e"": 1660,""s"": 1300,""te"": 15,""ts"": 12,""w"": ""want""},{""e"": 1850,""s"": 1660,""te"": 18,""ts"": 17,""w"": ""to""},{""e"": 2100,""s"": 1850,""te"": 22,""ts"": 20,""w"": ""eat""},{""e"": 2450,""s"": 2100,""te"": 27,""ts"": 24,""w"": ""some""},{""e"": 3530,""s"": 2450,""te"": 35,""ts"": 29,""w"": ""salads?""}]";
    ArraySyncText syncTexts = new ArraySyncText();
    private void Awake()
    {
        chars = this.text.Split(' ');

        foreach (var item in chars)
        {
            textPrefab.text = item;
            Instantiate(textPrefab,textOver.transform);
        }
    }

    private void Start()
    {
        texts = gameObject.GetComponentsInChildren<TextMeshProUGUI>();

        syncTexts = JsonUtility.FromJson<ArraySyncText>("{\"array\":" + jsonString + "}");

        times = 0; 
    }

    void SyncText(string text)
    {
        foreach (var item in texts)
        {
            if (item.text == text)
            {
                item.color = Color.red;
            }
            else
            {
                item.color = Color.black;
            }
        }
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        times += Time.fixedDeltaTime;
        foreach (var item in this.syncTexts.array)
        {
            if (item.s - times*1000 <= 0 && times*1000 - item.e <= 0)
            {
                SyncText(item.w);
                return;
            }
        }
        SyncText("");
    }
}