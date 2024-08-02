using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level7Controller : MonoBehaviour
{
    public static Level7Controller instance;

    [SerializeField] private Button btnOn;
    [SerializeField] private Button btnOff;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] public GameObject errScreen;
    
    private void Awake()
    {
        instance = this;
        btnOn.onClick.AddListener(HandleOn);
        btnOff.onClick.AddListener(HandleOff);
    }

    void HandleOn()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.clickAudioSource);
        blackScreen.gameObject.SetActive(false);
        btnOff.gameObject.SetActive(true);
        btnOn.gameObject.SetActive(false);
    }

    void HandleOff()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.clickAudioSource);
        blackScreen.gameObject.SetActive(true);
        btnOff.gameObject.SetActive(false);
        btnOn.gameObject.SetActive(true);
    }
    
    
}
