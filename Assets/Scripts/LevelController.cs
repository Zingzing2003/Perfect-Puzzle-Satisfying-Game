using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{

    [SerializeField] private Button btnOn;
    [SerializeField] private Image btnOff;
    [SerializeField] private Image imgBG;
    private void Start()
    {
        btnOn.onClick.AddListener(HandleOn);
    }

    void HandleOn()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
        btnOff.gameObject.SetActive(true);
        btnOn.gameObject.SetActive(false);
        imgBG.gameObject.SetActive(false);
        GameManager.instance.WinGame();
    }
}
