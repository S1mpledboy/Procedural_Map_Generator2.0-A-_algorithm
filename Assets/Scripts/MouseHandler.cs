using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    static PathNode startNode, endNode;
    
   

   public static void SetStartEndNode(int x, int y)
    {
        if (startNode == null)
        {
            startNode = A.FindPathNode(x, y);

        }
        else if (endNode == null) 
        {
            endNode = A.FindPathNode(x, y); 
        }
        GeneratePath();
    }
    static void GeneratePath()
    {
        if (startNode != null && endNode != null)
        {
            
            List<PathNode> path = A.FindPath(startNode.x, startNode.y, endNode.x, endNode.y);
            foreach (PathNode node in path)
            {
                
                MapGenerator.CreateTile(node.x, node.y);
            }
            startNode = null;
            endNode = null;
        }
    }

 
}
