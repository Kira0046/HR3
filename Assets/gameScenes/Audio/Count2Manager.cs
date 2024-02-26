using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Count2Manager : MonoBehaviour
{
    private AudioClip count2Clip;
    private AudioSource count2Source;

    const string count2path = "/Assets/Resource/Audio/Intro/intro2.mp3";
    private void LoadAudio(string path, AudioSource audioSource, AudioClip audioClip)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG))
        {
            www.SendWebRequest();

            while (!www.isDone)
            {
                // ‰½‚à‚µ‚È‚¢
            }

            if (www.result==UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClip=DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = audioClip;

            }
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        count2Source = GetComponent<AudioSource>();
        LoadAudio("file://" + count2path, count2Source, count2Clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
