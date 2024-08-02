using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11Controller : MonoBehaviour
{
    public static Level11Controller instance;
    public int countDirt;
    
    [SerializeField] private GameObject teethCleen;
    [SerializeField] private GameObject teethDirty;
    [SerializeField] private GameObject bedSmell;
    public ParticleSystem particleSystem;
    private void Awake()
    {
        instance = this;
        countDirt = 10;
    }

    public void WinGame()
    {
        bedSmell.SetActive(false);
        teethCleen.SetActive(true);
        teethDirty.SetActive(false);
        
        GameManager.instance.WinGame();
        
    }
}
