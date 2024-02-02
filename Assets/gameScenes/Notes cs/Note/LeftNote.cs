using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LeftNote : MonoBehaviour
{
    public float speed = 0.2f;
    public int longnote = 0;
    public int longtime = 0;
    //private int laneindex = 0;

    //const string BASE_TEXTURE = "NoteTexture/left";
    //const string LongBASE_TEXTURE = "NoteTexture/longleft";
    const string FinBASE_TEXTURE = "NoteTexture/finleft";

    //private NotesControl _notesControl;
    // Start is called before the first frame update
    private void Awake()
    {
        ///�e�N�X�`���ǂݍ���
        //�m�[�c
        Vector2 mid = new(0.5f, 0.5f);
        string path = "Assets/Resource/NoteTexture/left.png";
        byte[] imagedata = File.ReadAllBytes(path);
        Texture2D texture = new(2, 2);
        texture.LoadImage(imagedata);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), mid);

        GameObject spriteObject = GameObject.Find("LeftNote");
        //Sprite sprite = Resources.Load<Sprite>(BASE_TEXTURE);

        SpriteRenderer spriteOb = spriteObject.GetComponent<SpriteRenderer>();
        spriteOb.sprite=sprite;

        //�����O�m�[�c
        string longpath = "Assets/Resource/NoteTexture/leftlong.png";
        byte[] longimagedata = File.ReadAllBytes(longpath);
        Texture2D longtexture = new(2, 2);
        longtexture.LoadImage(longimagedata);
        Sprite longsprite = Sprite.Create(longtexture, new Rect(0, 0, longtexture.width, longtexture.height), mid);
        GameObject longspriteObject = GameObject.Find("LeftlongNote");
        SpriteRenderer longspriteOb = longspriteObject.GetComponent<SpriteRenderer>();
        longspriteOb.sprite = longsprite;

        //���X�g�����O�m�[�c
        string finlongpath = "Assets/Resource/NoteTexture/leftfinlong.png";
        byte[] finlongimagedata = File.ReadAllBytes(finlongpath);
        Texture2D finlongtexture = new(2, 2);
        finlongtexture.LoadImage(finlongimagedata);
        Sprite finlongsprite = Sprite.Create(finlongtexture, new Rect(0, 0, finlongtexture.width, finlongtexture.height), mid);
        GameObject finlongspriteObject = GameObject.Find("LeftlongfinNote");
        SpriteRenderer finlongspriteOb = finlongspriteObject.GetComponent<SpriteRenderer>();
        finlongspriteOb.sprite = finlongsprite;
    }

    public void Test()
    {
        Debug.Log("a");

    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector3.down * speed);


    }
}
