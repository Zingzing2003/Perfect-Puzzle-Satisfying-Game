using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour


{
    public static SoundManager instance;
    [HideInInspector] public SoundState soundState;
    [HideInInspector] public MusicState musicState;
    [HideInInspector] public VibrationState vibrationState;



    public AudioSource gameAudioSource;
    public AudioSource winAudioSource;
    public AudioSource endTimeAudioSource;
    public AudioSource uiClickAudioSource;
    public AudioSource clickAudioSource;
    public AudioSource calButtonSourse;
    private void Awake()
    {
        instance = this;
    }


    public void PlayAudio(AudioSource audioSource)
    {
        if( musicState== MusicState.Off) return;
        audioSource.Play();
    }

    public void StopAudio(AudioSource audioSource)
    {
        audioSource.Stop();
    }

    public void PlayOneShootAudio(AudioSource audioSource)
    {
        if( soundState== SoundState.Off) return;
        audioSource.PlayOneShot(audioSource.clip);
    }
    
    public void CallVibration()
    {
        if(vibrationState == VibrationState.Off) return;
        Vibration.Vibrate(50);
        
    }
}

public enum SoundState
{
    On,
    Off
}

public enum MusicState
{
    On,
    Off
}

public enum VibrationState
{
    On,
    Off
}

public static class Vibration
{
#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else
    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void Vibrate()
    {
        if (isAndroid())
            vibrator.Call("vibrate");
        else
            Handheld.Vibrate();
    }


    public static void Vibrate(long milliseconds)
    {
        if (isAndroid())
            vibrator.Call("vibrate", milliseconds);
        else
            Handheld.Vibrate();
    }

    public static void Vibrate(long[] pattern, int repeat)
    {
        if (isAndroid())
            vibrator.Call("vibrate", pattern, repeat);
        else
            Handheld.Vibrate();
    }

    public static bool HasVibrator()
    {
        return isAndroid();
    }

    public static void Cancel()
    {
        if (isAndroid())
            vibrator.Call("cancel");
    }

    private static bool isAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
	return true;
#else
        return false;
#endif
    }
}