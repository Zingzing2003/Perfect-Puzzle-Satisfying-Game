using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicElement : MonoBehaviour
{
    public int id;

    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(OnPic);
    }

    void OnPic()
    {
        
        Debug.Log("Click");
        if (Level14Controller.instance.clickCount == 0)
        {
            Level14Controller.instance.clickCount++;
            //Level14Controller.instance.curentId = this.id;
            Level14Controller.instance.cur = this;
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.gameObject.GetComponent<Image>().raycastTarget = false;
        }
        else
        {// 1
            if (Level14Controller.instance.cur.id == this.id)
            {
                Level14Controller.instance.clickCount++;
                this.transform.GetChild(0).gameObject.SetActive(false);
                if (Level14Controller.instance.clickCount == 2)
                {
                    this.transform.GetChild(0).gameObject.SetActive(false);
                    StartCoroutine(WaitFor());
                    Level14Controller.instance.clickCount = 0;
                   
                    Level14Controller.instance.count--;
                    
                    if (Level14Controller.instance.count == 0)
                    {
                        Level14Controller.instance.WinGame();
                    }
                }
            }
            else
            {
                //Level14Controller.instance.cur.transform.GetChild(0).gameObject.SetActive(true);
                Level14Controller.instance.clickCount = 0;
                //Level14Controller.instance.clickCount++;
                //Level14Controller.instance.cur = this;
                this.transform.GetChild(0).gameObject.SetActive(false);
                StartCoroutine(WaitClose(this.transform.GetChild(0).gameObject,
                    Level14Controller.instance.cur.transform.GetChild(0).gameObject));
                Level14Controller.instance.cur.transform.gameObject.GetComponent<Image>().raycastTarget = true;
            }
           
        }
    }
    IEnumerator WaitClose(GameObject a, GameObject b)
    {
        yield return new WaitForSeconds(0.5f);
       a.SetActive(true);
       b.SetActive(true);
    }
    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(0.5f);
        Level14Controller.instance.DelPic(this.id);
    }
}
