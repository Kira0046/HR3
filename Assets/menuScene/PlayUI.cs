using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayUI : MonoBehaviour
{
    // Start is called before the first frame update
    public bool mPlay = false;

    MenuUI uiscript;
    private void Awake()
    {
        mPlay=false;
        GameObject UIObject = GameObject.Find("menuManager");
        uiscript = UIObject.GetComponent<MenuUI>();
    }

    public void OnPlay()
    {
        uiscript.moveflag = true;
        mPlay = true;
        //SceneManager.LoadScene("RebindScene");
    }
}
