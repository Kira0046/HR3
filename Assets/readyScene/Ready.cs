using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ready : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        SceneManager.LoadScene("titleScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
