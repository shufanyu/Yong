using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mingdi : MonoBehaviour
{

    //AudioSource audioSource;
    public GameObject car;
    public ParticleSystem pcar;

    public Button playBtn;
    public Button pauseBtn;


    void Start()
    {
        pcar.Stop();
        AudioSource As = gameObject.GetComponent<AudioSource>();
       // ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();
        playBtn.onClick.AddListener(delegate ()
        {
            As.Play();
            pcar.Play();
        });

        pauseBtn.onClick.AddListener(delegate ()
        {
            As.Pause();
            pcar.Pause();
        });
    }

    void Update()
    {

    }

    //public void Mingdi()
    //{
    //    car.SetActive(true);
    //    audioSource.isActiveAndEnabled



    //}
}