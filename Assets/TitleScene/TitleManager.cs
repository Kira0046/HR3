using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        //サイズ設定
        Screen.SetResolution(1280, 720, false);

        //fps制限
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene()
    {
        GameObject gameobject=GameObject.Find("endboard");
        menubutton menuscript=gameobject.GetComponent<menubutton>();
        menuscript.moveflag = true;
    }

}
