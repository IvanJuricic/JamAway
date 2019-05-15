using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour {
    //bool isAudioLoaded = false;
    public WWW selectedClip;

    public AudioSource songSource;


    void Start()
    {
        AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        AndroidJavaObject userFiles = new AndroidJavaObject("com.ionegames.jamawaylibrary.UnityBinder");

        userFiles.CallStatic("OpenStorage", androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity"));
    }

    IEnumerator OnAudioPick(string filePath)
    {
        selectedClip = new WWW("file://" + filePath);
        yield return selectedClip;

        songSource.clip = selectedClip.GetAudioClipCompressed();

        songSource.Play();
    }

    public void LoadSong(string filePath)
    {

        StartCoroutine(OnAudioPick(filePath));

    }
}
