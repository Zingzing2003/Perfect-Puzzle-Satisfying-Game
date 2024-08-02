using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level12Controller : MonoBehaviour
{

    public static Level12Controller instance;
    [SerializeField] private Button btnGachSai;
    

    private void Awake()
    {
        instance = this;
        btnGachSai.onClick.AddListener(OnCorrect);
    }

    void OnCorrect()
    {
        
        btnGachSai.transform.Rotate(0,0,90);
        Vector3 angel = btnGachSai.transform.rotation.eulerAngles;
        
        if (angel.z % 180 == 0)
        {
            btnGachSai.gameObject.GetComponent<Button>().enabled = false;
            WinGame();
        }
    }
    public void WinGame()
    {
        GameManager.instance.WinGame();
    }
}
