using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Vector3 move = new(-11, -6, 0);
    Vector3 startposition = new();
    // Start is called before the first frame update
    private void Awake()
    {
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += move;
        if(transform.position.x < startposition.x-630)
        {
            transform .position =startposition;
        }
    }
}