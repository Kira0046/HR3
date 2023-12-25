using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class Information : MonoBehaviour
{
    private int score = 0;
    private int nowcombo = 0;
    private int maxcombo = 0;

    [SerializeField]
    private TMPro.TMP_Text scoretext;

    [SerializeField]
    private TMPro.TMP_Text maxcombotext;

    // Start is called before the first frame update
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoretext.SetText("score:{0}", score);
        maxcombotext.SetText("maxcombo:{0}", maxcombo);
    }

    public void ZeroNowCombo()
    {
        nowcombo=0;
    }

    public void UpCombo()
    {
        nowcombo++;
        if (nowcombo > maxcombo)
        {
            maxcombo++;
        }
    }

    public void SickScore()
    {

    }

    public void GoodScore()
    {

    }

    public void BadScore()
    {

    }
}
