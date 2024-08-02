using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        Level4Controller.instance.isTouch = true;
        Level4Controller.instance.MoveTouch();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");
        Level4Controller.instance.isTouch = false;
        Level4Controller.instance.CancelMove();
    }
}
