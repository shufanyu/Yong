using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zishiying : MonoBehaviour {


    //定义标准屏幕分辨率  
    public float m_fScreenWidth = 1280;
    public float m_fScreenHeight = 800;

    //定义缩放系数  
    public float m_fScaleWidth;
    public float m_fScaleHeight;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        //计算缩放系数  
        m_fScaleWidth = (float)Screen.width / m_fScreenWidth;
        m_fScaleHeight = (float)Screen.height / m_fScreenHeight;
    }
}
