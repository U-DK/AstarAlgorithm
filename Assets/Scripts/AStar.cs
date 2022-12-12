using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{

    public GridMap map;
    List<Point> openList;
    List<Point> closeList;
    Coroutine coroutine;
    Point startPoint;
    Point endPoint;
    Point current;


    //public Transform parent;
    //public Point point;

    void Start()
    {
        openList = new List<Point>();
        closeList = new List<Point>();

    }

    public void Generate()
    {
        Debug.LogError("generate!");
        map.GenerateMap();
        List<Point> points = map.GetList();
        for (int i = 0; i < points.Count; i++)
        {
            points[i].gameObject.SetActive(true);
            points[i].SetTransform(transform);
        }
        startPoint = map.GetPoint(0, 0);
        endPoint = map.GetPoint(map.row-1, map.col-1);
        startPoint.SetStartOrEnd(true);
        endPoint.SetStartOrEnd(false);
        Global.isGenerated = true;
    }

    public void LetTheGameBegin()
    {


        current = startPoint;
        current.SetCurrent();
        //map.GetPointsNearby(0, 0, openList, closeList);
        //foreach (var item in openList)
        //{
        //    item.SetStatus(true);
        //    item.parent = current;
        //    item.Calculate(startPoint,endPoint);
        //}
        //Debug.LogError("openlist count: " + openList.Count);
        //closeList.Add(current);
        //current = ChooseLeastF();
        //openList.Remove(current);

        StartCoroutine("TracingPath");



    }



    IEnumerator TracingPath()
    {

        while (true)
        {
            map.GetPointsNearby(current, openList, closeList);
            foreach (var item in openList)
            {
                item.SetStatus(true);
                //item.parent = current;
                item.Calculate(current, endPoint);
            }
            yield return new WaitForSeconds(0.5f);

            closeList.Add(current);
            if (current == endPoint || 0 == openList.Count)
            {
                StartCoroutine("ShowPath");
                break;
            }
            
            current = ChooseLeastF();
            openList.Remove(current);
            current.SetCurrent();
            //Debug.LogError("openlist count: " + closeList.Count);
            //Debug.LogError("openlist count: " + openList.Count);
            yield return new WaitForSeconds(0.5f);

        }

    }

    IEnumerator ShowPath()
    {
        if (current!=endPoint)
        {
            current = null;
            Debug.LogError("No path found");
            Global.globalInstance.uicontrol.SetText("No path found");
            //endPoint.SetStartOrEnd(false);
            StopAllCoroutines();
            yield return null;
        }
        Debug.LogError("Path found");
        Global.globalInstance.uicontrol.SetText("Path found");
        while (current!=null)
        {
            current.SetPath();
            current = current.parent;
            yield return new WaitForSeconds(.5f);
        }
    }



    void Update()
    {
        
    }

    Point ChooseLeastF()
    {
        Point point = null;
        int f = int.MaxValue;
        foreach (var item in openList)
        {
            if (item.F<f)
            {
                point = item;
                f = item.F;
            }
        }
        point.SetStatus(false);
        return point;
        
    }
}
