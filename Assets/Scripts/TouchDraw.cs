using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchDraw : MonoBehaviour
{
    Coroutine drawing;
    public GameObject linePrefab;
    public Camera mainCam;
    public static List<LineRenderer> drawnLineRenderers= new List<LineRenderer>();
    
    public Scratch scratchScript;
    public GameObject spriteBui;

    [SerializeField] private List<Transform> tfPoint;
    public List<bool> vt;
    [SerializeField] private GameObject khan;
    private bool isTouch;
    private void Awake()
    {
        mainCam = GameManager.instance.mainCam;
        for (int i = 0; i < tfPoint.Count; i++)
        {
            vt.Add(false);
        }

        isTouch = false;
    }

    void Update(){
        if(Input.GetMouseButtonDown(0))
        {
            isTouch = true;
                StartLine();
        }
        if(Input.GetMouseButtonUp(0))
        {
            isTouch = false;
            FinishLine();
        }

        // if (isTouch)
        // {
        //     Vector3 position = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //     position.z = 0;
        //     khan.transform.position = position;
        // }
    }
    public void StartLine(){
        if(drawing!=null){
            StopCoroutine(drawing);
        }
        drawing = StartCoroutine(DrawLine());
    }
    public void FinishLine(){
        if(drawing!=null)
        StopCoroutine(drawing);
        CheckWin();

    }

    void CheckWin()
    {
        for (int i = 0; i < tfPoint.Count; i++)
        {
            if(!vt[i]) return;
        }
        drawnLineRenderers[0].gameObject.SetActive(false);
        drawnLineRenderers.Clear();
        spriteBui.gameObject.SetActive(false);
        GameManager.instance.WinGame();
    }
    IEnumerator DrawLine(){
        GameObject newGameObject = Instantiate(linePrefab, new Vector3(0,0,0), Quaternion.identity);
        LineRenderer line =  newGameObject.GetComponent<LineRenderer>();
        drawnLineRenderers.Add(line);
        line.positionCount = 0;
        while(true){
            Vector3 position = mainCam.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            line.positionCount++;
            line.SetPosition(line.positionCount-1, position);
            CheckPoint(line);
            
            scratchScript.AssignScreenAsMask();
            position.z = -1;
            khan.transform.position = position;
            
            yield return null;
        }
    }


    void CheckPoint(LineRenderer line)
    {
        Vector3 a= line.GetPosition(line.positionCount - 1);
        for (int i = 0; i < tfPoint.Count; i++)
        {
            if (!vt[i])
            {
                float kc = Kc(a, tfPoint[i].position);
                float kc2 = line.startWidth/2;
                if (kc <= kc2)
                {
                    vt[i] = true;
                    break ;
                }
            }
        }
        return ;
    }

    float Kc(Vector3 a, Vector3 b)
    {
        float d = (float)Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
        return d;
    }
}

