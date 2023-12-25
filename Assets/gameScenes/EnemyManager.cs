using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyManager : MonoBehaviour
{

    //prefabオブジェクト
    public GameObject preLeftNote;
    public GameObject preDownNote;
    public GameObject preUpNote;
    public GameObject preRightNote;

    //判定オブジェクト
    public GameObject LeftNoteJudgeObject;
    public GameObject DownNoteJudgeObject;
    public GameObject UpNoteJudgeObject;
    public GameObject RightNoteJudgeObject;

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

    // Start is called before the first frame update
    void Start()
    {
        LoadJson();
    }

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

    }
}
