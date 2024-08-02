using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject mainGame;
    [SerializeField] private GameObject toolBtn;
    [SerializeField] private GameObject PS;
    public Camera mainCam;
    public GameObject levelController;
    [SerializeField] private GameObject faildPopup;
    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        SetUp();
    }

    public void OpenFailePopup()
    {
        faildPopup.gameObject.SetActive(true);
    }
    void SetUp()
    {
        GameObject levelPref = Resources.Load<GameObject>("Level/Level" + GameConfig.instance.levelSelected);
        if (levelPref)
        {
            if (GameConfig.instance.levelSelected == 6 ||GameConfig.instance.levelSelected == 8  ||GameConfig.instance.levelSelected == 4 )
            {
                GameObject lv = Instantiate(levelPref);
                levelController = lv;
            }
            else
            {
                GameObject lv = Instantiate(levelPref, mainGame.transform);
                levelController = lv;
            }
            
           
        }

        StartCoroutine(LoadingPanel.instance.ActiveScene(() => { }));

    }
    public void WinGame()
    {
        SoundManager.instance.PlayOneShootAudio(SoundManager.instance.winAudioSource);
        toolBtn.gameObject.SetActive(true);
        PS.gameObject.SetActive(true);
        PS.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
    }
}
