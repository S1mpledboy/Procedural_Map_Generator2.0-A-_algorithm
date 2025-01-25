using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    public int x, y, weigth;
    public int gCost, hCost, fCost;
    public PathNode cameFromNode;
    public PathNode(int x, int y, int weigth)
    {
        this.x = x;
        this.y = y;
        this.weigth = weigth;
    }
    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }
    public override string ToString()
    {
        return x + "," + y;
    }
}
