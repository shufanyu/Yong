using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_SceneControl : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void GoMathScene()
    {
        SceneManager.LoadScene("Math_menu");
    }
    public void GoPhysicalScene()
    {
        SceneManager.LoadScene("Physical_menu");
    }
    public void GoChemistryScene()
    {
        SceneManager.LoadScene("Chemistry_menu");
    }
    public void GoBiologicalScene()
    {
        SceneManager.LoadScene("Biological_menu");
    }
}
