using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnMath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void mathReturn()
    {
        SceneManager.LoadScene("Math_menu2");
    }


    public void Click_Back()
    {
        StartCoroutine(Load());


    }
    IEnumerator Load()
    {

        AsyncOperation op = SceneManager.LoadSceneAsync("Math_menu2");
        yield return new WaitForEndOfFrame();
        op.allowSceneActivation = true;

    }



}

