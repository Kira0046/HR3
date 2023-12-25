using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{


    // Start is called before the first frame update
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlay()
    {
        SceneManager.LoadScene("RebindScene");
    }

    public void OnEdit()
    {
        SceneManager.LoadScene("EditScene");
    }
}
