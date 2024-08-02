using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Toothbrush : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDrag;


    private void Update()
    {
        if (isDrag)
        {
            Vector3 a = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            a.z = 0;
            this.transform.position = a;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dirt"))
        {
           if( !Level11Controller.instance.particleSystem.isPlaying) Level11Controller.instance.particleSystem.Play();
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            Level11Controller.instance.countDirt--;
           
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDrag = false;
        if (Level11Controller.instance.countDirt == 0)
        {
            Level11Controller.instance.WinGame();
            this.gameObject.SetActive(false);
        }
    }
}
