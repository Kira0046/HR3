using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
//using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditSceneSetting : MonoBehaviour
{
    //prefabオブジェクト
    public GameObject preLeftNote;
    public GameObject preDownNote;
    public GameObject preUpNote;
    public GameObject preRightNote;

    public GameObject prelongLeftNote;
    public GameObject prelongDownNote;
    public GameObject prelongUpNote;
    public GameObject prelongRightNote;

    public GameObject preFinlongLeftNote;
    public GameObject preFinlongDownNote;
    public GameObject preFinlongUpNote;
    public GameObject preFinlongRightNote;

    List<GameObject> NoteList = new();
    int allnote = 0;
    List<int> NotelaneIndex = new(); //0:左 1:下 2:上 3:右

    //出現場所オブジェクト
    public GameObject LeftNoteSpawnObject;
    public GameObject DownNoteSpawnObject;
    public GameObject UpNoteSpawnObject;
    public GameObject RightNoteSpawnObject;

    private EditControl editControl;

    public float speed = 0.2f;
    private bool advance = true;

    public bool stopflag = false;

    [System.Serializable]
    public class NoteData
    {
        public float y;
        public float notelane;
        public float longpress;
        public float longtime;
    }

    [System.Serializable]
    public class MyData
    {
        public int NoteCount;
        public NoteData[] NoteData;
    }

    private void Awake()
    {
        //サイズ設定
        Screen.SetResolution(1280, 720, false);

        //fps制限
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        editControl=new EditControl();
        editControl.Enable();
    }

    private void OnDestroy()
    {
        editControl?.Dispose();
    }


    /// <summary>
    /// 各種操作のコールバック
    /// </summary>
    void EditControl()
    {
        editControl.edit.left.started+=Left;
        editControl.edit.down.started+=Down;
        editControl.edit.up.started+=Up;
        editControl.edit.right.started+=Right;
        editControl.edit.startandstopchart.started+=StartStop;
        editControl.edit.deletenote.started+=DeleteNote;
        editControl.edit.@switch.started+=Switch;
        editControl.edit.Complete.started+=Complete;
    }



    private void Left(InputAction.CallbackContext context)
    {
        Vector3 position = new(LeftNoteSpawnObject.transform.position.x, LeftNoteSpawnObject.transform.position.y, -1);
        NoteList.Add(Instantiate(preLeftNote, position, Quaternion.identity));
        allnote++;

        NotelaneIndex.Add(0);
        GameObject lastobject = NoteList[NoteList.Count-1];
        EditLeftNote leftnotescript = lastobject.GetComponent<EditLeftNote>();
        Vector3 seatposition = transform.position;
        leftnotescript.y=position.y-seatposition.y;

        if (stopflag==true)
        {
            leftnotescript.speed=0;
        }
    }

    private void Down(InputAction.CallbackContext context)
    {
        Vector3 position = new(DownNoteSpawnObject.transform.position.x, DownNoteSpawnObject.transform.position.y, -1);
        NoteList.Add(Instantiate(preDownNote, position, Quaternion.identity));
        allnote++;

        NotelaneIndex.Add(1);
        GameObject lastobject = NoteList[NoteList.Count-1];
        EditDownNote downnotescript = lastobject.GetComponent<EditDownNote>();
        Vector3 seatposition = transform.position;
        downnotescript.y=position.y-seatposition.y;
        if (stopflag==true)
        {
            downnotescript.speed=0;
        }
    }

    private void Up(InputAction.CallbackContext context)
    {
        Vector3 position = new(UpNoteSpawnObject.transform.position.x, UpNoteSpawnObject.transform.position.y, -1);
        NoteList.Add(Instantiate(preUpNote, position, Quaternion.identity));
        allnote++;

        NotelaneIndex.Add(2);
        GameObject lastobject = NoteList[NoteList.Count-1];
        EditUpNote upnotescript = lastobject.GetComponent<EditUpNote>();
        Vector3 seatposition = transform.position;
        upnotescript.y=position.y-seatposition.y;
        if (stopflag==true)
        {
            upnotescript.speed=0;
        }
    }

    private void Right(InputAction.CallbackContext context)
    {
        Vector3 position = new(RightNoteSpawnObject.transform.position.x, RightNoteSpawnObject.transform.position.y, -1);
        NoteList.Add(Instantiate(preRightNote, position, Quaternion.identity));
        allnote++;

        NotelaneIndex.Add(3);
        GameObject lastobject = NoteList[NoteList.Count-1];
        EditRightNote rightnotescript = lastobject.GetComponent<EditRightNote>();
        Vector3 seatposition = transform.position;
        rightnotescript.y=position.y-seatposition.y;
        if (stopflag==true)
        {
            rightnotescript.speed=0;
        }
    }

    private void StartStop(InputAction.CallbackContext context)
    {
        if (speed==0)
        {
            stopflag = false;
            speed=0.2f;
            for (int i = 0; i<NoteList.Count; i++)
            {
                if (NotelaneIndex[i]==0)
                {
                    NoteList[i].GetComponent<EditLeftNote>().Stop();
                }
                if (NotelaneIndex[i]==1)
                {
                    NoteList[i].GetComponent<EditDownNote>().Stop();
                }
                if (NotelaneIndex[i]==2)
                {
                    NoteList[i].GetComponent<EditUpNote>().Stop();
                }
                if (NotelaneIndex[i]==3)
                {
                    NoteList[i].GetComponent<EditRightNote>().Stop();
                }
            }
            return;
        }
        if (speed==0.2f)
        {
            stopflag=true;
            speed=0;
            for (int i = 0; i<NoteList.Count; i++)
            {
                if (NotelaneIndex[i]==0)
                {
                    NoteList[i].GetComponent<EditLeftNote>().Stop();
                }
                if (NotelaneIndex[i]==1)
                {
                    NoteList[i].GetComponent<EditDownNote>().Stop();
                }
                if (NotelaneIndex[i]==2)
                {
                    NoteList[i].GetComponent<EditUpNote>().Stop();
                }
                if (NotelaneIndex[i]==3)
                {
                    NoteList[i].GetComponent<EditRightNote>().Stop();
                }
            }
            return;
        }
    }


    private void DeleteNote(InputAction.CallbackContext context)
    {
        if (NoteList.Count>0)
        {

            Destroy(NoteList[NoteList.Count-1]);
            NoteList.RemoveAt(NoteList.Count-1);
            NotelaneIndex.RemoveAt(NotelaneIndex.Count-1);
        }
    }

    private void Switch(InputAction.CallbackContext context)
    {

    }

    private void Complete(InputAction.CallbackContext context)
    {
        MyData data = new();
        data.NoteCount=allnote;
        data.NoteData=new NoteData[allnote];
        for (int i = 0; i<data.NoteCount; i++)
        {
            //data.NoteData[i]=new NoteData { y=NoteList[i]., notelane=1, longpress=1, longtime=1 };

            if (NotelaneIndex[i]==0)
            {
                data.NoteData[i]=new NoteData
                {
                    y=NoteList[i].GetComponent<EditLeftNote>().y,
                    notelane=NotelaneIndex[i],
                    longpress=NoteList[i].GetComponent<EditLeftNote>().longnote,
                    longtime=NoteList[i].GetComponent<EditLeftNote>().longtime
                };
            }
            if (NotelaneIndex[i]==1)
            {
                data.NoteData[i]=new NoteData
                {
                    y=NoteList[i].GetComponent<EditDownNote>().y,
                    notelane=NotelaneIndex[i],
                    longpress=NoteList[i].GetComponent<EditDownNote>().longnote,
                    longtime=NoteList[i].GetComponent<EditDownNote>().longtime
                };
            }
            if (NotelaneIndex[i]==2)
            {
                data.NoteData[i]=new NoteData
                {
                    y=NoteList[i].GetComponent<EditUpNote>().y,
                    notelane=NotelaneIndex[i],
                    longpress=NoteList[i].GetComponent<EditUpNote>().longnote,
                    longtime=NoteList[i].GetComponent<EditUpNote>().longtime
                };
            }
            if (NotelaneIndex[i]==3)
            {
                data.NoteData[i]=new NoteData
                {
                    y=NoteList[i].GetComponent<EditRightNote>().y,
                    notelane=NotelaneIndex[i],
                    longpress=NoteList[i].GetComponent<EditRightNote>().longnote,
                    longtime=NoteList[i].GetComponent<EditRightNote>().longtime
                };
            }
        }
        string json = JsonUtility.ToJson(data);

        string path = "Assets/Resource/Output/test.json";
        System.IO.File.Create(path).Dispose();
        File.WriteAllText(path, json);
    }

    // Update is called once per frame
    void Update()
    {
        EditControl();

        if (editControl.edit.backchart.IsPressed()==false)
        {
            advance=true;
            if (stopflag==true)
            {
                speed=0;
            }
            for (int i = 0; i<NoteList.Count; i++)
            {
                if (NotelaneIndex[i]==0)
                {
                    NoteList[i].GetComponent<EditLeftNote>().GoAdvance();
                }
                if (NotelaneIndex[i]==1)
                {
                    NoteList[i].GetComponent<EditDownNote>().GoAdvance();
                }
                if (NotelaneIndex[i]==2)
                {
                    NoteList[i].GetComponent<EditUpNote>().GoAdvance();
                }
                if (NotelaneIndex[i]==3)
                {
                    NoteList[i].GetComponent<EditRightNote>().GoAdvance();
                }
            }
        }
        if (editControl.edit.backchart.IsPressed()==true)
        {
            advance=false;
            if (stopflag==true)
            {
                speed=0.2f;
            }
            for (int i = 0; i<NoteList.Count; i++)
            {
                if (NotelaneIndex[i]==0)
                {
                    NoteList[i].GetComponent<EditLeftNote>().BackAdvance();
                }
                if (NotelaneIndex[i]==1)
                {
                    NoteList[i].GetComponent<EditDownNote>().BackAdvance();
                }
                if (NotelaneIndex[i]==2)
                {
                    NoteList[i].GetComponent<EditUpNote>().BackAdvance();
                }
                if (NotelaneIndex[i]==3)
                {
                    NoteList[i].GetComponent<EditRightNote>().BackAdvance();
                }
            }

            GameObject audioObject = GameObject.Find("AudioManager");
            EditAudioManager audioscript = audioObject.GetComponent<EditAudioManager>();
            audioscript.Back();
        }

        if (advance==true)
        {
            transform.Translate(Vector3.down * speed);
        }

        if (advance==false)
        {
            transform.Translate(Vector3.up * speed);
        }
    }
}
