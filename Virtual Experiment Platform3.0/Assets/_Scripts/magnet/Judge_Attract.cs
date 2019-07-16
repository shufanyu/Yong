using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge_Attract : MonoBehaviour
{

    public static bool isD1n2s = false;


    public GameObject magnet1_s, magnet1_n, magnet2_s, magnet2_n;
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
        d1s2s = Vector3.Distance(v1s, v2s);
        d1s2n = Vector3.Distance(v1s, v2n);
        d1n2n = Vector3.Distance(v1n, v2n);
        d1n2s = Vector3.Distance(v1n, v2s);
        if ((d1n2s < d1n2n) && (d1n2s < d1s2n) && (d1n2s < d1s2s)) isD1n2s = true; else isD1n2s = false;

    }
}
