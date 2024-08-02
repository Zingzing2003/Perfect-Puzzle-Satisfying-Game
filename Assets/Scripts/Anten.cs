using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Anten : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    
    [SerializeField] private bool isTouch;
   
    private void Awake()
    {
        
    }

    private void Update()
    {
        if (isTouch)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 a = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        a.z = 0;
        // float ch = Mathf.Sqrt((a.x - this.transform.position.x) * (a.x - this.transform.position.x) +
        //                       (a.y - this.transform.position.y) * (a.y - this.transform.position.y));
        // float cgv = (float)Mathf.Abs(a.y - this.transform.position.y);
        Vector3 direction = a - this.transform.position;

        // Tính toán góc quay cần thiết
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        
        if (direction.x< direction.y && angle >= 90) angle = 90 - angle;
        Debug.Log(angle);
        // Cập nhật góc quay của đối tượng
        if (Mathf.Abs(angle)<=90) transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        float kNhieu = Mathf.Abs(45 - angle)/50;
        Color color = Level7Controller.instance.errScreen.GetComponent<Image>().color;
        color.a = kNhieu;
        Level7Controller.instance.errScreen.GetComponent<Image>().color = color;
        //this.transform.position = a;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
        isTouch = true;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        Vector3 a = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        a.z = 0;
        CheckWin(a);
        
        
    }

    void CheckWin(Vector3 a)
    {
        Vector3 direction = a - this.transform.position;

        // Tính toán góc quay cần thiết
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        
        if (direction.x< direction.y && angle >= 90) angle = 90 - angle;
        //Debug.Log(angle);
        
        if (Mathf.Abs(45- angle) < 2)
        {
            this.gameObject.GetComponent<Image>().raycastTarget = false;
            GameManager.instance.WinGame();
        }
    }
}
