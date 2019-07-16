using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown_test : MonoBehaviour {


    Dropdown dpn;
    public GameObject car;
    public GameObject train;
    private bool isDown = false;
    public GameObject railway;
    public GameObject partCar;
    public GameObject partTrain;




    void Start () {
        //Dropdown.OptionData data1 = new Dropdown.OptionData();
        //data1.text = "汽车";
        //Dropdown.OptionData data2 = new Dropdown.OptionData();
        //data2.text = "火车";
        dpn = transform.GetComponent<Dropdown>();
        //dpn.options.Add(data1);
        //dpn.options.Add(data2);

    }


    public void Drop_select(int n)
    {

        print("选择了:" + dpn.captionText.text);

    }



    public void ConsoleResult(int value)
    {
        //这里用 if else if也可，看自己喜欢
        //分别对应：第一项、第二项....以此类推
        switch (value)
        {
            case 0:
                print("选择了汽车");
                car.SetActive(true);
                train.SetActive(false);
                railway.SetActive(false);
                partCar.SetActive(true);
                partTrain.SetActive(false);

                GameObject.Find("trainControl").GetComponent<move2>().enabled = false;
                GameObject.Find("trainControl").GetComponent<AudioSource>().enabled = false;
                GameObject.Find("carControl").GetComponent<move>().enabled = true ;
                GameObject.Find("carControl").GetComponent<AudioSource>().enabled = true;
                isDown = false;

                break;


        
            case 1:
                print("选择了火车");
                train.SetActive(true);
                car.SetActive(false);
                railway.SetActive(true);
                partCar.SetActive(false);
                partTrain.SetActive(true);

                GameObject.Find("carControl").GetComponent<move>().enabled = false;
                GameObject.Find("carControl").GetComponent<AudioSource>().enabled = false;
                GameObject.Find("trainControl").GetComponent<move2>().enabled = true;
                GameObject.Find("trainControl").GetComponent<AudioSource>().enabled = true;

                isDown = true;
                break;

 
            //如果只设置的了4项，而代码中有第五个，是调用不到的
            //需要对应在 Dropdown组件中的 Options属性 中增加选择项即可
        }
    }



    void Update () {
        if (!isDown)
        {
            train.SetActive(false);
            GameObject.Find("trainControl").GetComponent<move2>().enabled = false;
            GameObject.Find("trainControl").GetComponent<AudioSource>().enabled = false;

        }

    }
}
