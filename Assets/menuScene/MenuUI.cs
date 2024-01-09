using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject startblackboard;
    public GameObject endblackboard;

    Vector3 move = new(-20.0f, 0.0f, 0.0f);
    PlayUI playscript;
    EditUI editscript;
    public bool moveflag = false;
    // Start is called before the first frame update
    private void Awake()
    {
        moveflag=false;
        startblackboard.transform.localPosition=new(0.0f,0.0f,0.0f);
        endblackboard.transform.localPosition=new Vector3(1290.0f, 0.0f, 0.0f);

        GameObject playObject=GameObject.Find("PlayButton");
        playscript=playObject.GetComponent<PlayUI>();

        GameObject editObject = GameObject.Find("EditButton");
        editscript = editObject.GetComponent<EditUI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (startblackboard.transform.localPosition.x>-2000)
        {
            startblackboard.transform.position+=move;
        }


        if (moveflag)
        {
            endblackboard.transform.position+=move;
        }
        if(endblackboard.transform.localPosition.x <= 0.0f)
        {
            move =new(0.0f,0.0f, 0.0f);
            if (playscript.mPlay==true)
            {
                SceneManager.LoadScene("RebindScene");
            }
            if(editscript.mEdit==true)
            {
                SceneManager.LoadScene("EditScene");
            }
        }
    }




}
