using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

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
        this.transform.Rotate(0f, 0f, 90);
        checkRotate();
    }

    void checkRotate()
    {
        if (this.transform.rotation.z % 360 == 0 && isDone.Equals(false))
        {
            //Debug.Log("Dung r");
            isDone = true;
            this.GetComponent<Image>().raycastTarget = false;
            Level2Controller.instance.max--;

            if (Level2Controller.instance.max == 0)
            {
                GameManager.instance.WinGame();
            }
            
        }
    }
}
