using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Count3Manager : MonoBehaviour
{
    private AudioClip count3Clip;
    private AudioSource count3Source;

    const string count3path = "/Assets/Resource/Audio/Intro/intro3.mp3";

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
        count3Source = GetComponent<AudioSource>();
        LoadAudio("file://" + count3path, count3Source, count3Clip);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        count3Source.Play();
    }
}
