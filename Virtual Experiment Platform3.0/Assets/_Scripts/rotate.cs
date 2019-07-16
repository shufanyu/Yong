using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class rotate : MonoBehaviour
{
    private Vector3 startFingerPos;
    private Vector3 nowFingerPos;
    private float xMoveDistance;
    private float yMoveDistance;
    private int backValue = 0;
    int fingerCount;
    [HideInInspector]
    public float spinSpeed = 0f;
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
        if (fingerCount == 2)
            JudgeFinger();
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



    public void JudgeFinger()
    {




        #region 双指旋转
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {

            //Debug.Log("======开始触摸=====");  

            startFingerPos = Input.GetTouch(0).position;


        }

        nowFingerPos = Input.GetTouch(0).position;

        if (((Input.GetTouch(0).phase == TouchPhase.Stationary) || (Input.GetTouch(0).phase == TouchPhase.Ended)))
        {

            startFingerPos = nowFingerPos;
            //Debug.Log("======释放触摸=====");  
            return;
        }
        //          if (Input.GetTouch(0).phase == TouchPhase.Ended) {  
        //                
        //          }  
        #endregion

        if (startFingerPos == nowFingerPos)
        {
            return;
        }
        xMoveDistance = Mathf.Abs(nowFingerPos.x - startFingerPos.x);

        yMoveDistance = Mathf.Abs(nowFingerPos.y - startFingerPos.y);

        if (xMoveDistance > yMoveDistance)
        {

            if (nowFingerPos.x - startFingerPos.x > 0)
            {

                //Debug.Log("=======沿着X轴负方向移动=====");  

                backValue = -1; //沿着X轴负方向移动  

            }
            else
            {

                //Debug.Log("=======沿着X轴正方向移动=====");  

                backValue = 1; //沿着X轴正方向移动  

            }

        }
        else
        {

            if (nowFingerPos.y - startFingerPos.y > 0)
            {

                //Debug.Log("=======沿着Y轴正方向移动=====");  

                backValue = 2; //沿着Y轴正方向移动  

            }
            else
            {

                //Debug.Log("=======沿着Y轴负方向移动=====");  

                backValue = -2; //沿着Y轴负方向移动  

            }

        }
        if (backValue == -1)
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 300, Space.World);

        }
        else if (backValue == 1)
        {
            transform.Rotate(Vector3.down * -1 * Time.deltaTime * 300, Space.World);

        }
        else if (backValue == 2)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * 200, Space.World);
        }
        else if (backValue == -2)
        {
            transform.Rotate(Vector3.right * -1 * Time.deltaTime * 200, Space.World);
        }

    }
}
