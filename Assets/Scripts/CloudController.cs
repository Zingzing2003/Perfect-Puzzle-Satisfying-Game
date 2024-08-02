using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloudController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDrag;


    private void Awake()
    {
        isDrag = false;
    }

    private void Update()
    {
        if (isDrag)
        {
           Vector3 v= Camera.main.ScreenToWorldPoint(Input.mousePosition);
           v.z = 0;
           this.transform.position = v;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDrag)
        {
            isDrag = false;
            Level5Controller.instance.CheckWin();
            Debug.Log("checkm");
        }
    }
}
