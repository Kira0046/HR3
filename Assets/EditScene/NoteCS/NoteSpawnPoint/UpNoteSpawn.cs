using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UpNoteSpawn : MonoBehaviour
{
    //const string BASE_TEXTURE = "NoteTexture/upCollision";


    private void Awake()
    {
        ///テクスチャ読み込み
        Vector2 mid = new(0.5f, 0.5f);
        string path = "Assets/Resource/NoteTexture/upCollision.png";
        byte[] imagedata = File.ReadAllBytes(path);
        Texture2D texture = new(2, 2);
        texture.LoadImage(imagedata);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), mid);

        GameObject spriteObject = GameObject.Find("UpNoteSpawn");
        //Sprite sprite = Resources.Load<Sprite>(BASE_TEXTURE);

        SpriteRenderer spriteOb = spriteObject.GetComponent<SpriteRenderer>();
        spriteOb.sprite=sprite;
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    //void Update()
    //{

    //}
}
