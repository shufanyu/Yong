using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class menuBtn : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        CloseCameraDevice();

    }

    // Update is called once per frame
    void Update()
    {
        CloseCameraDevice();

    }

    public void loadscene()
    {
        SceneManager.LoadScene("ploarization_lab");
    }

    // 关闭相机
    public void CloseCameraDevice()
    {
        CameraDevice.Instance.Stop();
        CameraDevice.Instance.Deinit();
    }

    // 打开相机
    public void OpenCameraDevice()
    {
        CameraDevice.Instance.Init(CameraDevice.CameraDirection.CAMERA_DEFAULT);
        CameraDevice.Instance.Start();
    }

    // 关闭识别
    public void CloseCloudReco()
    {
        CloudRecoBehaviour cloudRecoBehaviour = GameObject.FindObjectOfType(typeof(CloudRecoBehaviour)) as CloudRecoBehaviour;
        cloudRecoBehaviour.CloudRecoEnabled = false;
    }

    // 打开识别
    public void OpenCloudReco()
    {
        CloudRecoBehaviour cloudRecoBehaviour = GameObject.FindObjectOfType(typeof(CloudRecoBehaviour)) as CloudRecoBehaviour;
        cloudRecoBehaviour.CloudRecoEnabled = true;
    }

}
