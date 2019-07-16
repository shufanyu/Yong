using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCollider : MonoBehaviour {

    Color defaultColor;
    Color newColor;
	// Use this for initialization
	void Start () {
        defaultColor= GetComponent<Renderer>().material.color;
        newColor =new Color(1, 0, 0, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if(whirlEyeDemo2.RayHittReturnName == transform.name)
        {
            GetComponent<Renderer>().material.color = newColor;
        }
        else
        {
            GetComponent<Renderer>().material.color = defaultColor;
        }

	}
}
