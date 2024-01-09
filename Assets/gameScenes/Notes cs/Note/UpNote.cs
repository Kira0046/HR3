using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
//using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class UpNote : MonoBehaviour
{
    public float speed = 0.2f;
    public int longnote = 0;
    public int longtime = 0;
    //private int laneindex = 2;

    //const string BASE_TEXTURE = "NoteTexture/up";
    //const string LongBASE_TEXTURE = "NoteTexture/longup";
    const string FinBASE_TEXTURE = "NoteTexture/finup";

    //private NotesControl _notesControl;
    // Start is called before the first frame update

    private void Awake()
    {
        //ノーツ
        Vector2 mid = new(0.5f, 0.5f);
        string path = "Assets/Resource/NoteTexture/up.png";
        byte[] imagedata = File.ReadAllBytes(path);
        Texture2D texture = new(2, 2);
        texture.LoadImage(imagedata);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), mid);

        GameObject spriteObject = GameObject.Find("UpNote");
        //Sprite sprite = Resources.Load<Sprite>(BASE_TEXTURE);

        SpriteRenderer spriteOb = spriteObject.GetComponent<SpriteRenderer>();
        spriteOb.sprite=sprite;

        //ロングノーツ
        string longpath = "Assets/Resource/NoteTexture/uplong.png";
        byte[] longimagedata = File.ReadAllBytes(longpath);
        Texture2D longtexture = new(2, 2);
        longtexture.LoadImage(longimagedata);
        Sprite longsprite = Sprite.Create(longtexture, new Rect(0, 0, longtexture.width, longtexture.height), mid);
        GameObject longspriteObject = GameObject.Find("UplongNote");
        SpriteRenderer longspriteOb = longspriteObject.GetComponent<SpriteRenderer>();
        longspriteOb.sprite = longsprite;

        //ラストロングノーツ
        //GameObject finspriteObject = GameObject.Find("UplongfinNote");
        //Sprite finsprite = Resources.Load<Sprite>(FinBASE_TEXTURE);

        //SpriteRenderer finspriteOb = finspriteObject.GetComponent<SpriteRenderer>();
        //finspriteOb.sprite=finsprite;
    }

    public void Test()
    {
        Debug.Log("c");

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.down * speed);

    }
}