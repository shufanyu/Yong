using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Sub_SceneControl : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }
    public void Return_main()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Return()
    {
        SceneManager.LoadScene("Math_menu");
    }
    public void Math_enter1()
    {
        SceneManager.LoadScene("Math_menu2");
    }
    public void Physical_enter1()
    {
        SceneManager.LoadScene("ploarization_lab");
    }
    public void Physical_enter2()
    {
        SceneManager.LoadScene("Magnet_One");
    }

    public void Chemistry_enter1()
    {
        SceneManager.LoadScene("Acid-base titration");
    }
    public void Biological_enter1()
    {
        SceneManager.LoadScene("EyeVu_Start");
    }
}
