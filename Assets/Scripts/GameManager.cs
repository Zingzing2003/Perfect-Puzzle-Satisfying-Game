using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject toolBtn;
    private void Awake()
    {
        instance = this;
    }


    public void WinGame()
    {
        Debug.Log("Win");
        toolBtn.gameObject.SetActive(true);
    }
}
