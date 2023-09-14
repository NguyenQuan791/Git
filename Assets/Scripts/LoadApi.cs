using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class LoadApi : MonoBehaviour
{
    public Transform parentTransform;

    ImageContent image;
    string fileContent;

    private void Awake()
    {
        string filePath = "d:/Downloads/Tele/4057_1_4307_1688701526/4131_page_1.json";

        if (File.Exists(filePath))
        {
            fileContent = File.ReadAllText(filePath);
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }

        if(fileContent!=null)
        {
            image=JsonUtility.FromJson<ImageContent>(fileContent);
        }
    }

    private void Start()
    {
        if(image!=null)
        {
            foreach(var img in image.image)
            {
                GameObject test = new GameObject();

                test.AddComponent<PolygonCollider2D>();
                test.AddComponent<RectTransform>();
                test.AddComponent<Audios>();
                test.AddComponent<SpamTexts>();

                Audios audio = test.GetComponent<Audios>();
                SpamTexts spam = test.GetComponent<SpamTexts>();
                RectTransform rect = test.GetComponent<RectTransform>();

                audio.audioSource = FindObjectOfType<AudioSource>();
                spam.SpamText = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Spam text.prefab");
                spam.Parent = gameObject.transform;

                rect.position = StringToVector2(img.position);
                rect.anchorMax = new Vector2(0, 0);
                rect.anchorMin = new Vector2(0, 0);
                rect.sizeDelta = new Vector2(150, 150);

                if(img.word_id == 40000183)
                {
                    audio.audioClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/audios/boy.mp3");
                    spam.Text = "Boy";
                    spam.number = 3;
                }
                else if(img.word_id == 40000177)
                {
                    audio.audioClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/audios/spoon.mp3");
                    spam.Text = "Spoon";
                    spam.number = 2;
                }
                else if (img.word_id == 40000178)
                {
                    audio.audioClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/audios/fork.mp3");
                    spam.Text = "Fork";
                    spam.number = 1;
                }
                else
                {
                    audio.audioClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/audios/salad bowl.mp3");
                    spam.Text = "Salad bowl";
                    spam.number = 0;
                }
                foreach (var item in img.touch)
                {
                    PolygonCollider2D col = test.GetComponent<PolygonCollider2D>();
                    List<Vector2> points = new List<Vector2>();
                    foreach (var ve2 in item.vertices)
                    {
                        points.Add(StringToVector2(ve2));
                    }
                    col.points = points.ToArray();
                }
                Instantiate(test, this.parentTransform);
                Destroy(test);
            }
        }
    }

    Vector2 StringToVector2(string str)
    {
        string[] arr = str.Trim('{','}').Split(',');
        return new Vector2(float.Parse(arr[0]), float.Parse(arr[1]));
    }
}

