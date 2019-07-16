using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArcSlider : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    public Image handleButton;
    float circleRadius = 0.0f;

    bool isPointerDown = false;
    public Image baseCircle;

    //忽略圈内的交互
    public float ignoreInTouchRadiusHandleOffset = 10;

    Vector3 handleButtonLocation;

    [Tooltip("初始角度到终止角度")]
    public float firstAngle = 0;
    public float secondAngle = 360;

    float tempAngle = 30;//用来缓动
    public void Start()
    {
        circleRadius = Mathf.Sqrt(Mathf.Pow(handleButton.GetComponent<RectTransform>().localPosition.x, 2) + Mathf.Pow(handleButton.GetComponent<RectTransform>().localPosition.y, 2));//按钮到圆心的距离
        ignoreInTouchRadiusHandleOffset = circleRadius - ignoreInTouchRadiusHandleOffset;//按钮到圆心的距离-忽略的距离
        handleButtonLocation = handleButton.GetComponent<RectTransform>().localPosition;//按钮的初始位置
    }
    public void Update()
    {
        //用来重置
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReSet(); //如果按R重置
        }
    }
    public void ReSet()
    {
        handleButton.GetComponent<RectTransform>().localPosition = handleButtonLocation; //恢复原始位置
    }
	public void OnPointerEnter( PointerEventData eventData ) //当光标进入
	{
       
		StartCoroutine( "TrackPointer" );
	}

    //如果需要移动到外部时仍然有效可以去掉这里的
    //public void OnPointerExit( PointerEventData eventData )
	//{
	//	StopCoroutine( "TrackPointer" );
	//}
    
    public void OnPointerDown(PointerEventData eventData) //当鼠标按下去（或者获取触摸按下）
	{
       
        isPointerDown = true;
	}

	public void OnPointerUp(PointerEventData eventData) //当鼠标松开（或者触摸松开）
	{
       
        isPointerDown = false;
	}
    
	IEnumerator TrackPointer()
	{
		var ray = GetComponentInParent<GraphicRaycaster>();
		var input = FindObjectOfType<StandaloneInputModule>();

		var text = GetComponentInChildren<Text>();//获取text
        
		if( ray != null && input != null ) //如果能正常获取到射线以及鼠标/键盘输入
		{
			while( Application.isPlaying )//正在运行
			{                    
				//这个是左侧的
				if (isPointerDown)
				{
					Vector2 localPos;
                    //获取鼠标当前位置out里赋值，屏幕坐标转换成recttransform
					RectTransformUtility.ScreenPointToLocalPointInRectangle( transform as RectTransform, Input.mousePosition, ray.eventCamera, out localPos );
                   // print(localPos);
                   localPos.x = -localPos.x;
                    
                    //半径
                    float mouseRadius = Mathf.Sqrt(localPos.x*localPos.x+localPos.y*localPos.y);
                    //float tempDegree = localPos.x;
                    //localPos.x = localPos.y;
                    //localPos.y = tempDegree;
                    //阻止圆内部点击的响应，只允许在一个圆环上进行响应
                    if (mouseRadius > ignoreInTouchRadiusHandleOffset)// && handleButton.GetComponent<RectTransform>().localPosition.x <= 0
                    {
                        //0-180  -180-0偏移后的角度 从第一象限校正到0-360(即圆的左边是起始0点)
                        float angle = (Mathf.Atan2(localPos.y, localPos.x)) * Mathf.Rad2Deg; //Atan2 tan转化为弧度，弧度变为角度(这边的原理参考一下Atan2与Atan的区别)

                       
                        // print(angle+"    y/x= "+localPos.y/localPos.x+  "   弧度1="+ Mathf.Atan2(localPos.y, localPos.x)+"    弧度2："+　Mathf.Atan(localPos.y/localPos.x) );
                        //角度转换为0-360
                        if (angle < 0) angle = 360 + angle;
                        //避免出错后的重置 
                       
                        if (angle < firstAngle) angle = firstAngle;
                        if (angle > secondAngle) angle = secondAngle;
                      //此处缓动函数：理解，比如说现在处于30°的状态那么到60°第一次运算是angle=30+60/2=45 依次45+60/2=55.5 ，55.5+60/2=57.75 ....最后为60°
                      //即不是一下子到指定角度而是慢慢的过去到指定角度
                        angle = (tempAngle + angle) / 2f;
                       
                      
                        tempAngle = angle;
                       
                        //改变小圆的位置，（正弦余弦转换）
                        handleButton.GetComponent<RectTransform>().localPosition = new Vector3(Mathf.Cos(-angle / Mathf.Rad2Deg +  Mathf.PI) * circleRadius, Mathf.Sin(-angle / Mathf.Rad2Deg +  Mathf.PI) * circleRadius, 0);


                      //  this.transform.parent.GetComponent<Image>().color = Color.Lerp(Color.green, Color.blue, (angle - firstAngle) / (secondAngle - firstAngle));

                            
                        //数值的偏移值
                        float temp = secondAngle - firstAngle;// 360 - 285 + 64;
                        //归一化
                        float tempangle = (angle - firstAngle)/ (secondAngle - firstAngle);

                        //可能会出现很小的数 注意保留小数位数
                        // text.text = tempangle.ToString();
                        text.text = angle.ToString();
                    }
                }
				yield return 0;
			}        
		}   
	}
}
