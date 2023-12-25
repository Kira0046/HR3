using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class evaluation : MonoBehaviour
{
    ///出現位置はx=0,y=-150

    private float speed = 10.0f;

    private Sprite spriteSick;
    private Sprite spriteGood;
    private Sprite spriteBad;

    Image spriteOb;

    // Start is called before the first frame update
    private void Awake()
    {
        Vector2 mid = new(0.5f, 0.5f);
        ///テクスチャ読み込み
        //Sick
        string Sickpath = "Assets/Resource/evaluation/Sick.png";
        byte[] Sickimagedata = File.ReadAllBytes(Sickpath);
        Texture2D Sicktexture = new(2, 2);
        Sicktexture.LoadImage(Sickimagedata);

        spriteSick=Sprite.Create(Sicktexture, new Rect(0, 0, Sicktexture.width, Sicktexture.height), mid);
        //Good
        string Goodpath = "Assets/Resource/evaluation/Good.png";
        byte[] Goodimagedata = File.ReadAllBytes(Goodpath);
        Texture2D Goodtexture = new(2, 2);
        Goodtexture.LoadImage(Goodimagedata);

        spriteGood=Sprite.Create(Goodtexture, new Rect(0, 0, Goodtexture.width, Goodtexture.height), mid);
        //Bad
        string Badpath = "Assets/Resource/evaluation/Bad.png";
        byte[] Badimagedata = File.ReadAllBytes(Badpath);
        Texture2D Badtexture = new(2, 2);
        Badtexture.LoadImage(Badimagedata);

        spriteBad=Sprite.Create(Badtexture, new Rect(0, 0, Badtexture.width, Badtexture.height), mid);
        ///

        GameObject spriteObject = GameObject.Find("Evaluation");
        spriteOb=spriteObject.GetComponent<Image>();
        //spriteOb.sprite=spriteSick;

    }

    // Update is called once per frame
    void Update()
    {
        speed-=0.5f;
        transform.Translate(Vector3.up*speed);
    }

    public void SetSick()
    {
        spriteOb.sprite=spriteSick;
        Debug.Log("a");
    }

    public void SetGood()
    {
        spriteOb.sprite=spriteGood;
        Debug.Log("b");
    }

    public void SetBad()
    {
        spriteOb.sprite=spriteBad;
        Debug.Log("c");
    }
}
