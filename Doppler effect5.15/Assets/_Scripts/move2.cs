using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;


public class move2 : MonoBehaviour {

    float spe;
    float speed2;

    public GameObject train;


    public GameObject particle;
    private ParticleSystemRenderer psr_train;
    public Vector3 pivot;


    public Material A;
    public Material B;

    private bool isDown = false;



  //  public GameObject fre;

    public Slider sd;     //滑块
    public Slider sd2;     //滑块

    public Text text;
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

    bool flag = false;
    int countFlag = 1;
    float distance;


    public Quaternion to;



    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = startPitch;

        psr_train = particle.GetComponent<ParticleSystemRenderer>();

    }


    // Update is called once per frame
    void Update()
    {
        spe = sd.value;
        speed2 = sd2.value;


        //audioSource.pitch = (340 + speed*10) / 150;
        // audioSource.pitch = gameObject.TransformPitch(10);
        text.text = sd.value.ToString();
        peopletext.text = sd2.value.ToString();

        // speed = sd.value;


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




        if (spe > 0)
        {
            trainmoveControl();
            //pivot.x = -0.002f * spe;

            if (spe < 50)
            {
                pivot.x = -0.004f * spe;
            }
            else
            {
                pivot.x = -0.2f;
            }



        }
        else if (spe < 0)
        {
            //pivot.x = -0.002f * spe;
            trainmoveControl2();

            if (spe > -50)
            {
                pivot.x = -0.004f * spe;
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




        //d为车与人的距离
        m = train.transform.position;
        n = people.transform.position;


        //判断车和人之间的距离，若靠近，频率变大；远离，频率变小。
        //if (countFlag % 2 == 1)
        //{
        //    distance = Vector3.Distance(m, n);
        //    countFlag++;
        //}
        //else
        //{
        //    if (Vector3.Distance(m, n) < distance)
        //    {
        //        flag = true;
        //       // peopleFre.text = (340 / (340 - spe) * 400).ToString() + "HZ";    //实时显示人接收到的频率
        //        peopleFre.text = (400 * (6120 + 5 * speed2*3.6) / (6120 - 5 * spe*3.6)).ToString() + "HZ";

        //        countFlag = 1;
        //    }
        //    else if (Vector3.Distance(m, n) == distance)
        //    {
        //        peopleFre.text = 400 + "HZ";
        //    }
        //        else
        //        {
        //        // peopleFre.text = (340 / (340 + spe) * 400).ToString() + "HZ";    //实时显示人接收到的频率
        //        peopleFre.text = (400 * (6120 - 5 * speed2*3.6) / (6120 + 5 * spe*3.6)).ToString() + "HZ";

        //    }

        //    distance = Vector3.Distance(m, n);

        //}







        //计算音量
        d = Vector3.Distance(m, n);
        a = Mathf.Pow(d,2);  //d的平方
        b = 100 - 10 * Mathf.Log10((a) / 100);//当前分贝值
        c = Mathf.Pow(10, (b - 100) / 10);  //当前音量
        audioSource.volume = c;

      //  peopleFre.text = (340 / (340 - speed) * 400).ToString() + "HZ";    //实时显示人接收到的频率
        fenbei.text = c.ToString(); //实时显示人听到的音量


        audioSource.pitch = (340 / (340 - spe) * 400) / 400;
        // audioSource.pitch = gameObject.TransformPitch(10);


        psr_train.pivot = pivot;

    }






    public void trainmoveControl()
    {
        to = Quaternion.Euler(0, -90, 90);
        train.transform.rotation = to;

        //train.transform.position = Vector3.MoveTowards(start.position, end.position, spe / 10 * Time.deltaTime);            //车移动
        //particle.transform.position = Vector3.MoveTowards(start.position, end.position, spe / 10 * Time.deltaTime);    //波纹移动
                                                                                                                       // fre.transform.position = Vector3.MoveTowards(start.position, end.position, speed / 10 * Time.deltaTime);
        train.transform.Translate(new Vector3(0, 0, -1) * 0.0027f * spe);//当速度为正时，小车沿着y轴负方向运动
        particle.transform.Translate(new Vector3(1, 0, 0) * 0.0027f * spe);

    }

    public void trainmoveControl2()
    {
        to = Quaternion.Euler(0, -270, 0);
        train.transform.rotation = to;
        // car.transform.Rotate(new Vector3(0, 0, 180));
        train.transform.Translate(new Vector3(0, 0, 1) * 0.0027f * -spe);//当速度为负时，小车沿着y轴正方向运动
        particle.transform.Translate(new Vector3(-1, 0, 0) * 0.0027f * -spe);


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




    public void trainClick()
    {
        print("点击行驶按钮！行驶");
        //isDown = true ;
        isDown = !isDown;



    }

    //设置进度为速度大小
    public void Control_spe()
    {
      // spe = sd.value;
    }



  
    
}
