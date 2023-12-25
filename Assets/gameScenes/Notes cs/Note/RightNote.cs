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
        //GameObject longspriteObject = GameObject.Find("RightlongNote");
        //Sprite longsprite = Resources.Load<Sprite>(LongBASE_TEXTURE);

        //SpriteRenderer longspriteOb = longspriteObject.GetComponent<SpriteRenderer>();
        //longspriteOb.sprite=longsprite;

        //ラストロングノーツ
        GameObject finspriteObject = GameObject.Find("RightlongfinNote");
        Sprite finsprite = Resources.Load<Sprite>(FinBASE_TEXTURE);

        SpriteRenderer finspriteOb = finspriteObject.GetComponent<SpriteRenderer>();
        finspriteOb.sprite=finsprite;
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
