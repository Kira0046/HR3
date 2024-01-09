using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyLeftCollisionNote : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        ///テクスチャ読み込み
        Vector2 mid = new Vector2(0.5f, 0.5f);
        string path = "Assets/Resource/NoteTexture/leftCollision.png";
        byte[] imagedata = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(imagedata);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), mid);

        GameObject spriteObject = GameObject.Find("EnemyLeftNoteCollision");
        //Sprite sprite = Resources.Load<Sprite>(BASE_TEXTURE);

        SpriteRenderer spriteOb = spriteObject.GetComponent<SpriteRenderer>();
        spriteOb.sprite=sprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
