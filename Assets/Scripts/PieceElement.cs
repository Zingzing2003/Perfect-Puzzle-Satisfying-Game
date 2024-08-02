using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PieceElement : MonoBehaviour, IPointerDownHandler
{
    public bool isDone;

    private void Awake()
    {
        isDone = false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
        checkRotate();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       // float q = 90;
      // Debug.Log("check");
       SoundManager.instance.PlayOneShootAudio(SoundManager.instance.clickAudioSource);
        this.transform.Rotate(0f, 0f, 90);
        checkRotate();
    }

    void checkRotate()
    {
        Vector3 angel = this.transform.rotation.eulerAngles;

        if (angel.z % 360 == 0 && isDone.Equals(false))
        {
            //Debug.Log("Dung r");
            isDone = true;
            //this.GetComponent<Image>().raycastTarget = false;
            Level2Controller.instance.max--;

            if (Level2Controller.instance.max == 0)
            {
                Level2Controller.instance.WinGame();
            }
            
        }
        else
        {
            if (isDone)
            {
                isDone = false;
                Level2Controller.instance.max++;
            }
        }
    }
}
