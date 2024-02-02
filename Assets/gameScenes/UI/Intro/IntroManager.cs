using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{

    [SerializeField] GameObject readymask;
    [SerializeField] GameObject setmask;
    [SerializeField] GameObject gomask;
    // Start is called before the first frame update
    private void Awake()
    {
        ///readyテクスチャ読み込み
        Vector2 mid = new(0.5f, 0.5f);
        string readypath = "Assets/Resource/Intro/ready.png";
        byte[] readyimagedata = File.ReadAllBytes(readypath);
        Texture2D readytexture = new(2, 2);
        readytexture.LoadImage(readyimagedata);
        Sprite readysprite = Sprite.Create(readytexture, new Rect(0, 0, readytexture.width, readytexture.height), mid);

        GameObject readyspriteObject = GameObject.Find("Ready");

        Image readyspriteOb = readyspriteObject.GetComponent<Image>();
        readyspriteOb.sprite=readysprite;

        ///setテクスチャ読み込み
        string setpath = "Assets/Resource/Intro/set.png";
        byte[] setimagedata = File.ReadAllBytes(setpath);
        Texture2D settexture = new(2, 2);
        settexture.LoadImage(setimagedata);
        Sprite setsprite = Sprite.Create(settexture, new Rect(0, 0, settexture.width, settexture.height), mid);

        GameObject setspriteObject = GameObject.Find("Set");

        Image setspriteOb = setspriteObject.GetComponent<Image>();
        setspriteOb.sprite=setsprite;

        ///goテクスチャ読み込み
        string gopath = "Assets/Resource/Intro/go.png";
        byte[] goimagedata = File.ReadAllBytes(gopath);
        Texture2D gotexture = new(2, 2);
        gotexture.LoadImage(goimagedata);
        Sprite gosprite = Sprite.Create(gotexture, new Rect(0, 0, gotexture.width, gotexture.height), mid);

        GameObject gospriteObject = GameObject.Find("Go");

        Image gospriteOb = gospriteObject.GetComponent<Image>();
        gospriteOb.sprite=gosprite;

        ///マスクを非表示
        readymask.SetActive(false);
        setmask.SetActive(false);
        gomask.SetActive(false);

    }

    public void ToggleReady()
    {
        bool toggleready = readymask.activeSelf;
        readymask.SetActive(!toggleready);
    }

    public void ToggleSet()
    {
        bool toggleset = setmask.activeSelf;
        setmask.SetActive(!toggleset);
    }

    public void ToggleGo()
    {
        bool togglego = gomask.activeSelf;
        gomask.SetActive(!togglego);
    }


}
