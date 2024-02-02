using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RightNote : MonoBehaviour
{
    public float speed = 0.2f;
    public int longnote = 0;
    public int longtime = 0;
    //private int laneindex = 3;

    //const string BASE_TEXTURE = "NoteTexture/right";
    //const string LongBASE_TEXTURE = "NoteTexture/longright";
    const string FinBASE_TEXTURE = "NoteTexture/finright";


    //private NotesControl _notesControl;
    // Start is called before the first frame update

    private void Awake()
    {
        //ノーツ
        Vector2 mid = new(0.5f, 0.5f);
        string path = "Assets/Resource/NoteTexture/right.png";
        byte[] imagedata = File.ReadAllBytes(path);
        Texture2D texture = new(2, 2);
        texture.LoadImage(imagedata);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), mid);

        GameObject spriteObject = GameObject.Find("RightNote");
        //Sprite sprite = Resources.Load<Sprite>(BASE_TEXTURE);

        SpriteRenderer spriteOb = spriteObject.GetComponent<SpriteRenderer>();
        spriteOb.sprite = sprite;
        //ロングノーツ
        string longpath = "Assets/Resource/NoteTexture/rightlong.png";
        byte[] longimagedata = File.ReadAllBytes(longpath);
        Texture2D longtexture = new(2, 2);
        longtexture.LoadImage(longimagedata);
        Sprite longsprite=Sprite.Create(longtexture,new Rect(0,0,longtexture.width,longtexture.height), mid);
        GameObject longspriteObject = GameObject.Find("RightlongNote");
        SpriteRenderer longspriteOb=longspriteObject.GetComponent<SpriteRenderer>();
        longspriteOb.sprite = longsprite;

        //ラストロングノーツ
        string finlongpath = "Assets/Resource/NoteTexture/rightfinlong.png";
        byte[] finlongimagedata = File.ReadAllBytes(finlongpath);
        Texture2D finlongtexture = new(2, 2);
        finlongtexture.LoadImage(finlongimagedata);
        Sprite finlongsprite = Sprite.Create(finlongtexture, new Rect(0, 0, finlongtexture.width, finlongtexture.height), mid);
        GameObject finlongspriteObject = GameObject.Find("RightlongfinNote");
        SpriteRenderer finlongspriteOb = finlongspriteObject.GetComponent<SpriteRenderer>();
        finlongspriteOb.sprite = finlongsprite;
    }

    public void Test()
    {
        Debug.Log("d");

    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector3.down * speed);


    }
}
