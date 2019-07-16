using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bangzhu : MonoBehaviour {


    private bool isDown = false;
    public GameObject help;


    void Start () {
		
	}
	
	void Update () {
        if (isDown)
        {
            help.SetActive(true);
        }
        else
        {
            help.SetActive(false);

        }
    }

    public void helpClick()
    {
        print("点击帮助");
        //isDown = true ;
        isDown = !isDown;



    }



}
