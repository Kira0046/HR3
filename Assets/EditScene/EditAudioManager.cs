using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EditAudioManager : MonoBehaviour
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

            if (www.result==UnityWebRequest.Result.ConnectionError)
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
        StartCoroutine(LoadAudio("file://" + path));
    }

    // Update is called once per frame
    void Update()
    {

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
        if (audioSource.isPlaying==true)
        {
            audioSource.Pause();
        }
        audioSource.time-=1.0f/60.0f;
    }


}
