using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitchControl : MonoBehaviour {

    public int startPitch = 1;
    AudioSource audioSource;



	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = startPitch;
	}
	

	void Update () {
        
	}
}
