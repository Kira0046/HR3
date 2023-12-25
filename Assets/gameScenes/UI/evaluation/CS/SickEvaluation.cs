using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SickEvaluation : MonoBehaviour
{
    private float speed = 10.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        ///テクスチャ読み込み
        Vector2 mid = new(0.5f, 0.5f);
        string path = "Assets/Resource/evaluation/Sick.png";
        byte[] imagedata = File.ReadAllBytes(path);
        Texture2D texture = new(2, 2);
        texture.LoadImage(imagedata);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), mid);

        GameObject spriteObject = GameObject.Find("SickEvaluation");
        Image spriteOb = spriteObject.GetComponent<Image>();
        spriteOb.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        speed-=0.5f;
        transform.Translate(Vector3.up*speed);
    }
}
