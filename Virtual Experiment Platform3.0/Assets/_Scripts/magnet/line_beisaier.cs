using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line_beisaier : MonoBehaviour {
    private LineRenderer lineRenderer;     //定义
    public Material lineMat;            //线的材质
    private float startWidth = 0.001f;       //起始宽度
    private float endWidth = 0.001f;        //末尾宽度
    public Color lineColor = Color.green;    //颜色设置
    private int lineVertex = 20;         //线分割成几段
    float jianxi = 0.05f;              //绘制的0-1的间隙 越小曲线越接近曲线， 
   
    public GameObject s0, n0, m0;
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
            lineRenderer.positionCount = lineVertex;
            lineRenderer.startWidth = startWidth;
            lineRenderer.endWidth = endWidth;
            lineRenderer.material = lineMat;
            lineRenderer.startColor = lineColor;
            lineRenderer.endColor = lineColor;
            lineRenderer.numCapVertices = 90;

        
        }
        // Update is called once per frame
        void Update()
    {
     
            Vector3[] linePoints = new Vector3[lineVertex];    //空间向量组，用于赋值
            GetPoints(linePoints);
            lineRenderer.enabled = true;
            lineRenderer.SetPositions(linePoints);
 
    }
    void GetPoints(Vector3[] linePoints)
    {
        float j = 0;
        for (int i = 0; i < lineVertex; i++)
        {
            linePoints[i] = po(j, s0, n0, m0);
            j += jianxi;
            //Debug.Log(linePoints[i]);
        }
    }
    private Vector3 po(float t, GameObject v0, GameObject v1, GameObject a0)//根据当前时间t 返回路径  其中v0为起点 v1为终点 a为中间点 
    {
        Vector3 a;
        
        a.x = t * t * (v1.transform.position.x - 2 * a0.transform.position.x + v0.transform.position.x) + v0.transform.position.x + 2 * t * (a0.transform.position.x - v0.transform.position.x);
        //公式为B(t)=(1-t)^2*v0+2*t*(1-t)*a0+t*t*v1 其中v0为起点 v1为终点 a为中间点 
        a.y = t * t * (v1.transform.position.y - 2 * a0.transform.position.y + v0.transform.position.y) + v0.transform.position.y + 2 * t * (a0.transform.position.y - v0.transform.position.y);
        a.z = t * t * (v1.transform.position.z - 2 * a0.transform.position.z + v0.transform.position.z) + v0.transform.position.z + 2 * t * (a0.transform.position.z - v0.transform.position.z);
        return a;
    }
}



