using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endboard : MonoBehaviour
{
    Vector3 move = new(-20.0f, 0.0f, 0.0f);
    public bool moveflag=false;
    // Update is called once per frame
    private void Awake()
    {
        moveflag = false;
    }
    void Update()
    {
        if (moveflag)
        {
            transform.position+=move;
            if (transform.localPosition.x<= 0.0f)
            {
                move =new(0.0f, 0.0f, 0.0f);
                SceneManager.LoadScene("gameScene");
            }
        }
    }
}
