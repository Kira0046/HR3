using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class AudioManager : MonoBehaviour
{


    public bool playAudio = false;
    public bool backAudio = false;
    private AudioClip audioClip;
    private AudioSource audioSource;


    const string path = "/Assets/Resource/Audio/music.mp3";

    private IEnumerator LoadAudio(string path)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if(www.result==UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClip=DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = audioClip;
                Debug.Log(audioSource.clip.length);
                audioSource.Play();
            }
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(LoadAudio("file://" +path));

    }

    // Update is called once per frame
    void Update()
    {
        BackProcess();
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void UnPause()
    {
        audioSource.UnPause();
    }

    public void Back()
    {
        if (backAudio==true)
        {
            backAudio = false;
            return;
        }
        if (backAudio==false)
        {
            backAudio=true;
            return;
        }
    }

    private void BackProcess()
    {
        if (backAudio==true)
        {

        }
        if (backAudio==false)
        {

        }
    }
}
