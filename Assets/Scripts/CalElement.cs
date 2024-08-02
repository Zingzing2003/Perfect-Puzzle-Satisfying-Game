using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CalElement : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public Transform rightTrnform;
    private bool isDrag;
    private bool isP;
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject green;


    private void Awake()
    {
        isP = false;
        red = this.transform.GetChild(0).gameObject;
        green = this.transform.GetChild(1).gameObject;
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
        if (isDrag)
        {
            red.SetActive(true);
            green.SetActive(false);
        }
        
    }

    
    public void OnPointerUp(PointerEventData eventData)
    {
        isDrag = false;
        Check(rightTrnform, this.transform);
    }
    float Kc(Vector3 a, Vector3 b)
    {
        float kc = Mathf.Sqrt((a.x - b.x) *
                              (a.x - b.x) +
                              (a.y - b.y) *
                              (a.y - b.y));
        return kc;
    }
    void Check(Transform a, Transform b)
    {
        if (Kc(a.position, b.position)<= 0.08)
        {
            if (!isP)
            {
                b.position = a.position;
                Level10Controller.instance.countCal++;
                isP = true;
                SoundManager.instance.PlayOneShootAudio(SoundManager.instance.calButtonSourse);
                green.SetActive(true);
                red.SetActive(false);
                
            }
            
        }
        else
        {
            if (isP)
            {
                Level10Controller.instance.countCal--;
                isP = false;
            }
        }
        Level10Controller.instance.CheckWin();
    }
}
