using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RightNoteIcon : MonoBehaviour
{
    private void Awake()
    {
        ///テクスチャ読み込み
        Vector2 mid = new(0.5f, 0.5f);
        string path = "Assets/Resource/NoteTexture/right.png";
        byte[] imagedata = File.ReadAllBytes(path);
        Texture2D texture = new(2, 2);
        texture.LoadImage(imagedata);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), mid);

        GameObject spriteObject = GameObject.Find("RightNote");
        //Sprite sprite = Resources.Load<Sprite>(BASE_TEXTURE);

        Image spriteOb = spriteObject.GetComponent<Image>();
        spriteOb.sprite=sprite;
    }
}
