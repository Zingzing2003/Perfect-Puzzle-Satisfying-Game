using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelElement : MonoBehaviour
{
    public int levelId;

    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(OnPlay);
    }

    void OnPlay()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
        GameConfig.instance.levelSelected = levelId;
        LoadingPanel.instance.GotoScene("GamePlay",()=>{});
    }
    
    public void SetUp(int id, Sprite sprite)
    {
        this.levelId = id;
        this.GetComponent<Image>().sprite = sprite;
    }
}
