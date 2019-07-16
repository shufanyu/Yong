using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class labcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void enter1()
    {
        SceneManager.LoadScene("1menu");
    }
    public void enter2()
    {
        SceneManager.LoadScene("2menu");
    }
    public void enter3()
    {
        SceneManager.LoadScene("4lab");
    }
    public void enter4()
    {
        SceneManager.LoadScene("5menu");
    }

    public void enter5()
    {
        SceneManager.LoadScene("0Main Menu");
    }
    public void enter6()
    {
        SceneManager.LoadScene("3lab");
    }
    public void enter7()
    {
        SceneManager.LoadScene("6");
    }
}
