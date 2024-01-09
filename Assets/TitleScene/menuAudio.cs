using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuAudio : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.activeSceneChanged+=DestroyGameObject;
    }

    private void DestroyGameObject(Scene current,Scene next)
    {
        if (next.name=="gameScene")
        {
            Destroy(gameObject);
        }
    }
}
