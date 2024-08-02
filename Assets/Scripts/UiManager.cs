using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private List<LevelElement> levelElements;
    [SerializeField] private LevelElement levelPref;
    [SerializeField] private GameObject contentLevel;
    [SerializeField] private Sprite[] levelSprites;

    [SerializeField] private Button settingBtn;
    [SerializeField] private GameObject settingPopup;

    private void Awake()
    {
        settingBtn.onClick.AddListener(OnSetting);
    }

    void OnSetting()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.uiClickAudioSource);
        settingPopup.gameObject.SetActive(true);
    }
    private void Start()
    {
        HomeSetup();
    }

    void HomeSetup()
    {
        SoundManager.instance.PlayAudio(SoundManager.instance.gameAudioSource);
        // levelSprites = Resources.LoadAll<Sprite>("LevelTexure");
        //Array.Sort(levelSprites);
       // Debug.Log(levelSprites.Length);
        for (int i = 0; i < levelSprites.Length; i++)
        {
            LevelElement level = Instantiate(levelPref, contentLevel.transform);
            level.SetUp(i+1, levelSprites[i]);
        }
        
        StartCoroutine(LoadingPanel.instance.ActiveScene(() => { }));
    }
}
