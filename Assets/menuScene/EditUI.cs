using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditUI : MonoBehaviour
{
    public bool mEdit = false;

    MenuUI uiscript;
    private void Awake()
    {
        mEdit=false;
        GameObject UIObject = GameObject.Find("menuManager");
        uiscript = UIObject.GetComponent<MenuUI>();
    }

    

    public void OnEdit()
    {
        uiscript.moveflag = true;
        mEdit = true;
        //SceneManager.LoadScene("EditScene");
    }

}
