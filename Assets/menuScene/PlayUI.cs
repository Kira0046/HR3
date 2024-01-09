using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour
{
    // Start is called before the first frame update
    public bool mPlay = false;

    //public Button button;
    private bool isButtonSelected;

    public Button button1;
    public Button button2;

    public TMP_Text pathtext;

    MenuUI uiscript;
    private void Awake()
    {
        mPlay=false;
        GameObject UIObject = GameObject.Find("menuManager");
        uiscript = UIObject.GetComponent<MenuUI>();
    }

    private void Update()
    {

    }

    public void OnPlay()
    {
        uiscript.moveflag = true;
        mPlay = true;
        //SceneManager.LoadScene("RebindScene");
    }
}
