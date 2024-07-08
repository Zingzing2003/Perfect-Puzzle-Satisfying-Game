using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolManager : MonoBehaviour
{

    [SerializeField] private Button btnBackHome;
    [SerializeField] private Button btnReplay;
    [SerializeField] private Button btnNextLevel;
    
    private void Awake()
    {
        btnBackHome.onClick.AddListener(OnBackHome);
        btnReplay.onClick.AddListener(OnReplay);
        btnNextLevel.onClick.AddListener(OnNextLevel);
    }


    void OnBackHome()
    {
        Debug.Log("back home");
    }

    void OnReplay()
    {
        
    }

    void OnNextLevel()
    {
        
    }
}
