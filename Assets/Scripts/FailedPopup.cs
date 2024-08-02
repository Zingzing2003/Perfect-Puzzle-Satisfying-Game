using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailedPopup : MonoBehaviour
{
    [SerializeField] private Button btnHome;
    [SerializeField] private Button btnReplay;
    [SerializeField] private Button btnClose;
    
    private void Awake()
    {
        btnReplay.onClick.AddListener(OnRePlay);
        btnHome.onClick.AddListener(OnBackHome);
        btnClose.onClick.AddListener(OnClose);
    }
    void OnBackHome()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.clickAudioSource);
        LoadingPanel.instance.GotoScene("Home",()=>{});
     
    }

    void OnRePlay ()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.clickAudioSource);
        //this.gameObject.SetActive(false);
        LoadingPanel.instance.GotoScene("GamePlay", ()=>{});
    }

    void OnClose()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.clickAudioSource);
        this.gameObject.SetActive(false);
    }
}
