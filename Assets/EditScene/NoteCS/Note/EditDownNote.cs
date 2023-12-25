using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EditDownNote : MonoBehaviour
{
    //const string BASE_TEXTURE = "NoteTexture/down";

    public float speed = 0.2f;
    public float y;
    public int notelane;
    public int longnote = 0;
    public int longtime = 0;
    private bool advance = true;

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

        GameObject spriteObject = GameObject.Find("EditDownNote");
        //Sprite sprite = Resources.Load<Sprite>(BASE_TEXTURE);

        SpriteRenderer spriteOb = spriteObject.GetComponent<SpriteRenderer>();
        spriteOb.sprite=sprite;
    }

    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (advance==true)
        {
            transform.Translate(Vector3.down*speed);
        }
        if (advance==false)
        {
            transform.Translate(Vector3.up*speed);
        }
    }

    public void SwitchAdvance()
    {
        if (advance==true)
        {
            advance = false;
            return;
        }
        if (advance==false)
        {
            advance=true;
            return;
        }
    }

    public void GoAdvance()
    {
        advance=true;
        GameObject editobject = GameObject.Find("EditSeat");
        EditSceneSetting script = editobject.GetComponent<EditSceneSetting>();
        if (script.stopflag==true)
        {
            speed=0;
        }
    }

    public void BackAdvance()
    {
        advance=false;
        GameObject editobject = GameObject.Find("EditSeat");
        EditSceneSetting script = editobject.GetComponent<EditSceneSetting>();
        if (script.stopflag==true)
        {
            speed=0.2f;
        }
    }

    public void Stop()
    {
        if (speed==0)
        {
            speed=0.2f;
            return;
        }
        if (speed==0.2f)
        {
            speed=0;
            return;
        }
    }
}
