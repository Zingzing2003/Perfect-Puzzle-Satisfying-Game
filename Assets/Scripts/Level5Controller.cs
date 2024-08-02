using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level5Controller : MonoBehaviour
{
    public static Level5Controller instance;
    [SerializeField] private GameObject Sun;
    [SerializeField] private GameObject Cloud;

    private void Awake()
    {
        instance = this;
    }

     public void CheckWin()
     {
         double s = Math.Sqrt((Sun.transform.position.x- Cloud.transform.position.x)*(Sun.transform.position.x- Cloud.transform.position.x)+(Sun.transform.position.y- Cloud.transform.position.y)*(Sun.transform.position.y- Cloud.transform.position.y));
         if (s <= 0.3f)
         {
             Cloud.GetComponent<Image>().raycastTarget = false;
             GameManager.instance.WinGame();
         }
     }
}
