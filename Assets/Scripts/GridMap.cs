using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    private int[,] map;
    public uint row;
    public uint col;
    public Point point;
    List<Point> list;

    void Start()
    {
        list = new List<Point>();
    }

    public void GenerateMap()
    {
        map = new int[row, col];
        for (uint i = 0; i < map.GetLength(0); i++)
        {
            for (uint j = 0; j < map.GetLength(1); j++)
            {
                Point obj = Instantiate<Point>(point);
                obj.x = i;
                obj.y = j;
                list.Add(obj);
            }
        }
    }

    public List<Point> GetList()
    {
        return list;
    }

    public Point GetPoint(uint a, uint b)
    {
        if (a>=row||b>=col)
        {
            return null;
        }
        foreach (var item in list)
        {
            if (item.x==a&&item.y==b)
            {
                return item;
            }
        }
        return null;
    }

    //public void GetPointsNearby(uint x, uint y, List<Point> openList, List<Point> closeList)
    //{
    //    for (uint i = (0 == x ? x : x - 1); i <= x+1; i++)
    //    {
    //        for (uint j = (0 == y ? y : y - 1); j <= y+1; j++)
    //        {
    //            if (i!=x||j!=y)
    //            {
    //                Point p = GetPoint(i, j);
    //                if (null != p && -1 != p.value && !openList.Contains(p) && !closeList.Contains(p))
    //                {
    //                    openList.Add(p);
    //                }
    //            }
    //        }
    //    }
    //}

    public void GetPointsNearby(Point point,List<Point> openList, List<Point> closeList)
    {
        if (null==point)
        {
            return;
        }
        //GetPointsNearby(point.x, point.y, openList, closeList);
        uint x = point.x;
        uint y = point.y;
        for (uint i = (0 == x ? x : x - 1); i <= x + 1; i++)
        {
            for (uint j = (0 == y ? y : y - 1); j <= y + 1; j++)
            {
                if (i != x || j != y)
                {
                    Point p = GetPoint(i, j);
                    if (null != p && -1 != p.value && !openList.Contains(p) && !closeList.Contains(p))
                    {
                        p.parent = point;
                        openList.Add(p);
                    }
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
