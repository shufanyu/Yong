using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_test : MonoBehaviour {
    public GameObject s4, n4, m4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(s4.transform.position,m4.transform.position, Color.green);
        Debug.DrawLine(n4.transform.position, m4.transform.position, Color.green);
    }
}
