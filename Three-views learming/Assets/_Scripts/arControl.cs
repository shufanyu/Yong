using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arControl : MonoBehaviour {

    public Text ar1;
    public Text ar2;
    private float MoveSpeed;
    public Transform avoidGimbo1;
    public Transform avoidGimbo2;

    public Light spotLight;
    private float lightProtIntensity;
    public float deltaDe;
	void Start () {
        MoveSpeed = 5f;
        lightProtIntensity = spotLight.intensity;
	}
	
	// Update is called once per frame
	void Update () {
        float de1=  float.Parse(ar1.text);
        float de2 = float.Parse(ar2.text);
        deltaDe = de2-de1;
        print(gameObject.transform.rotation.eulerAngles);
       // print(Quaternion.Euler(0, 0, de1));
        avoidGimbo1.rotation = Quaternion.Slerp(avoidGimbo1.rotation, Quaternion.Euler(0, 0, de1), Time.deltaTime * MoveSpeed);
        avoidGimbo2.rotation = Quaternion.Slerp(avoidGimbo2.rotation, Quaternion.Euler(0, 0, de2), Time.deltaTime * MoveSpeed);
        spotLight.intensity = ploLight(lightProtIntensity);
       
    }
    public float ploLight(float j)
        {

            return (j / 2 * Mathf.Cos(deltaDe* Mathf.Deg2Rad) * Mathf.Cos(deltaDe* Mathf.Deg2Rad));
        }


}
