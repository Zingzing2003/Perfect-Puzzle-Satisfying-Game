using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public static GameConfig instance;

    private void Awake()
    {
        instance = this;
    }

    public int levelSelected;
    public int curentLevel;
}
