using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Controller : MonoBehaviour
{
    public static Level3Controller instance;
    [SerializeField] private List<PopitElement> listPopit;
    public int total;

    private void Awake()
    {
        instance = this;
        total = listPopit.Count;
    }
    
    
}
