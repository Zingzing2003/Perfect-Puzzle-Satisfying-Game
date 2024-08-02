using System;
using System.Collections;
// using Cysharp.Threading.Tasks.Triggers;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    public static LoadingPanel instance;
    // [SerializeField] private Image bgImage;
    [SerializeField] CanvasGroup canvas = default;
    [SerializeField] Image progressbar = default;
    private bool isShowedOpenAds = false;

    private bool isLoad = false;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        GotoScene("Home", (() => { }));
    }

    // private void OnEnable()
    // {
    //     SetUpBG();
    // }

    public IEnumerator ActiveScene(Action action)
    {
        yield return new WaitUntil(() => isLoad);
        action.Invoke();
        // SoundManager.instance.PlayAudio(SoundManager.instance.gameAudioSource);
        canvas.DOFade(0f, 0.4f).OnComplete(() => { canvas.gameObject.SetActive(false); });
    }

    public void GotoScene(string scene, Action action)
    {
        isLoad = false;
        // SoundManager.instance.StopAudio(SoundManager.instance.gameAudioSource);
        StartCoroutine(FadeOutScene(scene, action));
    }

    IEnumerator FadeInScene(string scene, Action action)
    {
        yield return new WaitForFixedUpdate();
        action.Invoke();
        if (!isLoad)
        { 
            isLoad = true;
        }
    }

    IEnumerator FadeOutScene(string scene, Action action)
    {
        progressbar.fillAmount = 0;
        canvas.alpha = 0;
        canvas.gameObject.SetActive(true);
        bool fadeDone = false;
        canvas.DOFade(1f, 0.4f).OnComplete((() => { fadeDone = true; }));
        yield return new WaitUntil((() => fadeDone));
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            progressbar.fillAmount = async.progress / 3;
            yield return null;
            {
                async.allowSceneActivation = true;
            }
        }

        float timerPro = 2;
        while (timerPro > 0)
        {
            timerPro -= Time.fixedDeltaTime;
            progressbar.fillAmount += Time.fixedDeltaTime / 2;
            yield return new WaitForFixedUpdate();
        }

        progressbar.fillAmount = 1;
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(FadeInScene(scene, action));
    }
}