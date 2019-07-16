using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Attract_OneBezier : MonoBehaviour {
    private LineRenderer lineRenderer;     //定义
    //public Material lineMat;            //线的材质
    private float startWidth = 0.001f;       //起始宽度
    private float endWidth = 0.001f;        //末尾宽度
    private float startArrow = 0.001f;
    private float endArrow = 0.003f;
    private Color lineColor = Color.green;    //颜色设置
    private int lineVertex = 20;         //线分割成几段
    float jianxi = 0.05f;              //绘制的0-1的间隙 越小曲线越接近曲线，  
    public GameObject s0, m0, jt;
   

    // Use this for initialization
    void Start()
    {
        if (GetComponent<LineRenderer>())
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
        else
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        lineRenderer.enabled = false;
        jt.GetComponent<LineRenderer>().enabled = false;   //先阻止其画线
        lineRenderer.alignment = LineAlignment.View;  //alignment：组件是否面向相机
                                                      //*****上述赋值
        lineRenderer.positionCount = lineVertex;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        
        jt.GetComponent<LineRenderer>().startWidth = startArrow;
        jt.GetComponent<LineRenderer>().endWidth = endArrow;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3[] linePoints = new Vector3[lineVertex];    //空间向量组，用于赋值
        Vector3[] arrowPoints = new Vector3[2];
        GetPoints(linePoints, arrowPoints);
        if (Object1_TrackableEventHandler.object1_get&&Object2_TrackableEventHandler.object2_get&&Judge_Attract.isD1n2s)
        {
            lineRenderer.enabled = true;
            jt.GetComponent<LineRenderer>().enabled = true;
            lineRenderer.SetPositions(linePoints);
            jt.GetComponent<LineRenderer>().SetPositions(arrowPoints);

        }
        else
        {
            lineRenderer.enabled = false;
            jt.GetComponent<LineRenderer>().enabled = false;
        }




    }

    void GetPoints(Vector3[] linePoints, Vector3[] arrowPoints)
    {
        float j = 0;
        Vector3 d;
        for (int i = 0; i < lineVertex; i++)
        {
            d = Po(j, s0, m0);
            linePoints[i] = d;
            j += jianxi;
            if (i == (lineVertex / 2)) { arrowPoints[0] = d; }
            if (i == (lineVertex / 2 + 2)) { arrowPoints[1] = d; }

        }
    }

    private Vector3 Po(float t, GameObject v0, GameObject v1)                              //根据当前时间t 返回路径  其中v0为起点 v1为终点 a为中间点  
    {
        Vector3 a;
        a.x = (1 - t) * v0.transform.position.x + t * v1.transform.position.x;
        a.y = (1 - t) * v0.transform.position.y + t * v1.transform.position.y;
        a.z = (1 - t) * v0.transform.position.z + t * v1.transform.position.z;
        return a;
    }

}
