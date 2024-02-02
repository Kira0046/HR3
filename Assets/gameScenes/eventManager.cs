using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    int ready = 5;
    int ready3 = 20;
    int ready2 = 20;
    int ready1 = 20;
    int readygo = 20;
    // Start is called before the first frame update
    private void Awake()
    {
        //サイズ設定
        Screen.SetResolution(1280, 720, false);

        //fps制限
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        ready=5;
        ready3 = 20;
        ready2 = 20;
        ready1 = 20;
        readygo = 20;
    }

    // Update is called once per frame
    void Update()
    {
        Ready();
    }

    //カウントダウン
    private void Ready()
    {
        ready-=1;
        if (ready < 0)
        {
            ready3-=1;
            if (ready3 < 0)
            {
                ready2-=1;
                if (ready2 < 0)
                {
                    ready1-=1;
                    if (ready1 < 0)
                    {
                        readygo-=1;
                        if(readygo < 0)
                        {

                        }
                    }
                }
            }
        }
    }
}
