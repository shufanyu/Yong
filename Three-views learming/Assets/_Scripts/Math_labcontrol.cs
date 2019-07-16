using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Math_labcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void enter1()
    {
        SceneManager.LoadScene("Three-views_lab1");
    }
    public void enter2()
    {
        SceneManager.LoadScene("Three-views_lab2");
    }
    public void enter4()
    {
        SceneManager.LoadScene("Three-views_lab3");
    }
}
