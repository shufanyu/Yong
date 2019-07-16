using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frequencyTest : MonoBehaviour {

    public float xOffset;
    public float yOffset;
    public RectTransform recTransform;

    void Start () {
		
	}
	
	void Update () {
        if (recTransform == null)
        {
            return;
        }

        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        recTransform.position = player2DPosition + new Vector2(xOffset, yOffset);



    }
}
