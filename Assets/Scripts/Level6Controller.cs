using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level6Controller : MonoBehaviour
{
    public static Level6Controller instance;
    [SerializeField] private GameObject knifePrefab;
     [SerializeField] private float speedMove;
    private bool isMoveKnife;
    [SerializeField] private Transform startTransform;
    public GameObject go;
    public bool win = false;
    [SerializeField] private List<GameObject> listHeart;

    public int hp = 4;
    private void Awake()
    {
        instance = this;
        InsKnife();
    }

    public void InsKnife()
    {
       
        hp--;
        if (hp < 3)
        {
            listHeart[4-hp-2].SetActive(false);
        }
        if( hp>=0) StartCoroutine(IEInsKnife());
        else
        {
            if (!win)
            {
                GameManager.instance.OpenFailePopup();
            }
           
        }
        
        
        

    }

    IEnumerator IEInsKnife()
    {
        yield return new WaitForSeconds(0.5f);
        
        Vector3 st = startTransform.position;
        go= Instantiate(knifePrefab,st, Quaternion.identity, this.transform);
        //Instantiate()
    }
}
