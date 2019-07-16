using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_Behavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click_ToAttract() {
        SceneManager.LoadScene("Magnet_Attract", LoadSceneMode.Single);
    }

   public void Click_ToRepellent() {
        SceneManager.LoadScene("Magnet_Repellent", LoadSceneMode.Single);
    }

   public void Click_ToOne()
    {
        SceneManager.LoadScene("Magnet_One", LoadSceneMode.Single);
    }

}
