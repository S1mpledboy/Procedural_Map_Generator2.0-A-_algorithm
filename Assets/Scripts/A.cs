using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class A : MonoBehaviour
{
    static List<PathNode> openList;
    static List<PathNode> closedList;

    public static List<PathNode> FindPath(int startX, int startY, int endX, int endY)
    {
        PathNode startNode = FindPathNode(startX, startY);
        PathNode endNode = FindPathNode(endX, endY);
        openList = new List<PathNode> { startNode };
        closedList = new List<PathNode>();
        while(openList.Count > 0)
        {
            PathNode currentNode = openList[0];
            for(int i= 0; i < openList.Count; i++)
            {
                if (openList[i].fCost < currentNode.fCost && openList[i].hCost < currentNode.hCost)
                {
                    currentNode = openList[i];
                }
            }
            openList.Remove(currentNode);
            closedList.Add(currentNode);
            if(currentNode == endNode)
            {
                return Retrace(startNode,endNode);
            }
            foreach(PathNode neighbour in MapGenerator.GetNeighbours(currentNode))
            {
                if (closedList.Contains(neighbour))
                {
                    continue;
                }
                int newMovementCostToNeighbour = currentNode.gCost + CalculateDistanceCost(currentNode, neighbour) + neighbour.weigth;
                if(newMovementCostToNeighbour < neighbour.gCost||!openList.Contains(neighbour))
                {
                    neighbour.gCost = newMovementCostToNeighbour;
                    neighbour.hCost = CalculateDistanceCost(neighbour, endNode);
                    neighbour.cameFromNode = currentNode;
                    if (!openList.Contains(neighbour))
                    {
                        openList.Add(neighbour);
                    }
                }
            }
        }
        return null;
    }
    static List<PathNode> Retrace(PathNode startNode, PathNode endNode) 
    {
        List<PathNode> path = new List<PathNode>();
        PathNode currentNode = endNode;
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.cameFromNode;
        }
        path.Reverse();
        return path;
    }
    static int CalculateDistanceCost(PathNode a, PathNode b)
    {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        if (xDistance > yDistance)
        {
            return  yDistance +  (xDistance - yDistance);
        }
        return  xDistance +  (yDistance - xDistance);
    }
    public static PathNode FindPathNode(int x,int y)
    {
        foreach(PathNode node in MapGenerator.nodes)
        {

            if (node.x == x && node.y == y)
            {
                return node;
            }
        }
        return null;
    }

}
