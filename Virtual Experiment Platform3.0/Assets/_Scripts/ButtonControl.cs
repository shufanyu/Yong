using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour {

    public Animator _split;
    public Animator _combine;
    public Animator _intro;

    public GameObject[] InformationGameObjects;
    private bool isActive= false;
    public void eyeSplit()
    {
        _split.SetBool("eyeSplit",true) ;
        _split.SetBool("eyeCombine", false);
    }

    public void eyeCombine()
    {
        _split.SetBool("eyeSplit", false);
        _split.SetBool("eyeCombine", true);
    }
    public void intro()
    {
        SceneManager.LoadScene("EyeVu_Intro");
    }

    public void research()
    {
        SceneManager.LoadScene("EyeVu_Start");
    }

    public void review()
    {
        if (isActive == false)
        {
            InformationGameObjects[0].SetActive(true);
            InformationGameObjects[1].SetActive(true);
            isActive = true;
        }
        else
        {
            InformationGameObjects[0].SetActive(false);
            InformationGameObjects[1].SetActive(false);
            isActive = false;
        }
    }
}
