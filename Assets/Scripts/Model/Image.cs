using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Image
{
    public string position;
    public string contentsize;
    public int star_order;
    public int z_order;
    public bool touchable;
    public Touch[] touch;
    public string type;
    public string sequence;
    public string animation_type;
    public bool animation_reset;
    public bool repeat_animation;
    public int animation_order;
    public int word_id;
}

[System.Serializable]
public class Touch
{
    public string star_position;
    public string boundingbox;
    public string[] vertices;
}

[System.Serializable]
public class Text
{
    public string word_id;
    public string boundingbox;
    public string[] config_image;
    public string[] config_audio;
}

[System.Serializable]
public class Backgroud
{
    public string path;
    public string position;
}

[System.Serializable]
public class ImageContent
{
    public Image[] image;
    public Text[] text;
    public Backgroud bg_img;
    public string highlight_color;
    public Backgroud normal_color;
    public int line_height;
    public int fontsize;
    public string box_type;
}
