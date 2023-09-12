using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class LoadApi : MonoBehaviour
{
    public Transform parent;

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
                RectTransform rect = test.GetComponent<RectTransform>();
                rect.position = StringToVector2(img.position);
                rect.anchorMax = new Vector2(0, 0);
                rect.anchorMin = new Vector2(0, 0);
                rect.sizeDelta = new Vector2(150, 150);
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
                Instantiate(test, parent);
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

