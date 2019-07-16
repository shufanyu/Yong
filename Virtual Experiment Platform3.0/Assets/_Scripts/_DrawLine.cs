using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DrawLine : MonoBehaviour {

     LineRenderer _Line;
    public Transform[] DrawLineObject;

	void Start () {
        _Line = GetComponent<LineRenderer>();
        _Line.positionCount=2;
      
    }
	
	
	void Update () {
       
        try
        {
            _Line.SetPosition(0, DrawLineObject[0].position);
            _Line.SetPosition(1, DrawLineObject[1].position);
        }
        catch (System.Exception)
        {

            throw;
        }
       

	}
}
