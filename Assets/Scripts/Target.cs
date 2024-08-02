using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField]
    private float speedRotate;
    void Update()
    {
        this.transform.Rotate(-Vector3.forward, speedRotate*Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
       
    }
}
