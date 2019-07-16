using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Des : MonoBehaviour
{

    
     public GameObject SwordPrefab;
     public GameObject JwordPrefab;
    
    //private void Awake()
    //{
    //    SworldPrefab.SetActive (false);

    //}

    private void Start()
    {
        SwordPrefab = GameObject.Find("Sword");
        JwordPrefab = GameObject.Find("Jword");
       
    }

    public void OnTriggerEnter(Collider other)
 
    {

        if (other.tag == "waterS")
        {
            Destroy(this.gameObject);

            other.gameObject.GetComponent<Renderer>().material.SetColor("_RefrColor", Color.red);

            var scale = 1;
            other.gameObject.transform.localScale += new Vector3(0,0,0.01f * scale);

            SwordPrefab.GetComponent<CanvasGroup>().alpha = 1;
  
          


        }
        if (other.tag == "waterJ")
        {
            Destroy(this.gameObject);

            other.gameObject.GetComponent<Renderer>().material.SetColor("_RefrColor", Color.blue);

           JwordPrefab.GetComponent<CanvasGroup>().alpha = 1;

            var scale = 1;
            other.gameObject.transform.localScale += new Vector3(0,0,0.01f * scale);


        }

    }
}
