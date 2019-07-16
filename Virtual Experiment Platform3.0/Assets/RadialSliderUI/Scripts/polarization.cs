using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class polarization : MonoBehaviour
{
    public Text degreeA1;
    public Text degreeA2;

    public float deltaDegree;
    float I0;
    float I1;
    float I2;
    float I3;
    public Image image0;
    public Image image1;
    public Image image2;
    public Image image3;
    private void Start()
    {
        I0 = image0.color.a;
        print(I0);
        I1 = image1.color.a;
        I2 = image2.color.a;
        I3 = image3.color.a;
    }
    private void Update()
    {
        deltaDegree = float.Parse(degreeA2.text) - float.Parse(degreeA1.text);
        print(I0+"   kkk"+ calI1(I0));

        image1.color = new Color(image1.color.r,image1.color.g,image1.color.b,calI1(I0));
        image2.color = new Color(image2.color.r, image2.color.g, image2.color.b, calI2(I0));
        image3.color = image2.color;
    }
    public float calI1(float i)
    {
        return i/2;
    }
    public float calI2(float j)
    {

        return ( j/2 * Mathf.Cos(deltaDegree * Mathf.Deg2Rad) * Mathf.Cos(deltaDegree * Mathf.Deg2Rad));
    }



}
