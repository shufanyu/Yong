using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_middle : MonoBehaviour {
    public static bool isget = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Object1_TrackableEventHandler.object1_get)
        {
            isget = true;
        }
        else isget = false;
	}
}
