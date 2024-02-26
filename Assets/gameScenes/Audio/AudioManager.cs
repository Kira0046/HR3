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

    
    private AudioClip count1Clip;
    private AudioSource count1Source;
    private AudioClip GoClip;
    private AudioSource GoSource;


    const string musicpath = "/Assets/Resource/Audio/music.mp3";
    const string count1path = "/Assets/Resource/Audio/Intro/intro1.mp3";
    const string Gopath = "/Assets/Resource/Audio/Intro/introGo.mp3";

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

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        LoadAudio("file://" + musicpath, musicSource, musicClip);
        musicSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        BackProcess();
    }

    public void Play(AudioSource audioSource)
    {
        audioSource.Play();
    }

    public void Stop(AudioSource audioSource)
    {
        audioSource.Stop();
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
