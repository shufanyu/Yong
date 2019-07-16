using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge_Repellent : MonoBehaviour
{
    bool isD1n2n = false;
    bool isD1s2s = false;


    public GameObject magnet1_s, magnet1_n, magnet2_s, magnet2_n;
    private Vector3 v1s, v1n, v2s, v2n, v1, v2;
    float d1s2s, d1s2n, d1n2s, d1n2n;
    public GameObject m1s1, m1s2, m1s3,m1s4,m2s1,m2s2,m2s3,m2s4,m1n1, m1n2, m1n3, m1n4, m2n1, m2n2, m2n3, m2n4;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        v1s = magnet1_s.transform.position;
        v1n = magnet1_n.transform.position;
        v2s = magnet2_s.transform.position;
        v2n = magnet2_n.transform.position;
        d1s2s = Vector3.Distance(v1s, v2s);
        d1s2n = Vector3.Distance(v1s, v2n);
        d1n2n = Vector3.Distance(v1n, v2n);
        d1n2s = Vector3.Distance(v1n, v2s);

        if ((d1n2n < d1n2s) && (d1n2n < d1s2n) && (d1n2n < d1s2s))
        {
            //  isD1n2n = true;
            Debug.Log(d1n2n);
            m1n1.SetActive(true);
            m1n2.SetActive(true);
            m1n3.SetActive(true);
            m1n4.SetActive(true);
            m2n1.SetActive(true);
            m2n2.SetActive(true);
            m2n3.SetActive(true);
            m2n4.SetActive(true);
            m1s1.SetActive(false);
            m1s2.SetActive(false);
            m1s3.SetActive(false);
            m1s4.SetActive(false);
            m2s1.SetActive(false);
            m2s2.SetActive(false);
            m2s3.SetActive(false);
            m2s4.SetActive(false);
        }
       else  if ((d1s2s < d1n2s) && (d1s2s < d1s2n) && (d1s2s < d1n2s))
        {
            //  isD1s2s = true;
           // Debug.Log(d1s2s);
            m1s1.SetActive(true);
            m1s2.SetActive(true);
            m1s3.SetActive(true);
            m1s4.SetActive(true);
            m2s1.SetActive(true);
            m2s2.SetActive(true);
            m2s3.SetActive(true);
            m2s4.SetActive(true);
            m1n1.SetActive(false);
            m1n2.SetActive(false);
            m1n3.SetActive(false);
            m1n4.SetActive(false);
            m2n1.SetActive(false);
            m2n2.SetActive(false);
            m2n3.SetActive(false);
            m2n4.SetActive(false);
        }
        else
        {
           // isD1s2s = false;
            m1n1.SetActive(false);
            m1n2.SetActive(false);
            m1n3.SetActive(false);
            m1n4.SetActive(false);
            m2n1.SetActive(false);
            m2n2.SetActive(false);
            m2n3.SetActive(false);
            m2n4.SetActive(false);
            m1s1.SetActive(false);
            m1s2.SetActive(false);
            m1s3.SetActive(false);
            m1s4.SetActive(false);
            m2s1.SetActive(false);
            m2s2.SetActive(false);
            m2s3.SetActive(false);
            m2s4.SetActive(false);


        }

}
}

