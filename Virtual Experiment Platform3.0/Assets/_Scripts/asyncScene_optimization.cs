using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class asyncScene_optimization : MonoBehaviour
{

    AsyncOperation asy; //协程的变量
    public Slider slider;
    float value = 0;//滑动条的值
    void Start()
    {

    }
    public void return_mathmenu()
    {

        StartCoroutine(LoadScene());
       // asy.allowSceneActivation = true;

    }



    // Update is called once per frame
    void Update()
    {
        if (asy == null)
        {
            return;
        }
        int jd = 0;
        if (asy.progress < 0.9f)
        {
            jd = (int)asy.progress * 1;

        }
        else
        {
            jd = 1;
        }
        if (value < jd)
        {
            value++;

        }
        slider.value = value / 1;
        if (value == 1)
        {
            asy.allowSceneActivation = true;
        }

    }

    IEnumerator LoadScene()
    {
        asy = SceneManager.LoadSceneAsync(14);
        asy.allowSceneActivation = false;
        yield return asy;
       // yield return null;
    }
}