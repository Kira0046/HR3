using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
#pragma warning disable IDE0059 // 値の不必要な代入
#pragma warning disable IDE0060

public class PlayerTexture : MonoBehaviour
{
    //const string BASE_TEXTURE = "Character/base/base";
    int basefilecount = 0;
    float looptime = 0.0f;
    float transitiontime = 0.0f;


    bool up = false;
    bool down = false;
    bool left = false;
    bool right = false;
    float transPosetime = 0.0f;

    //const string UP_TEXTURE = "Character/up";
    //const string DOWN_TEXTURE = "Character/down";
    //const string RIGHT_TEXTURE = "Character/right";
    //const string LEFT_TEXTURE = "Character/left";

    private Sprite spriteDown;
    private Sprite spriteLeft;
    private Sprite spriteUp;
    private Sprite spriteRight;
    Sprite[] basesprite;
    SpriteRenderer spriteOb;

    private void Awake()
    {
        ///テクスチャ読み込み
        Vector2 mid = new(0.5f, 0.5f);
        //左
        string leftpath = "Assets/Resource/Character/Player/left.png";
        byte[] leftimagedata = File.ReadAllBytes(leftpath);
        Texture2D lefttexture = new(2, 2);
        lefttexture.LoadImage(leftimagedata);

        spriteLeft=Sprite.Create(lefttexture, new Rect(0, 0, lefttexture.width, lefttexture.height), mid);
        //下
        string downpath = "Assets/Resource/Character/Player/down.png";
        byte[] downimagedata = File.ReadAllBytes(downpath);
        Texture2D downtexture = new(2, 2);
        downtexture.LoadImage(downimagedata);

        spriteDown=Sprite.Create(downtexture, new Rect(0, 0, downtexture.width, downtexture.height), mid);
        //上
        string uppath = "Assets/Resource/Character/Player/up.png";
        byte[] upimagedata = File.ReadAllBytes(uppath);
        Texture2D uptexture = new(2, 2);
        uptexture.LoadImage(upimagedata);

        spriteUp=Sprite.Create(uptexture, new Rect(0, 0, uptexture.width, uptexture.height), mid);
        //右
        string rightpath = "Assets/Resource/Character/Player/right.png";
        byte[] rightimagedata = File.ReadAllBytes(rightpath);
        Texture2D righttexture = new(2, 2);
        righttexture.LoadImage(rightimagedata);

        spriteRight=Sprite.Create(righttexture, new Rect(0, 0, righttexture.width, righttexture.height), mid);
        ///

        LoadBASEPose();

        GameObject spriteObject = GameObject.Find("Player");
        spriteOb = spriteObject.GetComponent<SpriteRenderer>();
        spriteOb.sprite=basesprite[0];

        transitiontime=30.0f/(float)basefilecount;
    }

    // Update is called once per frame
    void Update()
    {
        looptime+=1.0f;
        if (looptime>=30.0f)
        {
            looptime=0.0f;
        }

        for (float i = 0; i<basefilecount; i++)
        {
            if (transitiontime*i <= looptime && looptime <= transitiontime*(i+1))
            {
                if (up==false&&down==false&&left == false&&right == false)
                {
                    spriteOb.sprite=basesprite[(int)i];
                }
            }
        }

        ChangePose();

    }



    private void LoadBASEPose()
    {
        string FileCountpath = "Assets/Resource/Character/Player/base";
        DirectoryInfo dir = new(FileCountpath);
        FileInfo[] info = dir.GetFiles("*.*", SearchOption.AllDirectories);

        foreach (FileInfo file in info)
        {
            if (file.Extension!=".meta")
            {
                basefilecount++;
            }
        }
        Debug.Log(basefilecount);

        basesprite=new Sprite[basefilecount];
        for (int i = 0; i < basefilecount; i++)
        {
            Vector2 mid = new(0.5f, 0.5f);
            string path = "Assets/Resource/Character/Player/base/base";
            string extension = ".png";
            byte[] imagedata = File.ReadAllBytes(path+i+extension);
            Texture2D texture = new(2, 2);
            texture.LoadImage(imagedata);
            basesprite[i]=Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), mid);

            //basesprite[i]=Resources.Load<Sprite>(BASE_TEXTURE+i);
        }
    }

    public void Up()
    {
        if (up==true)
        {
            up = false;
            up=true;
            SetChangePose();
            return;
        }
        up=true;
        SetChangePose();
    }

    public void Down()
    {
        if (down==true)
        {
            down = false;
            down=true;
            SetChangePose();
            return;
        }
        down=true;
        SetChangePose();
    }

    public void Left()
    {
        if (left == true)
        {
            left = false;
            left = true;
            SetChangePose();
            return;
        }
        left=true;
        SetChangePose();
    }

    public void Right()
    {
        if (right == true)
        {
            right = false;
            right = true;
            SetChangePose();
            return;
        }
        right=true;
        SetChangePose();
    }

    private void SetChangePose()
    {
        if (up==true)
        {
            transPosetime=20.0f;

        }

        if (down==true)
        {
            transPosetime=20.0f;
        }

        if (left==true)
        {
            transPosetime=20.0f;
        }

        if (right==true)
        {
            transPosetime=20.0f;
        }
    }

    private void ChangePose()
    {
        if (transPosetime>0)
        {
            transPosetime-=1.0f;
            if (up==true)
            {
                spriteOb.sprite=spriteUp;
            }
            if (down==true)
            {
                spriteOb.sprite = spriteDown;
            }
            if (left==true)
            {
                spriteOb.sprite= spriteLeft;
            }
            if (right==true)
            {
                spriteOb.sprite=spriteRight;
            }
        }

        if (transPosetime<=0)
        {
            up=false;
            down=false;
            left=false;
            right=false;
        }
    }
}
