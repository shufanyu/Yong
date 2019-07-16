using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Bezier : MonoBehaviour
{
    private LineRenderer lineRenderer;     //定义
    //public Material lineMat;            //线的材质
    private float startWidth = 0.001f;       //起始宽度
    private float endWidth = 0.001f;        //末尾宽度
    private Color lineColor = Color.green;    //颜色设置
    public int lineVertex = 20;         //线分割成几段
    float jianxi = 0.05f;              //绘制的0-1的间隙 越小曲线越接近曲线，  


    //****** 1级贝塞尔 *******
    public void line_one_bezier(GameObject v0, GameObject v1) {
        Vector3[] linePoints = new Vector3[lineVertex];    //空间向量组，用于赋值
        GetPoints(linePoints,v0,v1);
        // if (Object1_TrackableEventHandler.object1_get)
        //  {
        if (GetComponent<LineRenderer>())
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        else
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.enabled = true;
            lineRenderer.SetPositions(linePoints);
       // }


    }
    
    //*****************
    void GetPoints(Vector3[] linePoints, GameObject v0, GameObject v1)
    {
        float j = 0;
        for (int i = 0; i < lineVertex; i++)
        {
            linePoints[i] = Po(j, v0, v1);
            j += jianxi;
            //Debug.Log(j);
            //Debug.Log(linePoints[i]);
        }
    }

    private Vector3 Po(float t, GameObject start01, GameObject end01)//根据当前时间t 返回路径  其中v0为起点 v1为终点 a为中间点  
    {
        Vector3 a;
        a.x = (1 - t) * start01.transform.position.x + t * end01.transform.position.x;
        a.y = (1 - t) * start01.transform.position.y + t * end01.transform.position.y;
        a.z = (1 - t) * start01.transform.position.z + t * end01.transform.position.z;
        return a;
    }

    //**********************




    //****** 3级贝塞尔*******

    public void line_three_bezier(GameObject v0, GameObject v1, GameObject v2, GameObject v3)
    {
        Debug.Log(lineVertex);
        Vector3[] linePoints = new Vector3[lineVertex];    //空间向量组，用于赋值
        GetPoints(linePoints,v0,v1,v2,v3);
        //  Debug.Log(line_middle.isget);
        //  if (Object1_TrackableEventHandler.object1_get)

        // {
        // Debug.Log(line_middle.isget);
        if (GetComponent<LineRenderer>())
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        else
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();

        }
        lineRenderer.enabled = true;
        lineRenderer.alignment = LineAlignment.View;  //alignment：组件是否面向相机
                                                      //*****上述赋值
        lineRenderer.positionCount = lineVertex;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        // lineRenderer.material = lineMat;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.SetPositions(linePoints);
       // }


    }

    //************

    void GetPoints(Vector3[] linePoints, GameObject v0, GameObject v1, GameObject v2, GameObject v3)
    {
        float j = 0;
        Debug.Log("getpoints:lineVertex,jianxi:"+lineVertex+" "+jianxi);
        for (int i = 0; i < lineVertex; i++)
        {
            linePoints[i] = Po(j, v0,v1,v2,v3);
            j += jianxi;
            //Debug.Log(j);
            //Debug.Log(linePoints[i]);
        }
    }

    private Vector3 Po(float t, GameObject v0, GameObject v1, GameObject a0, GameObject a1)//根据当前时间t 返回路径  其中v0为起点 v1为终点 a为中间点  
    {
        Vector3 a;
        a.x = (1 - t) * (1 - t) * (1 - t) * v0.transform.position.x + 3 * (1 - t) * (1 - t) * t * a0.transform.position.x + 3 * (1 - t) * t * t * a1.transform.position.x + t * t * t * v1.transform.position.x;
        //公式为B(t)=(1-t)^3*P0 + 3*(1-t)^2*t*P1+ 3*(1-t)*t^2*P2 + t^3*P3   
        a.y = (1 - t) * (1 - t) * (1 - t) * v0.transform.position.y + 3 * (1 - t) * (1 - t) * t * a0.transform.position.y + 3 * (1 - t) * t * t * a1.transform.position.y + t * t * t * v1.transform.position.y;
        a.z = (1 - t) * (1 - t) * (1 - t) * v0.transform.position.z + 3 * (1 - t) * (1 - t) * t * a0.transform.position.z + 3 * (1 - t) * t * t * a1.transform.position.z + t * t * t * v1.transform.position.z; ;

        return a;
    }

    //**************


}
