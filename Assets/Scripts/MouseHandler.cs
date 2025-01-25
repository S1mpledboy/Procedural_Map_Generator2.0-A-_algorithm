using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    PathNode startNode;
    PathNode endNode;
    [SerializeField]Vector2Int startPosition,endPosition;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        { 
            startNode = A.FindPathNode(startPosition.x, startPosition.y);
            endNode = A.FindPathNode(endPosition.x, endPosition.y);

        }

        if (Input.GetKeyDown(KeyCode.H) && startNode != null && endNode != null)
        {
          List<PathNode> path =  A.FindPath(startNode.x, startNode.y, endNode.x, endNode.y);
            foreach(PathNode node in path)
            {
                Debug.Log(node);
                MapGenerator.CreateTile(node.x, node.y);
            }
        }
    }
 
}
