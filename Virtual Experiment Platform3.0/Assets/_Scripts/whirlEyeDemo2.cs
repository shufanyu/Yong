using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.XR;
using UnityEngine.UI;

public class whirlEyeDemo2 : MonoBehaviour
{
    public Camera _camera;
    public Text _text;
    Color _oldColor;
    public Canvas[] eye_component;
    public static string RayHittReturnName;
     Touch oldTouch1;
     Touch oldTouch2;

    float oldis = 0, newdis = 0;
    private void Start()
    {

        //CloudRecoBehaviour cloudRecoBehaviour = GameObject.FindObjectOfType(typeof(CloudRecoBehaviour)) as CloudRecoBehaviour;//找到当前的云识别组件
        //cloudRecoBehaviour.CloudRecoEnabled = false;//禁用云识别，当前摄像头依然是活动的，仅可以识别当前的识别卡
        CameraDevice.Instance.Stop();//停止当前的摄像头
        CameraDevice.Instance.Deinit();//将当前的摄像头禁用掉（反实例化），以便重新启用新的摄像头

    }
    void Update()
    {
        #region touch
        if (Input.touchCount == 1)
        {
            RaycastHit Hitt = new RaycastHit();
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Physics.Raycast(ray, out Hitt);
            var hitObj = Hitt.collider.transform.gameObject;
            var renderer =hitObj.GetComponent<Renderer>();
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
               
                RayHittReturnName = hitObj.name;
                string info=null;
                switch (RayHittReturnName)
                {
                    case "DM_Lenscrystallina": info = "晶状体";break;
                    case "DM_Sclera_Right": info = "巩膜"; break;
                    case "DM_Choroidea_Right": info = "脉络膜"; break;
                    case "DM_Cornea": info = "角膜"; break;
                    case "DM_Corpusciliare_Iris_Right": info = "睫状体"; break;
                    case "DM_Corpusciliare_Right": info = "睫状体"; break;
                    case "DM_Corpusvitreum": info = "玻璃体"; break;
                    case "DM_Iris": info = "虹膜"; break;
                    case "DM_nerve_": info = "神经元"; break;
                    case "DM_Retina_Right": info = "视网膜"; break;
                    default:break;
                }
               
                _text.text = info;
            }
            if (Input.GetTouch(0).phase==TouchPhase.Moved)
            {
                var touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(touchDeltaPosition.x * 0.001f, 0, touchDeltaPosition.y * 0.001f, Space.World);
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended &&Input.GetTouch(0).phase!=TouchPhase.Canceled )
            {
                RayHittReturnName = null;
              
            }
            
            
        }
        #endregion

        if (Input.touchCount == 2)
        {
            //记录新输入的两根手指
            Touch newTouch1 = Input.GetTouch(0);
            Touch newTouch2 = Input.GetTouch(1);
            //第二根手指刚触碰的时候，记录这两个手指的按的位置，作为老的事件
            if (newTouch2.phase == TouchPhase.Began)
            {
                oldTouch1 = newTouch1;
                oldTouch2 = newTouch2;
               //这边返回是因为记录好旧的位置之后需要记录新的位置
                return;
            }
            float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
            float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);
            float angle = Vector2.Angle(new Vector2(newTouch1.position.x - oldTouch1.position.x, newTouch1.position.y - oldTouch1.position.y),
                new Vector2(newTouch2.position.x - oldTouch2.position.x, newTouch2.position.y - oldTouch2.position.y));

            //两个距离之差，为正表示放大手势， 为负表示缩小手势
            float offset = newDistance - oldDistance;

            //放大因子， 一个像素按 0.01倍来算(100可调整)
            float scaleFactor = offset / 50f;
            //向量夹角大于45°时缩放
            if (angle > 45)
            {
                //插值缩放
                transform.localScale = Vector3.Lerp(transform.localScale,
                    new Vector3(Mathf.Clamp(transform.localScale.x + scaleFactor, 0.3f, 5f),
                                Mathf.Clamp(transform.localScale.y + scaleFactor, 0.3f, 5f),
                                Mathf.Clamp(transform.localScale.z + scaleFactor, 0.3f, 5f)), Time.deltaTime * 2);
                //碰到的位置进行记录，下次以这个为基准继续操作
            }
            else
            {
                var touchDeltaPosition = newTouch1.deltaPosition;
                transform.Translate(touchDeltaPosition.x * 0.001f, 0, touchDeltaPosition.y * 0.001f, Space.World);
              

            }

            oldTouch1 = newTouch1;
            oldTouch2 = newTouch2;

        }

    
    }
}
