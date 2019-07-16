using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reset : MonoBehaviour {

    public Transform start;
    public Transform start2;
    public Transform start_people;
    public Transform startPc;
    public Transform startTrain;



    //人初始位置
    public Quaternion iniRotaMan;
    Vector3 posMan;

    //小车初始位置
    public Quaternion iniRotaCar;
    Vector3 posCar;

    //小车初始位置
    public Quaternion iniRotaTrain;
    Vector3 posTrain;

    public Quaternion iniRotaPc;
    Vector3 posPc;


    public GameObject car;
    public GameObject people;
    public GameObject train;
    public GameObject Particle;
    public GameObject Particle2;

    public Text car_frequency;


    private bool isDown = false;


    void Start () {
        iniRotaMan = start_people.transform.localRotation;
        posMan = start_people.transform.localPosition;

        iniRotaCar = start.transform.localRotation;
        posCar = start.transform.localPosition;

        iniRotaPc = startPc.transform.localRotation;
        posPc = startPc.transform.localPosition;

        iniRotaTrain = startTrain.transform.localRotation;
        posTrain = startTrain.transform.localPosition;

    }


    void Update ()
    {
        if (isDown)
        {
            car_reset();
            train_reset();
            isDown = false;
        }
    }


    public void carClick()
    {
        print("复位！");
        isDown = true ;
       // isDown = !isDown;
    }
    public void car_reset()
    {
        car.transform.localPosition = posCar;
        car.transform.localRotation = iniRotaCar;

        train.transform.localPosition = posTrain;
        train.transform.localRotation = iniRotaTrain;

        car_frequency.transform.position = start2.position;

        people.transform.localPosition = posMan;
        people.transform.localRotation = iniRotaMan;

        Particle.transform.localPosition = posPc;
        Particle.transform.localRotation = iniRotaPc;

        Particle2.transform.localPosition = posPc;
        Particle2.transform.localRotation = iniRotaPc;

    }




    public void trainClick()
    {
        print("复位！");
        isDown = true;
        // isDown = !isDown;
    }
    public void train_reset()
    {
        //train.transform.position = start.position;
      //  Particle2.transform.position = start.position;
       // car_frequency.transform.position = start2.position;
       // people.transform.position = start_people.position;
    }
}
