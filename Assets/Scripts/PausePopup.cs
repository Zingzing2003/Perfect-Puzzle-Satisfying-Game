using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePopup : MonoBehaviour
{
    [SerializeField] private Button btnHome;
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnClose;

    private void Awake()
    {
        btnContinue.onClick.AddListener(OnContinue);
        btnHome.onClick.AddListener(OnBackHome);
        btnClose.onClick.AddListener(OnClose);
    }
    void OnBackHome()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.clickAudioSource);
        LoadingPanel.instance.GotoScene("Home",()=>{});
     
    }

    void OnContinue()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.clickAudioSource);
        this.gameObject.SetActive(false);
    }

    void OnClose()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.clickAudioSource);
        this.gameObject.SetActive(false);
    }
}
