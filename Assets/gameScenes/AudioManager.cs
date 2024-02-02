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
    private AudioClip musicClip;
    private AudioSource musicSource;
    private AudioClip count3Clip;
    private AudioSource count3Source;
    private AudioClip count2Clip;
    private AudioSource count2Source;
    private AudioClip count1Clip;
    private AudioSource count1Source;
    private AudioClip GoClip;
    private AudioSource GoSource;



    const string musicpath = "/Assets/Resource/Audio/music.mp3";
    const string count3path = "/Assets/Resource/Audio/Intro/intro3.mp3";
    const string count2path = "/Assets/Resource/Audio/Intro/intro2.mp3";
    const string count1path = "/Assets/Resource/Audio/Intro/intro1.mp3";
    const string Gopath = "/Assets/Resource/Audio/Intro/introGo.mp3";

    private IEnumerator LoadAudio(string path, AudioSource audioSource, AudioClip audioClip)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result==UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClip=DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = audioClip;
                //Debug.Log(audioSource.clip.length);
                //audioSource.Play();
            }
        }
    }

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        count3Source=GetComponent<AudioSource>();
        count2Source=GetComponent<AudioSource>();
        count1Source=GetComponent<AudioSource>();
        GoSource=GetComponent<AudioSource>();
        StartCoroutine(LoadAudio("file://" + musicpath, musicSource, musicClip));


    }

    // Update is called once per frame
    void Update()
    {
        BackProcess();
    }

    public void Play()
    {
        musicSource.Play();
    }

    public void Pause()
    {
        musicSource.Pause();
    }

    public void UnPause()
    {
        musicSource.UnPause();
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
