using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpControl : MonoBehaviour {

    public Button helpBtn;
    public Text help;


    void Start () {
        helpBtn.onClick.AddListener(delegate ()
        {
            help.IsActive();
        });
    }
	
	void Update () {
		
	}
}
