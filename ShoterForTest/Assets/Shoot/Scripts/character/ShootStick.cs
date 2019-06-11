using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ShootStick : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public Image joyStick;
    public Vector2 startpos;
    public Vector2 tek_pos;
    public int test;
    public bool Get;
    public Vector3 max_p;
    public bool ONDown;
    public TouchStick ts;
    private bool sel;
    // Use this for initialization
    void Start()
    {

        tek_pos = startpos;
        max_p.x = Screen.width * 0.82f;
        max_p.y = Screen.height / 6;
        startpos.x = 0;
        startpos.y = 0;

    }

    // Update is called once per frame
    void Update()
    {
        startpos.x = Screen.width*0.82f;
        startpos.y = Screen.height /6;
        max_p.x = Screen.width;
        max_p.y = Screen.height/3;
        if (sel)
        {
            IsSelect();
        }
        if (ONDown)
        {
            Touch[] myTouches = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {
                
                tek_pos = Input.touches[i].position;
                Debug.Log(startpos.x - (max_p.x - startpos.x));
            if (new Rect(startpos.x - (max_p.x - startpos.x), 0, max_p.x, max_p.y).Contains(tek_pos))
            {
                    if (Input.touchCount <= 1)
                    {
                        ts.Get = false;
                    }
                Get = true;

            }
            else
            {
                    if (Input.touchCount <= 1)
                    {
                        ts.Get = false;
                    }
                    if (!Get)
                {
                    horizontal = 0;
                    vertical = 0;
                    tek_pos = startpos;
                }
            }
        }
        }
        else
        {
            horizontal = 0;
            vertical = 0;
            tek_pos = startpos;

            Get = false;
        }
        tek_pos.x = Mathf.Clamp(tek_pos.x, startpos.x - (max_p.x - startpos.x), max_p.x);
        tek_pos.y = Mathf.Clamp(tek_pos.y, 0, max_p.y);

        joyStick.rectTransform.position = tek_pos;
        if (Get)
        {
            //horizontal = ((tek_pos.x)/max_p.x )-0.5f;
          float    h = ((tek_pos.x / max_p.x) - (startpos.x / max_p.x));
            if (h < 0)
            {
                horizontal = h*2 ;
            }
            else
            {
                horizontal = h *2;
            }
            vertical = (tek_pos.y / max_p.y) - 0.5f;
        }
        //horizontal = (tek_pos.x - Screen.width/6) /150;
        //vertical = (tek_pos.y - Screen.height/6) / 70;

    }
    public void Evns()
    {
       
        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            ONDown = true;
        }
    }
    public void Selected()
    {
      
        sel = true;
        
    }
    public void IsSelect()
    {
        Debug.Log("Selected");
        if (Input.touchCount <= 1)
        {
            ts.Get = false;
        }
    }
    public void Unselect()
    {
        sel = false;
    }
    public void Closes()
    {
        ONDown = false;
    }

}
