using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class frequencyPeople : MonoBehaviour {

    public float xOffset;
    public float yOffset;

    public float xOffset2;
    public float yOffset2;

    public RectTransform recTransform;
	public RectTransform fenbeiTransform;





    void Start () {
		
	}
	
	void Update () {
        if (recTransform == null)
        {
            return;
        }

        Vector2 player2DPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        recTransform.position = player2DPosition + new Vector2(xOffset, yOffset);


        if (fenbeiTransform == null)
        {
            return;
        }

        Vector2 player22DPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        fenbeiTransform.position = player22DPosition + new Vector2(xOffset2, yOffset2);


    }


   








}
