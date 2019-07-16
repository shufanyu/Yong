using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;


//控制旋转
public class RotateControl : MonoBehaviour
{

    private Vector3 startFingerPos;
    private Vector3 nowFingerPos;
    private float xMoveDistance;
    private float yMoveDistance;
    private int backValue = 0;
    public GameObject obj;
    public ParticleSystem pcar;
 
    void Update()
    {
        if (Input.touchCount <= 0)
        {
            return;
        }

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Debug.Log("======开始触摸=====");  
            startFingerPos = Input.GetTouch(0).position;
        }

        nowFingerPos = Input.GetTouch(0).position;

        if ((Input.GetTouch(0).phase == TouchPhase.Stationary) || (Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            startFingerPos = nowFingerPos;
            //Debug.Log("======释放触摸=====");  
            return;
        }
        //          if (Input.GetTouch(0).phase == TouchPhase.Ended) {  
        //                
        //          }  
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
            pcar.transform.Rotate(Vector3.up * -1 * Time.deltaTime * 50, Space.World);
            obj.transform.Rotate(Vector3.up * -1 * Time.deltaTime * 50, Space.World);
        }
        else if (backValue == 1)
        {
            pcar.transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.World);
            obj.transform.Rotate(Vector3.up * Time.deltaTime * 50, Space.World);
        }
        else if (backValue == 2)
        {
            pcar.transform.Rotate(Vector3.right * Time.deltaTime * 50, Space.World);
            obj.transform.Rotate(Vector3.right * Time.deltaTime * 50, Space.World);
        }
        else if (backValue == -2)
        {
            pcar.transform.Rotate(Vector3.right * -1 * Time.deltaTime * 50, Space.World);
            obj.transform.Rotate(Vector3.right * -1 * Time.deltaTime * 50, Space.World);
        }

    }


}
