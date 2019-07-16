using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_control : Line_Bezier
{
    public GameObject magnet1_s, magnet1_n, magnet2_s, magnet2_n, s1, s2;
    private Vector3 v1s, v1n, v2s, v2n, v1, v2;
    float d1s2s, d1s2n, d1n2s, d1n2n;

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
        v1 = s1.transform.position;
        v2 = s1.transform.position;
        // d1s2s = Vector3.Distance(v1s,v2s);
        //d1s2n = Vector3.Distance(v1s,v2n);
        //d1n2n = Vector3.Distance(v1n,v2n);
        //d1n2s = Vector3.Distance(v1n,v2s);
        // JudgeDistance(d1s2s, d1s2n, d1n2s, d1n2n);
        if (Object1_TrackableEventHandler.object1_get && Object2_TrackableEventHandler.object2_get)
        {
            line_three_bezier(magnet1_s, magnet1_n, magnet2_s, magnet2_n);
            line_one_bezier(s1, s2);
        }
        else if (Object1_TrackableEventHandler.object1_get == false && Object2_TrackableEventHandler.object2_get)
        {
            Debug.Log("1不在！");
        }
        else
        {
            Debug.Log("2不在！");
        }




    }

    /* float JudgeDistance(float d1s2s, float d1s2n, float d1n2s, float d1n2n) {
         if ((d1n2s < d1n2n) && (d1n2s < d1s2n) && (d1n2s < d1s2s)) return d1n2s;
         else if ((d1n2n < d1n2s) && (d1n2n < d1s2n) && (d1n2n < d1s2s)) return d1n2n;
         else if ((d1s2n < d1n2s) && (d1s2n < d1n2n) && (d1s2n < d1s2s)) return d1s2n;
         else return d1s2n; 
     }
     */
}
