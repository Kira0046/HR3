using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;

//using UnityEditor.Experimental.GraphView;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private InputActionReference _LeftactionRef;
    [SerializeField] private InputActionReference _DownactionRef;
    [SerializeField] private InputActionReference _UpactionRef;
    [SerializeField] private InputActionReference _RightactionRef;


    //private GameObject NoteObject;
    //LeftNote leftNoteScript;
    //DownNote downNoteScript;
    //UpNote upNoteScript;
    //RightNote rightNoteScript;

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

    public GameObject preSickEvaluation;
    public GameObject preGoodEvaluation;
    public GameObject preBadEvaluation;
    public GameObject canvas;

    bool leftuselongnote = false;
    bool downuselongnote = false;
    bool upuselongnote = false;
    bool rightuselongnote = false;

    //ノーツリスト
    List<GameObject> NoteList = new();
    List<GameObject> LeftLongNoteList = new();
    List<GameObject> DownLongNoteList = new();
    List<GameObject> UpLongNoteList = new();
    List<GameObject> RightLongNoteList = new();
    List<int> NotelaneIndex = new(); //0:左 1:下 2:上 3:右
    List<GameObject> EvaluationList = new();

    //それぞれのレーンのノーツ数
    int LeftNoteCount = 0;
    int DownNoteCount = 0;
    int UpNoteCount = 0;
    int RightNoteCount = 0;

    int leftlongtime = 0;
    int downlongtime = 0;
    int uplongtime = 0;
    int rightlongtime = 0;

    //判定オブジェクト
    public GameObject LeftNoteJudgeObject;
    public GameObject DownNoteJudgeObject;
    public GameObject UpNoteJudgeObject;
    public GameObject RightNoteJudgeObject;

    GameObject poseObject;
    PlayerTexture texturescript;

    RootObject noteData;
    [System.Serializable]
    public class NoteData
    {
        public float y;
        public float notelane;
        public float longpress;  //0:not long  1:long
        public float longtime;
    }

    [System.Serializable]
    public class RootObject
    {
        public string NoteCount;
        public List<NoteData> NoteData;
    }

    public void Awake()
    {
        //Input System 有効化
        _LeftactionRef.action.Enable();
        _DownactionRef.action.Enable();
        _UpactionRef.action.Enable();
        _RightactionRef.action.Enable();

        poseObject=GameObject.Find("Player");
        texturescript=poseObject.GetComponent<PlayerTexture>();
    }


    // Start is called before the first frame update
    public void Start()
    {
        ///ノーツ作成
        LoadJson();
        for (int i = 0; i < int.Parse(noteData.NoteCount); i++)
        {

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
    /// json読み込み
    /// </summary>
    private void LoadJson()
    {
        if (!File.Exists("Assets/Resource/Chart/Playernote.json"))
        {
            Debug.Log("Setting File not Exists(Player)");
            return;
        }


        var json = File.ReadAllText("Assets/Resource/Chart/Playernote.json");
        noteData = JsonUtility.FromJson<RootObject>(json);
    }

    /// <summary>
    /// 評価作成
    /// </summary>
    private void CreateSickEvaluation()
    {
        Vector3 position = new(0, -150, 0);
        GameObject newEvaluation = Instantiate(preSickEvaluation, position, Quaternion.identity);
        newEvaluation.transform.SetParent(canvas.transform, false);
        EvaluationList.Add(newEvaluation);
    }
    private void CreateGoodEvaluation()
    {
        Vector3 position = new(0, -150, 0);
        GameObject newEvaluation = Instantiate(preGoodEvaluation, position, Quaternion.identity);
        newEvaluation.transform.SetParent(canvas.transform, false);
        EvaluationList.Add(newEvaluation);
    }
    private void CreateBadEvaluation()
    {
        Vector3 position = new(0, -150, 0);
        GameObject newEvaluation = Instantiate(preBadEvaluation, position, Quaternion.identity);
        newEvaluation.transform.SetParent(canvas.transform, false);
        EvaluationList.Add(newEvaluation);
    }


    private void OnDestroy()
    {

        _LeftactionRef.action.Dispose();
        _DownactionRef.action.Dispose();
        _UpactionRef.action.Dispose();
        _RightactionRef.action.Dispose();

    }

    private void NotesKey()
    {
        _UpactionRef.action.started += UpNotes;
        _DownactionRef.action.started += DownNotes;
        _LeftactionRef.action.started += LeftNotes;
        _RightactionRef.action.started += RightNotes;

        LeftLongNoteProcess();
        DownLongNoteProsess();
        UpLongNoteProsess();
        RightLongNoteProcess();
    }

    /// <summary>
    /// コールバック
    /// </summary>
    private void LeftNotes(InputAction.CallbackContext context)
    {
        LeftNoteProcessing();
        texturescript.Left();
        CreateSickEvaluation();
    }

    private void DownNotes(InputAction.CallbackContext context)
    {
        DownNoteProcessing();
        texturescript.Down();
        CreateGoodEvaluation();
    }

    private void UpNotes(InputAction.CallbackContext context)
    {
        UpNoteProcessing();
        texturescript.Up();
        CreateBadEvaluation();
    }

    private void RightNotes(InputAction.CallbackContext context)
    {
        RightNoteProcessing();
        texturescript.Right();
    }

    /// <summary>
    /// 毎フレーム処理
    /// </summary>
    void Update()
    {
        NotesKey();

        DestroyNote();
        DestroyEvaluation();
    }



    /// <summary>
    /// ノーツ処理
    /// </summary>
    //左
    private void LeftNoteProcessing()
    {
        if (NotelaneIndex.Count == 0)
        {
            return;
        }

        if (LeftNoteCount <= 0)
        {
            return;
        }

        for (int i = 0; i < 8; i++)
        {
            if (NotelaneIndex[i] == 0)
            {
                LeftNoteJudge(i);
                return;
            }
        }
    }

    //下
    private void DownNoteProcessing()
    {
        if (NotelaneIndex.Count == 0)
        {
            return;
        }
        if (DownNoteCount <= 0)
        {
            return;
        }

        for (int i = 0; i < 8; i++)
        {
            if (NotelaneIndex[i] == 1)
            {
                DownNoteJudge(i);
                return;
            }
        }
    }

    //上
    private void UpNoteProcessing()
    {
        if (NotelaneIndex.Count == 0)
        {
            return;
        }
        if (UpNoteCount <= 0)
        {
            return;
        }

        for (int i = 0; i < 8; i++)
        {
            if (NotelaneIndex[i] == 2)
            {
                UpNoteJudge(i);
                return;
            }
        }
    }

    //右
    private void RightNoteProcessing()
    {
        if (NotelaneIndex.Count == 0)
        {
            return;
        }

        if (RightNoteCount <= 0)
        {
            return;
        }

        for (int i = 0; i < 8; i++)
        {
            if (NotelaneIndex[i] == 3)
            {
                RightNoteJudge(i);
                return;
            }
        }
    }


    /// <summary>
    /// 判定
    /// </summary>
    //左
    private void LeftNoteJudge(int i)
    {
        Vector3 CollisionpositionLeft = LeftNoteJudgeObject.transform.position;

        if (Mathf.Abs(CollisionpositionLeft.y - NoteList[i].transform.position.y) < 3.0f && NoteList[i].transform.position.y > -5.0f)
        {
            //NoteList[i].GetComponent<LeftNote>().Test();
            if (NoteList[i].GetComponent<LeftNote>().longnote == 1)
            {
                leftuselongnote=true;
                leftlongtime=NoteList[i].GetComponent<LeftNote>().longtime;
            }
            Destroy(NoteList[i]);
            NoteList.RemoveAt(i);
            NotelaneIndex.RemoveAt(i);
            LeftNoteCount--;
        }
    }

    //下
    private void DownNoteJudge(int i)
    {
        Vector3 CollisionpositionDown = DownNoteJudgeObject.transform.position;

        if (Mathf.Abs(CollisionpositionDown.y - NoteList[i].transform.position.y) < 3.0f && NoteList[i].transform.position.y > -5.0f)
        {
            //NoteList[i].GetComponent<DownNote>().Test();
            if (NoteList[i].GetComponent<DownNote>().longnote == 1)
            {
                downuselongnote=true;
                downlongtime=NoteList[i].GetComponent<DownNote>().longtime;
            }
            Destroy(NoteList[i]);
            NoteList.RemoveAt(i);
            NotelaneIndex.RemoveAt(i);
            DownNoteCount--;
        }
    }

    //上
    private void UpNoteJudge(int i)
    {
        Vector3 CollisionpositionUp = UpNoteJudgeObject.transform.position;

        if (Mathf.Abs(CollisionpositionUp.y - NoteList[i].transform.position.y) < 3.0f && NoteList[i].transform.position.y > -5.0f)
        {
            //NoteList[i].GetComponent<UpNote>().Test();
            if (NoteList[i].GetComponent<UpNote>().longnote == 1)
            {
                upuselongnote=true;
                uplongtime=NoteList[i].GetComponent<UpNote>().longtime;
            }
            Destroy(NoteList[i]);
            NoteList.RemoveAt(i);
            NotelaneIndex.RemoveAt(i);
            UpNoteCount--;
        }
    }

    //右
    private void RightNoteJudge(int i)
    {
        Vector3 CollisionpositionRight = RightNoteJudgeObject.transform.position;

        if (Mathf.Abs(CollisionpositionRight.y - NoteList[i].transform.position.y) < 3.0f && NoteList[i].transform.position.y > -5.0f)
        {
            //NoteList[i].GetComponent<RightNote>().Test();
            if (NoteList[i].GetComponent<RightNote>().longnote == 1)
            {
                rightuselongnote=true;
                rightlongtime= NoteList[i].GetComponent<RightNote>().longtime;
            }
            Destroy(NoteList[i]);
            NoteList.RemoveAt(i);
            NotelaneIndex.RemoveAt(i);
            RightNoteCount--;
        }
    }

    private void LeftLongNoteProcess()
    {
        if (leftuselongnote == true && leftlongtime > 0)
        {
            if (_LeftactionRef.action.IsPressed())
            {
                Vector3 CollisionpositionLeft = LeftNoteJudgeObject.transform.position;

                for (int i = 0; i < leftlongtime; i++)
                {
                    if (Mathf.Abs(CollisionpositionLeft.y - LeftLongNoteList[i].transform.position.y) < 0.5f)
                    {
                        Destroy(LeftLongNoteList[i]);
                        LeftLongNoteList.RemoveAt(i);
                        leftlongtime--;

                        if (leftlongtime <= 0)
                        {
                            leftuselongnote = false;
                        }
                        break;
                    }
                }
            }
        }
    }

    private void DownLongNoteProsess()
    {
        if (downuselongnote == true && downlongtime > 0)
        {
            if (_DownactionRef.action.IsPressed())
            {
                Vector3 CollisionpositionDown = DownNoteJudgeObject.transform.position;

                for (int i = 0; i < downlongtime; i++)
                {
                    if (Mathf.Abs(CollisionpositionDown.y - DownLongNoteList[i].transform.position.y) < 0.5f)
                    {
                        Destroy(DownLongNoteList[i]);
                        DownLongNoteList.RemoveAt(i);
                        downlongtime--;

                        if (downlongtime <= 0)
                        {
                            downuselongnote = false;
                        }
                        break;
                    }
                }
            }
        }
    }

    private void UpLongNoteProsess()
    {
        if (upuselongnote == true && uplongtime > 0)
        {
            if (_UpactionRef.action.IsPressed())
            {
                Vector3 CollisionpositionUp = UpNoteJudgeObject.transform.position;

                for (int i = 0; i < uplongtime; i++)
                {
                    if (Mathf.Abs(CollisionpositionUp.y - UpLongNoteList[i].transform.position.y) < 0.5f)
                    {
                        Destroy(UpLongNoteList[i]);
                        UpLongNoteList.RemoveAt(i);
                        uplongtime--;

                        if (uplongtime <= 0)
                        {
                            upuselongnote = false;
                        }
                        break;
                    }
                }
            }
        }
    }

    private void RightLongNoteProcess()
    {
        if (rightuselongnote == true && rightlongtime > 0)
        {
            if (_RightactionRef.action.IsPressed())
            {
                Vector3 CollisionpositionRight = RightNoteJudgeObject.transform.position;

                for (int i = 0; i < rightlongtime; i++)
                {
                    if (Mathf.Abs(CollisionpositionRight.y - RightLongNoteList[i].transform.position.y) < 0.5f)
                    {
                        Destroy(RightLongNoteList[i]);
                        RightLongNoteList.RemoveAt(i);
                        rightlongtime--;

                        if (rightlongtime <= 0)
                        {
                            rightuselongnote=false;
                        }
                        break;
                    }
                }
            }
        }
    }


    private void DestroyNote()
    {
        for (int i = 0; i < NoteList.Count; i++)
        {
            if (NoteList[i].transform.position.y < -5.5f)
            {
                Destroy(NoteList[i]);
                NoteList.RemoveAt(i);
                NotelaneIndex.RemoveAt(i);
            }
        }
        for (int i = 0; i < LeftLongNoteList.Count; i++)
        {
            if (LeftLongNoteList[i].transform.position.y < -5.5f)
            {
                Destroy(LeftLongNoteList[i]);
                LeftLongNoteList.RemoveAt(i);
            }
        }
        for (int i = 0; i < DownLongNoteList.Count; i++)
        {
            if (DownLongNoteList[i].transform.position.y < -5.5f)
            {
                Destroy(DownLongNoteList[i]);
                DownLongNoteList.RemoveAt(i);
            }
        }
        for (int i = 0; i < UpLongNoteList.Count; i++)
        {
            if (UpLongNoteList[i].transform.position.y < -5.5f)
            {
                Destroy(UpLongNoteList[i]);
                UpLongNoteList.RemoveAt(i);
            }
        }
        for (int i = 0; i < RightLongNoteList.Count; i++)
        {
            if (RightLongNoteList[i].transform.position.y < -5.5f)
            {
                Destroy(RightLongNoteList[i]);
                RightLongNoteList.RemoveAt(i);
            }
        }

    }

    private void DestroyEvaluation()
    {
        float canvasHeight = canvas.GetComponent<RectTransform>().rect.height;
        float canvasY = -canvasHeight/2.0f;
        for (int i = 0; i < EvaluationList.Count; i++)
        {
            if (EvaluationList[i].transform.position.y<canvasY+(-600.0f))
            {
                Destroy(EvaluationList[i]);
                EvaluationList.RemoveAt(i);
            }
        }
    }
}


