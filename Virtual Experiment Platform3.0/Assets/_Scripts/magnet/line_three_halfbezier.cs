using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_three_halfbezier : MonoBehaviour {
    private LineRenderer lineRenderer;     //定义
    //public Material lineMat;            //线的材质
    private float startWidth = 0.001f;       //起始宽度
    private float endWidth = 0.001f;        //末尾宽度
    private Color lineColor = Color.green;    //颜色设置
    private int lineVertex = 20;         //线分割成几段
    public int lineDrawVertex = 6;
    public GameObject s0, n0, m0, m1;
    float jianxi = 0.05f;              //绘制的0-1的间隙 越小曲线越接近曲线，  
                                     
    string startname;             //判断从哪一磁极出发
    bool Nstart;               // true，n极出发，false，s极出发

    //箭头
    public GameObject jt;
    private float startArrow = 0.001f;
    private float endArrow = 0.003f;

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
        lineRenderer.enabled = false;  //先阻止其画线
        lineRenderer.alignment = LineAlignment.View;  //alignment：组件是否面向相机
                                                      //*****上述赋值
        lineRenderer.positionCount = lineDrawVertex;
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;
        // lineRenderer.material = lineMat;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        //箭头
        jt.GetComponent<LineRenderer>().startWidth = startArrow;
        jt.GetComponent<LineRenderer>().endWidth = endArrow;

     //
      startname=m0.name;
        if (startname.Contains("mn")) Nstart = true;
        else Nstart = false;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3[] linePoints = new Vector3[lineDrawVertex];    //空间向量组，用于赋值
        Vector3[] arrowPoints = new Vector3[2];

        GetPoints(linePoints,arrowPoints);

        if (Object_One_TrackableEventHandler.object_get)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPositions(linePoints);
            jt.GetComponent<LineRenderer>().SetPositions(arrowPoints);
        }
        else
        {
            lineRenderer.enabled = false;
        }




    }

    void GetPoints(Vector3[] linePoints,Vector3[] arrowPoints)
    {
        float j = 0;
        Vector3 d;
        for (int i = 0; i < lineVertex; i++)
        {
            if (i < lineDrawVertex) {
                d = Po(j, s0, n0, m0, m1);
                linePoints[i] = d;

                if (i == (lineDrawVertex / 2 - 1))
                {
                    if (Nstart) arrowPoints[1] = d; else arrowPoints[0] = d;
                }
                if (i == (lineDrawVertex / 2))
                {
                    if (Nstart) arrowPoints[0] = d; else arrowPoints[1] = d;
                }
            }
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

}

