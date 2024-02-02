using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DownNote : MonoBehaviour
{
    public float speed = 0.2f;
    public int longnote = 0;
    public int longtime = 0;
    //private int laneindex = 1;

    //const string BASE_TEXTURE = "NoteTexture/down";
    //const string LongBASE_TEXTURE = "NoteTexture/longdown";
    const string FinBASE_TEXTURE = "NoteTexture/findown";

    //private NotesControl _notesControl;
    // Start is called before the first frame update

    private void Awake()
    {
        ///テクスチャ読み込み
        //ノーツ
        Vector2 mid = new(0.5f, 0.5f);
        string path = "Assets/Resource/NoteTexture/down.png";
        byte[] imagedata = File.ReadAllBytes(path);
        Texture2D texture = new(2, 2);
        texture.LoadImage(imagedata);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), mid);

        GameObject spriteObject = GameObject.Find("DownNote");
        //Sprite sprite = Resources.Load<Sprite>(BASE_TEXTURE);

        SpriteRenderer spriteOb = spriteObject.GetComponent<SpriteRenderer>();
        spriteOb.sprite=sprite;
        //ロングノーツ
        string longpath = "Assets/Resource/NoteTexture/downlong.png";
        byte[] longimagedata = File.ReadAllBytes(longpath);
        Texture2D longtexture = new(2, 2);
        longtexture.LoadImage(longimagedata);
        Sprite longsprite = Sprite.Create(longtexture, new Rect(0, 0, longtexture.width, longtexture.height), mid);
        GameObject longspriteObject = GameObject.Find("DownlongNote");
        SpriteRenderer longspriteOb = longspriteObject.GetComponent<SpriteRenderer>();
        longspriteOb.sprite = longsprite;

        //ラストロングノーツ
        string finlongpath = "Assets/Resource/NoteTexture/downfinlong.png";
        byte[] finlongimagedata = File.ReadAllBytes(finlongpath);
        Texture2D finlongtexture = new(2, 2);
        finlongtexture.LoadImage(finlongimagedata);
        Sprite finlongsprite = Sprite.Create(finlongtexture, new Rect(0, 0, finlongtexture.width, finlongtexture.height), mid);
        GameObject finlongspriteObject = GameObject.Find("DownlongfinNote");
        SpriteRenderer finlongspriteOb = finlongspriteObject.GetComponent<SpriteRenderer>();
        finlongspriteOb.sprite = finlongsprite;

    }

    public void Test()
    {
        Debug.Log("b");

    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector3.down * speed);


    }
}
