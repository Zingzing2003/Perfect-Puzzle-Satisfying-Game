using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopitElement : MonoBehaviour, IPointerDownHandler
{
    
    public void OnPointerDown(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);
        Level3Controller.instance.total--;
        if (Level3Controller.instance.total == 0)
        {
            GameManager.instance.WinGame();
        }
        
    }
}
