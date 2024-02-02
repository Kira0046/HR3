using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    Vector3 move = new(-11, -6, 0);
    Vector3 startposition = new();
    // Start is called before the first frame update
    private void Awake()
    {
        ///テクスチャ読み込み
        Vector2 mid = new(0.5f, 0.5f);
        string path = "Assets/Resource/menu/background.png";
        byte[] imagedata = File.ReadAllBytes(path);
        Texture2D texture = new(2, 2);
        texture.LoadImage(imagedata);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), mid);

        GameObject spriteObject1 = GameObject.Find("background");
        GameObject spriteObject2 = GameObject.Find("background2");
        GameObject spriteObject3 = GameObject.Find("background3");
        GameObject spriteObject4 = GameObject.Find("background4");

        Image spriteOb1 = spriteObject1.GetComponent<Image>();
        spriteOb1.sprite=sprite;
        Image spriteOb2 = spriteObject2.GetComponent<Image>();
        spriteOb2.sprite=sprite;
        Image spriteOb3 = spriteObject3.GetComponent<Image>();
        spriteOb3.sprite=sprite;
        Image spriteOb4 = spriteObject4.GetComponent<Image>();
        spriteOb4.sprite=sprite;

        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += move;
        if (transform.position.x < startposition.x-630)
        {
            transform.position =startposition;
        }
    }
}