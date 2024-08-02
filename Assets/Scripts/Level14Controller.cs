using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level14Controller : MonoBehaviour
{
    public static Level14Controller instance;
    public int count = 6;
    public PicElement cur;
    public int clickCount;
    [SerializeField] private List<PicElement> listElements;
    private void Awake()
    {
       
        instance = this;
        clickCount = 0;
    }

    public void WinGame()
    {
        GameManager.instance.WinGame();
    }

    public void DelPic(int id)
    {
        for (int i = 0; i <= listElements.Count; i++)
        {
            if (listElements[i].gameObject.activeSelf == true)
            {
                if (listElements[i].id == id)
                {
                    listElements[i].gameObject.SetActive(false);
                    //Destroy(listElements[i]);
                    // listElements.Remove(listElements[i]);
                }
            }
            
            
        }
    }
}
