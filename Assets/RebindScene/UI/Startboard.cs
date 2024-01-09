using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startboard : MonoBehaviour
{
    Vector3 move = new(-20.0f, 0.0f, 0.0f);
    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x>=-2000.0f)
        {
            transform.position+=move;
        }
    }
}
