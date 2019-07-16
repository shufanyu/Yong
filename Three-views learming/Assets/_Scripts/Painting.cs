
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine.UI;

public class Painting : MonoBehaviour
{
    public Rect rect;
    //存储路径  
    private string Path_save;
    private string destination;
    Texture2D screenShot;
    public Text text;
    public float countTime = 5f;
    public float lastTime;
    private float curTime;
    public GameObject ga;

    private RenderTexture texRender;
    public Material mat;
    GameObject gb;
    public bool isDraw = false;


    //定义菜单项贴图  
    public Texture start;
    public Texture exit;

    //定义标准屏幕分辨率  
    public float m_fScreenWidth = 1280;
    public float m_fScreenHeight = 800;

    //定义缩放系数  
    public float m_fScaleWidth;
    public float m_fScaleHeight;



    private enum BrushType
    {
        valid,
        invalid,
        count
    }
    private BrushType brushType = BrushType.valid;
    public Texture brushTypeTexture;

    private enum BrushColor
    {
        red,
        green,
        blue,
        pink,
        yellow,
        gray,
        black,
        white,
        count,
    }
    private float brushScale = 0.5f;
    private BrushColor brushColorType = BrushColor.black;
    private Color[] brushColor = new Color[(int)BrushColor.count] { Color.red, Color.green, Color.blue, new Color(255, 0, 255), Color.yellow, Color.gray, Color.black, Color.white };


    void Start()
    {
       
        texRender = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
        Clear(texRender);
        lastTime = Time.time;
    }

    Vector3 startPosition = Vector3.zero;
    Vector3 endPosition = Vector3.zero;



    void Update()
    {

        if (Input.GetMouseButton(0) && isDraw)
        //     if (Input.GetMouseButton(0))
        {
            OnMouseMove(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        }
        if (Input.GetMouseButtonUp(0) && isDraw)
        {
            OnMouseUp();
        }

        curTime = Time.time;
        if (curTime - lastTime >= 2)
        {
            Debug.Log("work");
            text.text = "";
            lastTime = curTime;
        }

        //计算缩放系数  
        m_fScaleWidth = (float)Screen.width / m_fScreenWidth;
        m_fScaleHeight = (float)Screen.height / m_fScreenHeight;
    }

    void OnMouseUp()
    {
        startPosition = Vector3.zero;
    }

    void OnMouseMove(Vector3 pos)
    {
        endPosition = new Vector3(pos.x * 2 - Screen.width, pos.y, 0);
        //   endPosition = pos;
        //	DrawBrush(texRender,(int)endPosition.x,(int)endPosition.y,brushTypeTexture,brushColor[(int)brushColorType],brushScale);

        if (startPosition.Equals(Vector3.zero))
        {
            startPosition = endPosition;
            return;
        }

        float distance = Vector3.Distance(startPosition, endPosition);
        if (distance > 1)
        {
            int d = (int)distance;
            for (int i = 0; i < d; i++)
            {
                float difx = endPosition.x - startPosition.x;
                float dify = endPosition.y - startPosition.y;
                float delta = (float)i / distance;
                DrawBrush(texRender, new Vector2(startPosition.x + (difx * delta), startPosition.y + (dify * delta)), brushTypeTexture, brushColor[(int)brushColorType], brushScale);
            }
        }
        startPosition = endPosition;
    }

    void Clear(RenderTexture destTexture)
    {
        Graphics.SetRenderTarget(destTexture);
        GL.PushMatrix();
        GL.Clear(true, true, Color.white);
        GL.PopMatrix();
    }

    void DrawBrush(RenderTexture destTexture, Vector2 pos, Texture sourceTexture, Color color, float scale)
    {
        DrawBrush(destTexture, (int)pos.x, (int)pos.y, sourceTexture, color, scale);
    }

    void DrawBrush(RenderTexture destTexture, int x, int y, Texture sourceTexture, Color color, float scale)
    {
        DrawBrush(destTexture, new Rect(x, y, sourceTexture.width, sourceTexture.height), sourceTexture, color, scale);
    }

    void DrawBrush(RenderTexture destTexture, Rect destRect, Texture sourceTexture, Color color, float scale)
    {
        float left = destRect.left - destRect.width * scale / 2.0f;
        float right = destRect.left + destRect.width * scale / 2.0f;
        float top = destRect.top - destRect.height * scale / 2.0f;
        float bottom = destRect.top + destRect.height * scale / 2.0f;

        Graphics.SetRenderTarget(destTexture);

        GL.PushMatrix();
        GL.LoadOrtho();

        mat.SetTexture("_MainTex", brushTypeTexture);
        mat.SetColor("_Color", color);
        mat.SetPass(0);

        GL.Begin(GL.QUADS);

        GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(left / Screen.width, top / Screen.height, 0);
        GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(right / Screen.width, top / Screen.height, 0);
        GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(right / Screen.width, bottom / Screen.height, 0);
        GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(left / Screen.width, bottom / Screen.height, 0);

        GL.End();
        GL.PopMatrix();
    }

    bool bshow = false;
    void OnGUI()
    {
        GUIStyle gUIStyle = new GUIStyle();
      //  gUIStyle.fontSize = 25;
    //    gUIStyle.normal.textColor = Color.black;

        if (bshow)
        {
            //GUI.DrawTexture(new Rect(Screen.width/2, Screen.height * 0.07f, Screen.width/2,Screen.height*0.9f),texRender,ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height), texRender, ScaleMode.StretchToFill);

            //点击save截图
            if (GUI.Button(new Rect(660 * m_fScaleWidth, 750 * m_fScaleHeight, 90* m_fScaleWidth, 40* m_fScaleHeight), "Save"))
            {
                rect = new Rect(Screen.width * 0.51f, Screen.height * 0.07f, Screen.width * 0.49f, Screen.height * 0.88f);
                CaptureScreenshot2(rect);
                text.text = "Saved!";

            }

            if (GUI.Button(new Rect(100, 80, 100, 40), "clear"))
            {
                Clear(texRender);
            }

            int width = Screen.width / (int)BrushColor.count;

            for (int i = 0; i < (int)BrushColor.count; i++)
            {
                if (GUI.Button(new Rect(i * width, 0, width, 30), Enum.GetName(typeof(BrushColor), i)))
                {
                    brushColorType = (BrushColor)i;
                }
            }

            GUI.Label(new Rect(0, 130, 300, 30), "brushScale : " + brushScale.ToString("F2"));
            brushScale = (int)GUI.HorizontalSlider(new Rect(120, 135, 200, 30), brushScale * 10.0f, 1, 50) / 10.0f;
            if (brushScale < 0.1f)
                brushScale = 0.1f;
        }

       

        if (GUI.Button(new Rect(0, 80, 100, 40), "Draw"))
        {
            bshow = !bshow;
            isDraw = !isDraw;
            ga.SetActive(true);
        }

        

        
    }

    //截图
    Texture2D CaptureScreenshot2(Rect rect)
    {
        //获取系统时间并命名相片名  
        System.DateTime now = System.DateTime.Now;
        string times = now.ToString();
        times = times.Trim();
        times = times.Replace("/", "-");
        string filename = "Screenshot" + times + ".png";
        //判断是否为Android平台  
        if (Application.platform == RuntimePlatform.Android)
        {
            // 先创建一个的空纹理，大小可根据实现需要来设置   
            Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);

            // 读取屏幕像素信息并存储为纹理数据，   
            screenShot.ReadPixels(rect, 0, 0);
            screenShot.Apply();

            // 然后将这些纹理数据，成一个png图片文件   
            byte[] bytes = screenShot.EncodeToPNG();
            string destination = "/sdcard/DCIM/ARphoto";
            //判断目录是否存在，不存在则会创建目录  
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);

            }
            Path_save = destination + "/" + filename;
            //存图片  
            Debug.Log("路径：" + Path_save);
            System.IO.File.WriteAllBytes(Path_save, bytes);

            //在这里要去刷新一下，不然相册显示不出来

            AndroidJavaClass obj = new AndroidJavaClass("com.ryanwebb.androidscreenshot.MainActivity");
            obj.CallStatic<bool>("scanMedia", Path_save);
        }
        return screenShot;



    }

   
}