using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class EnemyManager : MonoBehaviour
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

    //判定オブジェクト
    public GameObject LeftNoteJudgeObject;
    public GameObject DownNoteJudgeObject;
    public GameObject UpNoteJudgeObject;
    public GameObject RightNoteJudgeObject;


    //ノーツリスト
    List<GameObject> NoteList = new();
    List<GameObject> LeftLongNoteList = new();
    List<GameObject> DownLongNoteList = new();
    List<GameObject> UpLongNoteList = new();
    List<GameObject> RightLongNoteList = new();
    List<int> NotelaneIndex = new(); //0:左 1:下 2:上 3:右

    //それぞれのレーンのノーツ数
    int LeftNoteCount = 0;
    int DownNoteCount = 0;
    int UpNoteCount = 0;
    int RightNoteCount = 0;

    int leftlongtime = 0;
    int downlongtime = 0;
    int uplongtime = 0;
    int rightlongtime = 0;

    GameObject poseobject;
    EnemyTexture texturescript;

    RootObject noteData;
    [System.Serializable]
    public class NoteData
    {
        public float y;
        public float notelane;
        public float longpress;
        public float longtime;
    }

    [System.Serializable]
    public class RootObject
    {
        public string NoteCount;
        public List<NoteData> NoteData;
    }

    private void Awake()
    {
        poseobject=GameObject.Find("Enemy");
        texturescript=poseobject.GetComponent<EnemyTexture>();
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadJson();
        for (int i = 0; i < int.Parse(noteData.NoteCount); i++)
        {

            //左
            if (noteData.NoteData[i].notelane == 0)
            {
                Vector3 position = new(LeftNoteJudgeObject.transform.position.x, noteData.NoteData[i].y, -1);

                if (noteData.NoteData[i].longpress == 0)
                {
                    NoteList.Add(Instantiate(preLeftNote, position, Quaternion.identity));
                    NotelaneIndex.Add(0);
                    LeftNoteCount++;
                }
                if (noteData.NoteData[i].longpress == 1)
                {
                    NoteList.Add(Instantiate(preLeftNote, position, Quaternion.identity));
                    NotelaneIndex.Add(0);
                    LeftNoteCount++;

                    GameObject lastNote = NoteList[NoteList.Count-1];
                    LeftNote leftNoteScript = lastNote.GetComponent<LeftNote>();
                    leftNoteScript.longnote = 1;
                    leftNoteScript.longtime=(int)noteData.NoteData[i].longtime;

                    for (int k = 0; k < noteData.NoteData[i].longtime; k++)
                    {
                        if (k == 0)
                        {
                            position.y += 0.75f;
                            LeftLongNoteList.Add(Instantiate(prelongLeftNote, position, Quaternion.identity));
                        }
                        if (k <= noteData.NoteData[i].longtime - 2&&k > 0)
                        {
                            position.y += 0.5f;
                            LeftLongNoteList.Add(Instantiate(prelongLeftNote, position, Quaternion.identity));
                        }
                        if (k == noteData.NoteData[i].longtime - 1)
                        {
                            position.y += 0.5f;
                            LeftLongNoteList.Add(Instantiate(preFinlongLeftNote, position, Quaternion.identity));
                        }
                    }
                }
            }

            //下
            if (noteData.NoteData[i].notelane == 1)
            {
                Vector3 position = new(DownNoteJudgeObject.transform.position.x, noteData.NoteData[i].y, -1);

                if (noteData.NoteData[i].longpress == 0)
                {
                    NoteList.Add(Instantiate(preDownNote, position, Quaternion.identity));
                    NotelaneIndex.Add(1);
                    DownNoteCount++;
                }
                if (noteData.NoteData[i].longpress == 1)
                {
                    NoteList.Add(Instantiate(preDownNote, position, Quaternion.identity));
                    NotelaneIndex.Add(1);
                    DownNoteCount++;

                    GameObject lastObject = NoteList[NoteList.Count-1];
                    DownNote downNoteScript = lastObject.GetComponent<DownNote>();
                    downNoteScript.longnote = 1;
                    downNoteScript.longtime=(int)noteData.NoteData[i].longtime;

                    for (int k = 0; k < noteData.NoteData[i].longtime; k++)
                    {
                        if (k == 0)
                        {
                            position.y += 0.75f;
                            DownLongNoteList.Add(Instantiate(prelongDownNote, position, Quaternion.identity));
                        }
                        if (k <= noteData.NoteData[i].longtime - 2&&k > 0)
                        {
                            position.y += 0.5f;
                            DownLongNoteList.Add(Instantiate(prelongDownNote, position, Quaternion.identity));
                        }
                        if (k == noteData.NoteData[i].longtime - 1)
                        {
                            position.y += 0.5f;
                            DownLongNoteList.Add(Instantiate(preFinlongDownNote, position, Quaternion.identity));
                        }
                    }
                }
            }

            if (noteData.NoteData[i].notelane == 2)
            {
                Vector3 position = new(UpNoteJudgeObject.transform.position.x, noteData.NoteData[i].y, -1);

                if (noteData.NoteData[i].longpress == 0)
                {
                    NoteList.Add(Instantiate(preUpNote, position, Quaternion.identity));
                    NotelaneIndex.Add(2);
                    UpNoteCount++;
                }
                if (noteData.NoteData[i].longpress == 1)
                {
                    NoteList.Add(Instantiate(preUpNote, position, Quaternion.identity));
                    NotelaneIndex.Add(2);
                    UpNoteCount++;

                    GameObject lastObject = NoteList[NoteList.Count-1];
                    UpNote upNoteScript = lastObject.GetComponent<UpNote>();
                    upNoteScript.longnote=1;
                    upNoteScript.longtime=(int)noteData.NoteData[i].longtime;

                    for (int k = 0; k < noteData.NoteData[i].longtime; k++)
                    {
                        if (k == 0)
                        {
                            position.y += 0.75f;
                            UpLongNoteList.Add(Instantiate(prelongUpNote, position, Quaternion.identity));
                        }
                        if (k <= noteData.NoteData[i].longtime - 2 && k > 0)
                        {
                            position.y += 0.5f;
                            UpLongNoteList.Add(Instantiate(prelongUpNote, position, Quaternion.identity));
                        }
                        if (k == noteData.NoteData[i].longtime - 1)
                        {
                            position.y += 0.5f;
                            UpLongNoteList.Add(Instantiate(preFinlongUpNote, position, Quaternion.identity));
                        }
                    }
                }
            }

            if (noteData.NoteData[i].notelane == 3)
            {
                Vector3 position = new(RightNoteJudgeObject.transform.position.x, noteData.NoteData[i].y, -1);

                if (noteData.NoteData[i].longpress == 0)
                {
                    NoteList.Add(Instantiate(preRightNote, position, Quaternion.identity));
                    NotelaneIndex.Add(3);
                    RightNoteCount++;
                }
                if (noteData.NoteData[i].longpress == 1)
                {
                    NoteList.Add(Instantiate(preRightNote, position, Quaternion.identity));
                    NotelaneIndex.Add(3);
                    RightNoteCount++;

                    GameObject lastObject = NoteList[NoteList.Count-1];
                    RightNote rightNoteScript = lastObject.GetComponent<RightNote>();
                    rightNoteScript.longnote = 1;
                    rightNoteScript.longtime=(int)noteData.NoteData[i].longtime;

                    for (int k = 0; k < noteData.NoteData[i].longtime; k++)
                    {
                        if (k == 0)
                        {
                            position.y += 0.75f;
                            RightLongNoteList.Add(Instantiate(prelongRightNote, position, Quaternion.identity));
                        }
                        if (k <= noteData.NoteData[i].longtime - 2 && k > 0)
                        {
                            position.y += 0.5f;
                            RightLongNoteList.Add(Instantiate(prelongRightNote, position, Quaternion.identity));
                        }
                        if (k == noteData.NoteData[i].longtime - 1)
                        {
                            position.y += 0.5f;
                            RightLongNoteList.Add(Instantiate(preFinlongRightNote, position, Quaternion.identity));
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Json読み込み
    /// </summary>
    private void LoadJson()
    {
        if (!File.Exists("Assets/Resource/Chart/Enemynote.json"))
        {
            Debug.Log("Setting File not Exists(Enemy)");
            return;
        }
        var json = File.ReadAllText("Assets/Resource/Chart/Enemynote.json");
        noteData = JsonUtility.FromJson<RootObject>(json);
    }

    // Update is called once per frame
    void Update()
    {
        DestroyNote();
    }

    private void DestroyNote()
    {
        for(int i = 0; i < NoteList.Count; i++)
        {
            if ((NoteList[i].transform.position.y - LeftNoteJudgeObject.transform.position.y) < 0.0f)
            {
                Destroy(NoteList[i]);
                NoteList.RemoveAt(i);
                NotelaneIndex.RemoveAt(i);
            }
        }
        for (int i = 0; i<LeftLongNoteList.Count; i++)
        {
            if ((LeftLongNoteList[i].transform.position.y - LeftNoteJudgeObject.transform.position.y) < 0.0f)
            {
                Destroy(LeftLongNoteList[i]);
                LeftLongNoteList.RemoveAt(i);
            }
        }
        for (int i = 0; i < DownLongNoteList.Count; i++)
        {
            if ((DownLongNoteList[i].transform.position.y-LeftNoteJudgeObject.transform.position.y) < 0.0f)
            {
                Destroy(DownLongNoteList[i]);
                DownLongNoteList.RemoveAt(i);
            }
        }
        for (int i = 0; i < UpLongNoteList.Count; i++)
        {
            if ((UpLongNoteList[i].transform.position.y-LeftNoteJudgeObject.transform.position.y) < 0.0f)
            {
                Destroy(UpLongNoteList[i]);
                UpLongNoteList.RemoveAt(i);
            }
        }
        for (int i = 0; i< RightLongNoteList.Count;i++)
        {
            if ((RightLongNoteList[i].transform.position.y-LeftNoteJudgeObject.transform.position.y) < 0.0f)
            {
                Destroy(RightLongNoteList[i]);
                RightLongNoteList.RemoveAt(i);
            }
        }
    }
}
