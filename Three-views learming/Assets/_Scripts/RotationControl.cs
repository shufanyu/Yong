using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RotationControl : MonoBehaviour
{
    public Quaternion to;
    private bool isRotate = false;
    public Button Btn; // 按钮
    public GameObject gb;
    public bool isDraw = false;
    public Button answerBtn; // 答案按钮
    public GameObject zheng;
    public GameObject zuoshi;
    public GameObject fushi;



    //定义菜单项贴图  
    public Texture start;
    public Texture exit;

    //定义标准屏幕分辨率  
    public float m_fScreenWidth = 1280;
    public float m_fScreenHeight = 800;

    //定义缩放系数  
    public float m_fScaleWidth;
    public float m_fScaleHeight;


    void Start()
    {
        //找到按钮，并且获取按钮的Button组件
        //Button btn = GameObject.FindGameObjectWithTag("answer").GetComponent<Button>();
        //注册按钮的点击事件
        answerBtn.onClick.AddListener(delegate () {
            this.Btn_Test();

        });


        zheng.active = false;//设置开始不可见
        zuoshi.active = false;//设置开始不可见
        fushi.active = false;//设置开始不可见

    }
    void Btn_Test()
    {
        bshow = !bshow;
        isDraw = !isDraw;

    }



    void Update()
    {

        //计算缩放系数  
        m_fScaleWidth = (float)Screen.width / m_fScreenWidth;
        m_fScaleHeight = (float)Screen.height / m_fScreenHeight;
    }

    bool bshow = false;
    void OnGUI()
    {
        if (bshow)
        {
            var speed = 0.1f;
            GUI.skin.button.fontSize = 20;
            if (!isRotate)
            {
                if (GUI.Button(new Rect(160 * m_fScaleWidth, 735 * m_fScaleHeight, 80 * m_fScaleWidth, 30 * m_fScaleHeight), "正视图"))
                {
                    if (zheng.active == true)
                    {
                        zheng.SetActive(false);
                    }
                    else if (zheng.active == false )
                    {
                        zheng.SetActive(true);
                    }

                    isRotate = true;
                    to = Quaternion.Euler(90, -90, -90);
                    transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.time * speed);

                    //  this.transform.eulerAngles = new Vector3(0,90,0);
                    // this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * 5);
                if (Quaternion.Angle(to, transform.rotation) < 1)
                {
                    transform.rotation = to;
                    isRotate = false;
                    //   Debug.Log(isRotate);
                }
            }




            if (!isRotate)
            {
                if (GUI.Button(new Rect(260 * m_fScaleWidth, 735 * m_fScaleHeight, 80 * m_fScaleWidth, 30 * m_fScaleHeight), "左视图"))
                {

                    if (zuoshi.active == true)
                    {
                        zuoshi.SetActive(false);
                    }
                    else if (zuoshi.active == false)
                    {
                        zuoshi.SetActive(true);
                    }

                    isRotate = true;
                    to = Quaternion.Euler(0, -90, -90);
                    //   this.transform.rotation = Quaternion.Euler(0, 270, 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.time * speed);

                }
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * 5);
                if (Quaternion.Angle(to, transform.rotation) < 1)
                {
                    transform.rotation = to;
                    isRotate = false;
                }
            }






            if (!isRotate)
            {
                if (GUI.Button(new Rect(360 * m_fScaleWidth, 735 * m_fScaleHeight, 80 * m_fScaleWidth, 30 * m_fScaleHeight), "俯视图"))
                {
                    if (fushi.active == true)
                    {
                        fushi.SetActive(false);
                    }
                    else if (fushi.active == false)
                    {
                        fushi.SetActive(true);
                    }

                    isRotate = true;
                    to = Quaternion.Euler(180, -180, -180);
                    transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.time * speed);
                    // this.transform.rotation = Quaternion.Euler(270, 0, 0);
                }
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * 5);
                if (Quaternion.Angle(to, transform.rotation) < 1)
                {
                    transform.rotation = to;
                    isRotate = false;
                }
            }

        }

       
    }





    //public void front()
    //{
    //    var speed = 0.1f;
    //    if (!isRotate)
    //    {
    //        Btn.onClick.AddListener(delegate ()
    //        {
    //            isRotate = true;
    //            to = Quaternion.Euler(90, -90, -90);
    //            gb.transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.time * speed);
    //        });
    //    }
    //    else
    //    {
    //        gb.transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * 5);
    //        if (Quaternion.Angle(to, transform.rotation) < 1)
    //        {
    //            gb.transform.rotation = to;
    //            isRotate = false;
    //            //   Debug.Log(isRotate);
    //        }
    //    }
    //}


    //public void left()
    //{
    //    var speed = 0.1f;
    //    if (!isRotate)
    //    {
    //        Btn.onClick.AddListener(delegate ()
    //        {
    //            isRotate = true;
    //            to = Quaternion.Euler(0, -90, -90);
    //            //   this.transform.rotation = Quaternion.Euler(0, 270, 0);
    //            gb.transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.time * speed);
    //        });
    //    }
    //    else
    //    {
    //        gb.transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * 5);
    //        if (Quaternion.Angle(to, transform.rotation) < 1)
    //        {
    //            gb.transform.rotation = to;
    //            isRotate = false;
    //        }
    //    }
    //}



    //public void top()
    //{
    //    var speed = 0.1f;
    //    if (!isRotate)
    //    {
    //        Btn.onClick.AddListener(delegate ()
    //        {
    //            isRotate = true;
    //            to = Quaternion.Euler(180, -180, -180);
    //            gb.transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.time * speed);
    //            // this.transform.rotation = Quaternion.Euler(270, 0, 0);
    //        });
    //    }
    //    else
    //    {
    //        gb.transform.rotation = Quaternion.Slerp(transform.rotation, to, Time.deltaTime * 5);
    //        if (Quaternion.Angle(to, transform.rotation) < 1)
    //        {
    //            gb.transform.rotation = to;
    //            isRotate = false;
    //        }
    //    }
    //}

}

