using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopUp : MonoBehaviour
{
   [SerializeField] private Button btnOnSound;
   [SerializeField] private Button btnOffSound;
   [SerializeField] private Button btnOnMusic;
   [SerializeField] private Button btnOffMusic ;
   [SerializeField] private Button btnOnVibration;
   [SerializeField] private Button btnOffVibration;
   [SerializeField] private Button btnClose;

   private void Awake()
   {
      btnClose.onClick.AddListener(OnClose);
      btnOnSound.onClick.AddListener(OffSound);
      btnOffSound.onClick.AddListener(OnSound);
      btnOnMusic.onClick.AddListener(OffMusic);
      btnOffMusic.onClick.AddListener(OnMusic);
      btnOnVibration.onClick.AddListener(OffVibration);
      btnOffVibration.onClick.AddListener(OnVibration);
      
   }

   void OnClose()
   {
      SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
      this.gameObject.SetActive(false);
   }
   void OnSound()
   {
      btnOnSound.gameObject.SetActive(true);
      btnOffSound.gameObject.SetActive(false);
      SoundManager.instance.soundState = SoundState.On;
      SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
   }

   void OffSound()
   {
      btnOnSound.gameObject.SetActive(false);
      btnOffSound.gameObject.SetActive(true);
      SoundManager.instance.soundState = SoundState.Off;
   }
   
   void OnMusic()
   {
      btnOnMusic.gameObject.SetActive(true);
      btnOffMusic.gameObject.SetActive(false);
      SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
      SoundManager.instance.musicState = MusicState.On;
      SoundManager.instance.PlayAudio( SoundManager.instance.gameAudioSource);
   }

   void OffMusic()
   {
      btnOnMusic.gameObject.SetActive(false);
      btnOffMusic.gameObject.SetActive(true);
      SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
      SoundManager.instance.musicState = MusicState.Off;
      SoundManager.instance.StopAudio( SoundManager.instance.gameAudioSource);
   }

   void OnVibration()
   {
      btnOnVibration.gameObject.SetActive(true);
      btnOffVibration.gameObject.SetActive(false);
      SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
      SoundManager.instance.vibrationState = VibrationState.On;
      SoundManager.instance.CallVibration();
   }

   void OffVibration()
   {
      btnOnVibration.gameObject.SetActive(false);
      btnOffVibration.gameObject.SetActive(true);
      SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
      SoundManager.instance.vibrationState = VibrationState.Off;
      SoundManager.instance.CallVibration();
   }
   
}
