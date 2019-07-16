using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (MeshFilter))]
public class Drop : MonoBehaviour
{

    //声明滴下点
    public Transform droppoint;
    //声明水滴实例
    public Rigidbody dropwater;
    //初始化滴下时间
    private float nextFire = 1F;
    //声明水滴间隔
    public float fireRate = 2F;

    public GameObject WaterPrefab;

    private void Start()
    {
       
        WaterPrefab = GameObject.Find("Water");
    }


    // Update is called once per frame
    void Update()
    {

        //点击左键并且时间已经大于间隔时间
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.transform.localScale = new Vector3(4, 4, 5);

            dropwater.transform.Translate(Vector3.right * Time.deltaTime * 1);
            //更新间隔时间
            nextFire = Time.time + fireRate;
            //实例化水滴
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(dropwater, droppoint.position, droppoint.rotation);
        

            var scale = 1;
            WaterPrefab.gameObject.transform.localScale -= new Vector3(0,0,0.001f * scale);


        }

        if (Input.GetMouseButtonUp(0))
        {
           
            gameObject.transform.localScale = new Vector3(7, 5, 5);
        }
    }
}