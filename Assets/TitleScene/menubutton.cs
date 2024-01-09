using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menubutton : MonoBehaviour
{

    Vector3 move = new(-20.0f, 0.0f, 0.0f);
    public bool moveflag = false;
    // Start is called before the first frame update
    private void Awake()
    {
        moveflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveflag)
        {
            transform.position+=move;
            if (transform.localPosition.x<= 0.0f)
            {
                move =new(0.0f, 0.0f, 0.0f);
                SceneManager.LoadScene("menuScene");
            }
        }
    }


}
