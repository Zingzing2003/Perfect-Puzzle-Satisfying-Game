using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public bool isPrepare;
    public bool isFire;
    public float speedMove;
    public bool isSticked=false ;
    

    private void Update()
    {
        if (!isSticked && isPrepare)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                KeyBoardButton();
            }
            else if (Application.platform == RuntimePlatform.Android)
            {
                TouchButton();
            }
        }
        

        if (!Level6Controller.instance.win)  MoveUpward();
    }

    void KeyBoardButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPrepare)
            {
                isFire = true;
            }
        }
    }

    void TouchButton()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (isPrepare)
                {
                    isFire = true;
                }
            }
        }
    }
    
    void MoveUpward(){
        if (!isSticked  && isPrepare && isFire)
        {
           
            this.GetComponent<Rigidbody2D>().MovePosition (this.GetComponent<Rigidbody2D>().position + Vector2.up * speedMove * Time.deltaTime);
           // transform.GetChild (0).gameObject.SetActive (true);
        }
       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Knife"))
        {
            isFire = false;
            if (!isSticked && other.gameObject.GetComponent<Knife>().isSticked)
            {
                isPrepare = false;
               //isSticked = true;
                //isFire = false;
                this.GetComponent<Rigidbody2D>().gravityScale = 1;
                
                Level6Controller.instance.InsKnife();
            }
            
        }
        if (isFire && other.CompareTag("Target"))
        {
            isSticked = true;
            isFire = false;
            this.transform.SetParent(other.gameObject.transform);
             Level6Controller.instance.InsKnife();
        }

        if (other.CompareTag("Apple"))
        {
            Level6Controller.instance.win = true;
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            other.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            GameManager.instance.WinGame();
        }
        
    }

    
}
