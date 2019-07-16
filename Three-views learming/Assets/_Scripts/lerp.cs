using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerp : MonoBehaviour {
	public Color32 lerpcolor = Color.red;
  

	void Start () {
		
	}
	

	void Update () {
		lerpcolor = Color32.Lerp (Color.red  ,Color.red, Time.time);
        gameObject.GetComponent<Renderer>().material.color = lerpcolor;


	}




}
