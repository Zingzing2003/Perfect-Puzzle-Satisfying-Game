using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level9Controller : MonoBehaviour
{
    public static Level9Controller instance;
    [SerializeField] public int countHand;
    [SerializeField] private List<HandElement> handElements;
    private void Awake()
    {
        countHand = 0;
        instance = this;
    }


    public void CheckWin()
    {
        if (countHand == 5)
        {
            for (int i = 0; i < handElements.Count; i++)
            {
                handElements[i].transform.position = handElements[i].rightTranform.position;
                handElements[i].GetComponent<Image>().raycastTarget = false;
            }
            GameManager.instance.WinGame();
            
        }
    }
}
