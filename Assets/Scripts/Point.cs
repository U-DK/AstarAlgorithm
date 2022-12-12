using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public uint x=0;
    public uint y=0;
    public int value=0;
    public int G=0;
    public int H=0;
    public Point parent;
    public TextMesh tm;
    Material mat;
    bool isStart = false;
    bool isEnd = false;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
        parent = null;

    }

    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (Global.isInEditMode)
        {
            //Debug.LogError("this is cube");

            ChangeStatus();
        }
    }

    void ChangeStatus()
    {
        if (isStart || isEnd)
        {
            return;
        }
        if (0==value)
        {
            mat.color = Color.red;
            value = -1;
            return;
        }
        mat.color = Color.white;
        value = 0;

    }

    public void SetStatus(bool check)
    {
        if (isStart || isEnd)
        {
            return;
        }
        mat.color = check ? Color.blue : Color.white;
    }

    public void SetPath()
    {
        if (isStart || isEnd)
        {
            return;
        }
        mat.color = Color.green;
    }

    public void SetStartOrEnd(bool start)
    {
        mat.color = start ? Color.cyan : Color.yellow;
        isStart = start;
        isEnd = !start;

    }

    public void SetCurrent()
    {
        if (isStart||isEnd)
        {
            return;
        }
        mat.color = Color.magenta;
    }

    public void Calculate(Point from, Point end)
    {

        
        long gapFromX = (x>from.x?(x-from.x):(from.x-x));
        long gapFromY = (y > from.y ? (y - from.y) : (from.y - y));
        if (gapFromX > 1 || gapFromY > 1)
        {
            return;
        }
        if (H <= 0)
        {
            long gapTo = end.x - x + end.y - y;
            H = (int)gapTo * 10;
        }
        int temp = from.G;
        if (gapFromX == 1 && gapFromY == 1)
        {
            temp += 14;
            
        }
        if ((gapFromX == 0 && gapFromY == 1)|| (gapFromX == 1 && gapFromY == 0))
        {
            temp += 10;
        }

        if (temp<G||0==G)
        {
            G = temp;
            parent = from;
        }

        F = 0;
    }


    public int F
    {
        get
        {
            return G + H;
        }
        set
        {
            tm.text = F.ToString();
        }
        
    }

    public void SetTransform(Transform parent)
    {
        transform.parent = parent;
        transform.position = new Vector3(x+((float)x/20), 0, y+ ((float)y / 20));
        
    }

    void Update()
    {
        
    }
}
