﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;


public class AnswerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //找到按钮，并且获取按钮的Button组件
        Button btn = GameObject.Find("myBtn").GetComponent<Button>();
        //注册按钮的点击事件
        btn.onClick.AddListener(delegate () {
            this.Btn_Test();
        });

    }
    void Btn_Test()
    {
        Debug.Log("这是一个按钮点击事件！哈哈");
    }

}
