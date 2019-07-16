using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;


public class move : MonoBehaviour {


    float speed;
    float speed2;

    public GameObject car;


    public GameObject particle;
    //public Color colorEnd;
    //public Color colorStart;


    private bool isDown = false;
    public Button driving;



  //  public GameObject fre;

    public Slider sd;     //滑块
    public Slider sd2;     //滑块

    public Text cartext;
    public Text peopletext;

    public int startPitch = 1;
    AudioSource audioSource;


    public Text peopleFre;
    public Text fenbei;


    //距离
    public GameObject people;
    public Vector3 m;
    public Vector3 n;
    public float d;
    public float a;
    public float b;
    public float c;

 //   List<object> ob = new List<object>();
    public float[] juli;
    bool flag = false;
    int countFlag = 0;
    float distance;

    public Quaternion to;


    //修改粒子系统中心点
    private ParticleSystemRenderer psr_car;
    public Vector3 pivot;




    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = startPitch;


        psr_car = particle.GetComponent<ParticleSystemRenderer>();


    }

    void Update()
    { 
        speed2 = sd2.value;


        //// 创建GameObject对象
        //GameObject gameObj = new GameObject();

        //// 获取SpriteRenderer对象
        //SpriteRenderer spr = gameObj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        //// 添加图片        把上面的sprite赋值给他            
        //spr.sprite = imgS;     // Resources.Load("triangle.png", typeof(Sprite)) as Sprite;

        //// 设置位置    
        //spr.transform.position = new Vector2(0, 0);

        //audioSource.pitch = (340 + speed*10) / 150;
        // audioSource.pitch = gameObject.TransformPitch(10);
        cartext.text = sd.value.ToString();
        peopletext.text = sd2.value.ToString();


        //if (isDown)
        //{

        //    moveControl();
        //    Text text = driving.transform.Find("Text").GetComponent<Text>();
        //    text.text = "暂停";
        //}
        //else
        //{
        //    Text text = driving.transform.Find("Text").GetComponent<Text>();
        //    text.text = "行驶";
        //}


        //小车速度，控制小车移动
        if (speed > 0)
        {
            float lerp = Mathf.Lerp(Time.time * 0.15f, 1.0f, 0.001f);
            carmoveControl();



            //   pivot.x = -0.002f * speed ;

            if (speed < 50)
            {
                pivot.x = -0.004f * speed;
            }
            else
            {
                pivot.x = -0.2f;
            }


        }
        else  if (speed < 0)
         {
           // pivot.x = -0.002f * speed;
            carmoveControl2();

            if (speed > -50)
            {
                pivot.x = -0.004f * speed;
            }
            else
            {
                pivot.x = -0.2f;
            }
        }
        else
        {
            pivot.x = 0;

        }





        //人的速度，控制人移动
        if (speed2 > 0)
        {
            peoplemoveControl();
        }
        else if (speed2 < 0)
        {
            peoplemoveControl2();
        }


        //distance为车与人的距离
        m = car.transform.position;
        n = people.transform.position;

        //判断车和人之间的距离，若靠近，频率变大；远离，频率变小。
        if (countFlag < 30)
        {
            if (countFlag == 0)
            {
                distance = Vector3.Distance(m, n);
                
            }
               countFlag++;
        }
        else
        {
            if (Vector3.Distance(m, n) < distance&&speed!=0&&countFlag%30==0)  //靠近
            {
                flag = true;
                peopleFre.text = (400 * (6120 + 5 * Mathf.Abs(speed2) * 3.6) / (6120 - 5 * Mathf.Abs(speed) * 3.6)).ToString("f2") + "HZ";
                countFlag = 0;
            }
            
            else if (Vector3.Distance(m, n) == distance)
            {
                peopleFre.text = 400 + "HZ";
            }
            else if(Vector3.Distance(m, n) > distance && speed != 0 && countFlag % 30 == 0)
            {
                flag = true;
                peopleFre.text = (400 * (6120 - 5 * Mathf.Abs(speed2) * 3.6) / (6120 + 5 * Mathf.Abs(speed) * 3.6)).ToString("f2") + "HZ";
                countFlag = 0;
            }

            //distance = Vector3.Distance(m, n);
        }







        ////计算音量
        //d = Vector3.Distance(m, n);
        //a = Mathf.Pow(d,2);  //d的平方
        //b = 100 - 10 * Mathf.Log10((a) / 100);//当前分贝值
        //c = Mathf.Pow(10, (b - 100) / 10);  //当前音量
        //audioSource.volume = c;

      //  peopleFre.text = (340 / (340 - speed) * 400).ToString() + "HZ";    //实时显示人接收到的频率
      //  fenbei.text = c.ToString(); //实时显示人听到的音量


        audioSource.pitch = (340 / (340 - speed) * 400) / 400;
        // audioSource.pitch = gameObject.TransformPitch(10);




        psr_car.pivot = pivot;





    }

    //void OnGUI()
    //{
    //    if (!aTexture)
    //    {
    //        Debug.LogError("Assign a Texture in the inspector.");
    //        return;
    //    }
    //    GUI.DrawTexture(new Rect(10, 10, 200, 200), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
    //}



    public void carmoveControl() {
        to = Quaternion.Euler(180, 0, 90);
        car.transform.rotation = to;
        car.transform.Translate(new Vector3(0, -1, 0) *0.0027f*speed);//当速度为正时，小车沿着y轴负方向运动
        particle.transform.Translate(new Vector3(1, 0, 0) * 0.0027f * speed);
    }

    public void carmoveControl2() {
        to = Quaternion.Euler(180, 0, 270);
        car.transform.rotation = to;
        car.transform.Translate(new Vector3(0, -1, 0) * 0.0027f * -speed);//当速度为负时，小车沿着y轴正方向运动
        particle.transform.Translate(new Vector3(-1, 0, 0) * 0.0027f * -speed);


    }


    //控制人移动
    public void peoplemoveControl()
    {
        to = Quaternion.Euler(0, 90, -90);
        people.transform.rotation = to;
        // people.transform.Translate(new Vector3(0, -1, 0) * speed2);//当速度为正时
        people.transform.Translate(new Vector3(0, 0, 1) * 0.00027f * speed2);
    }
    public void peoplemoveControl2()
    {
        to = Quaternion.Euler(0, 270, 90);
        people.transform.rotation = to;
        people.transform.Translate(new Vector3(0, 0, 1) * 0.00027f * -speed2);//当速度为负时
    }



    public void carClick()
    {
        print("点击行驶按钮！行驶");
        //isDown = true ;
        isDown = !isDown;



    }

    //设置进度为速度大小
    public void Control_speed()
    {
        speed = sd.value;
    }
    public void Control_speed2()
    {
        //speed2 = sd2.value;
    }

  
}
