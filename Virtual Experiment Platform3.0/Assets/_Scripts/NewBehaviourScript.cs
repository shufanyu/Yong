using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public bool isShow = false;

    void Update()

    {

        //如果按下鼠标左键
        if (Input.GetMouseButtonDown(0))
            isShow = !isShow;

    }

    void OnGUI()

    {

        if (isShow)

            GUI.Label(new Rect(900, 300, 100, 30), "叫我红领巾！");

    
    }
}
