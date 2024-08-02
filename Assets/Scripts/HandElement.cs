using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] public Transform rightTranform;
    private bool isDrag;
    private bool isP;

    private void Awake()
    {
        isP = false;
    }

    private void Update()
    {
        if (isDrag)
        {
            Vector3 a = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            a.z = 0;
            this.transform.position = a;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrag = true;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDrag = false;
        Check();
    }

    float Kc()
    {
        float kc = Mathf.Sqrt((rightTranform.position.x - this.transform.position.x) *
                              (rightTranform.position.x - this.transform.position.x) +
                              (rightTranform.position.y - this.transform.position.y) *
                              (rightTranform.position.y - this.transform.position.y));
        return kc;
    }
    void Check()
    {
        if (Kc()<= 0.3)
        {
            if (!isP)
            {
                Level9Controller.instance.countHand++;
                isP = true;
            }
            
        }
        else
        {
            if (isP)
            {
                Level9Controller.instance.countHand--;
                isP = false;
            }
        }
        Level9Controller.instance.CheckWin();
    }
}
