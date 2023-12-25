using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;

    private void Awake()
    {
        slider.value = 50;
    }

    // Update is called once per frame
    void Update()
    {
        //slider.value+=1;
    }

    public void UpHealth()
    {
        slider.value+=5.0f;
    }

    public void DownHealth()
    {
        slider.value-=5.0f;
    }
}
