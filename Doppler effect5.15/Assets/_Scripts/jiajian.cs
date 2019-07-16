using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jiajian : MonoBehaviour {


    public Slider sd;     //滑块

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void jiacontrol()
    {
        sd.value++;
    }
    public void jiancontrol()
    {
        sd.value--;
    }
}

