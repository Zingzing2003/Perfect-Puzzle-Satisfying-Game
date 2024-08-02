using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Level4Controller : MonoBehaviour
{
    public static Level4Controller instance;
    [SerializeField] private Button btnTouch;

    private Coroutine moveCoroutine;
    private Coroutine shakeCoroutine;
    
    public Transform cameraTransform;  // Transform của camera cần rung
    public float shakeDuration = 0.5f;
    public float shakeDuration2 = 1.3f;// Thời gian rung
    public float shakeMagnitude = 0.1f; // Độ mạnh của rung
    public float duration = 1;
    private Vector3 originalPosition; 
    
    
    
    public bool isTouch;
    public Vector3 posStart;
    private int curID = 0;
    [SerializeField] private GameObject fruitTransform;
    [SerializeField] private List<GameObject> listFruits;
    [SerializeField] private GameObject thanh;
    [SerializeField] private float speed;
    [SerializeField] private Transform lastTf;
    private void Awake()
    {
        instance = this;
        isTouch = false;
        posStart = thanh.transform.position;
    }

    private void Start()
    {
        cameraTransform = GameManager.instance.mainCam.transform;
    }

    public void StartShake()
    {
        originalPosition = cameraTransform.localPosition; // Lưu vị trí ban đầu của camera
        StartCoroutine(Shake()); // Bắt đầu coroutine rung
    }
    public void StartShakeSmall()
    {
        originalPosition = cameraTransform.localPosition; // Lưu vị trí ban đầu của camera
        shakeCoroutine=StartCoroutine(ShakeSmall()); // Bắt đầu coroutine rung
    }

    IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
           
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            cameraTransform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        cameraTransform.localPosition = originalPosition; // Đặt lại vị trí ban đầu của camera
    }
    IEnumerator ShakeSmall()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration2)
        {
            float x = Random.Range(-0.3f, 0.3f) * shakeMagnitude;
           
            float y = Random.Range(-0.3f, 0.3f) * shakeMagnitude;

            cameraTransform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        //cameraTransform.localPosition = originalPosition; // Đặt lại vị trí ban đầu của camera
    }


    public void MoveTouch()
    {
        if (isTouch)
        {
            //StartCoroutine(IEMoveDown());
            StartShakeSmall();
            moveCoroutine=StartCoroutine(MoveDownRoutine());
            StartCoroutine(IEWait());

        }
        else
        {
            
        }
    }

    IEnumerator IEWait()
    {
        yield return new WaitForSeconds(1.5f);
        if (thanh.transform.position.y <= fruitTransform.transform.position.y)
        {
            CallWin();
        }
    }

    void CallWin()
    {
        StartShake();
        listFruits[curID].GetComponent<Image>().enabled = false;
        for (int i = 0; i < 5;  i++)
        {
            listFruits[curID].transform.GetChild(i).gameObject.SetActive(true);
        }

        thanh.transform.position = lastTf.position;
        curID++;
        if (curID == 3)
        {
            GameManager.instance.WinGame();
            btnTouch.GetComponent<Image>().raycastTarget = false;
        }
        else
        {
            StartCoroutine(IEWaitNext());
            
        }
        
        
        
    }

    IEnumerator IEWaitNext()
    {
        yield return new WaitUntil(() =>
        {
            if (!isTouch)
            {
                listFruits[curID].SetActive(true);
                return true;
            }
            else
            {
                return false;
            }
        });
    }

    IEnumerator IEMoveDown()
    {
        yield return new WaitUntil(() =>
        {
            
            while (thanh.transform.position.y>= fruitTransform.transform.position.y)
            {
                thanh.transform.position += Vector3.down* speed* Time.deltaTime;
                
            }
            return true;
        });
    }
    IEnumerator MoveDownRoutine()
    {
        float elapsedTime = 0;
        Debug.Log("ghi");

        while (elapsedTime < duration)
        {
            thanh.transform.Translate(Vector3.down * speed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    public void CancelMove()
    {
        if (!isTouch)
        {
            StopCoroutine(moveCoroutine);
            StopCoroutine(shakeCoroutine);
            Debug.Log("BanDau");
            thanh.transform.position = posStart;
        }
    }
    
    
}
