using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGameManager : MonoBehaviour
{
   [SerializeField] private Button backHomeBtn;
   [SerializeField] private Button replayBtn;
   [SerializeField] private Button nextLevelBtn;
   [SerializeField] private Button settingBtn;
   [SerializeField] private Button pauseBtn;
   [SerializeField] private GameObject settingPopup;
   [SerializeField] private GameObject pausePopup;
   
   private void Awake()
   {
      backHomeBtn.onClick.AddListener(OnBackHome);
      replayBtn.onClick.AddListener(OnReplay);
      nextLevelBtn.onClick.AddListener(OnNextLevel);
      settingBtn.onClick.AddListener(OnSetting);
      pauseBtn.onClick.AddListener(OnPause);
   }

   void OnSetting()
   {
      SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
      settingPopup.gameObject.SetActive(true);
   }
   void OnPause()
   {
      SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
      pausePopup.gameObject.SetActive(true);
   }
   void OnBackHome()
   {
      SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
      LoadingPanel.instance.GotoScene("Home",()=>{});
     
   }

   void OnReplay()
   {
      SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
      LoadingPanel.instance.GotoScene("GamePlay", ()=>{});
   }

   void OnNextLevel()
   {
      SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
      GameConfig.instance.levelSelected += 1;
      LoadingPanel.instance.GotoScene("GamePlay", ()=>{});
   }
}
