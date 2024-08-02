using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level10Controller : MonoBehaviour
{
    public static Level10Controller instance;
    [SerializeField] private List<CalElement> calElements;
    [SerializeField] private List<GameObject> calRElements;
    public int countCal;
    private void Awake()
    {
        instance = this;
        countCal = 0;
        for (int i = 0; i < calElements.Count; i++)
        {
            calElements[i].rightTrnform = calRElements[i].gameObject.transform;
        }
    }

    public void CheckWin()
    {
        if (countCal == 6)
        {
            for (int i = 0; i < calElements.Count; i++)
            {
                calElements[i].GetComponent<Image>().raycastTarget = false;
            }
            GameManager.instance.WinGame();
            for (int i = 0; i < calElements.Count; i++)
            {
                calElements[i].GetComponent<Image>().raycastTarget = false;
            }
            
        }
    }
}
