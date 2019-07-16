using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Whirl : MonoBehaviour
{

    int fingerCount;

    Camera _arCamera;
    //  Transform rotator;
    private void Start()
    {

        _arCamera = GameObject.Find("ARCamera").GetComponent<Camera>();
    }
    void Update()
    {
        // transform.Rotate(new Vector3(0f, spinSpeed * Time.deltaTime, 0f));
        //没有触摸  ，触摸手指为0
        if (Input.touchCount <= 0)
        {
            return;
        }
        else
            fingerCount = Input.touchCount;


        #region 单指移动
        if (fingerCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //Debug.Log("======开始触摸=====");  
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(touchDeltaPosition.x * 0.001f, touchDeltaPosition.y * 0.001f, 0, Space.World);



            }
        }
        #endregion
    }
}

