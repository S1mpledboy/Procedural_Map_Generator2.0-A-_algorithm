using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGenerator : MonoBehaviour
{
    Dictionary<int, GameObject> _tileset;
    [SerializeField] GameObject _parent, _forest, _city, _groundMountain, _ground, _road, _see, _hill;
    [SerializeField] int _width, _hiegth;
    public static int Width, Heigth;
    public static GameObject Road, Parent;
     [SerializeField] int xOffset, yOffset;
    List<List<GameObject>> _tileGrid = new List<List<GameObject>>();
    public static List<PathNode> nodes = new List<PathNode>();
    [SerializeField] float magnifcation = 7f;
    
    // Start is called before the first frame update
    void Start()
    {
        Width = _width;
        Heigth = _hiegth;
        Road = _road;
        Parent = _parent;
        CreateTleset();
        GenerateMap();
    }

    void CreateTleset()
    {
        _tileset = new Dictionary<int, GameObject>();
        _tileset.Add(0, _city);
        _tileset.Add(1, _ground);
        _tileset.Add(2, _forest);
        _tileset.Add(3, _hill);
        _tileset.Add(4, _groundMountain);

    }
    public static List<PathNode> GetNeighbours(PathNode startNode)
    {
        List<PathNode> neighbours = new List<PathNode>();
        PathNode currentNode = A.FindPathNode(startNode.x, startNode.y - 1);
        if (currentNode != null)
        {
            neighbours.Add(currentNode);
        }
        currentNode = A.FindPathNode(startNode.x - 1, startNode.y);
        if (currentNode != null)
        {
            neighbours.Add(currentNode);
        }
        currentNode = A.FindPathNode(startNode.x + 1, startNode.y);
        if (currentNode != null)
        {
            neighbours.Add(currentNode);
        }
        currentNode = A.FindPathNode(startNode.x, startNode.y + 1);
        if(currentNode!= null)
        {
            neighbours.Add(currentNode);
        }
        
        return neighbours;
    }
    void GenerateMap()
    {
        for(int x = 0; x < _width; x++)
        {
            _tileGrid.Add(new List<GameObject>());
            for(int y = 0; y < _hiegth; y++)
            {
                int tileID = GetIDbyPerlin(x,y);
                CreateTile(tileID, x, y);
                nodes.Add(new PathNode(x, y, (tileID+1)*(tileID+1)));
            }
        }
    }
    public static void CreateTile(int x, int y)
    {
        GameObject tile = Instantiate(Road, Parent.transform);
        tile.transform.localPosition = new Vector3(x, y, 0);

    }
    public void GenerateRandomOffset()
    {
        xOffset = Random.Range(0, 99999);
        yOffset = Random.Range(0, 99999);
    }
    void CreateTile(int tileId ,int x,int y)
    {
        GameObject tilePrefab = _tileset[tileId];
        GameObject tile = Instantiate(tilePrefab, _parent.transform);
        tile.transform.localPosition = new Vector3(x, y, 0);
        _tileGrid[x].Add(tile);
    }
    int GetIDbyPerlin(int x, int y)
    {
        float noiseValue = Mathf.PerlinNoise(
                            (x - xOffset) / magnifcation, 
                            (y - yOffset) / magnifcation
                            );
        float clampedPerlin = Mathf.Clamp01(noiseValue);
        float scalePerlin = clampedPerlin * _tileset.Count;
        if(scalePerlin >= 5)
        {
            scalePerlin = 4;
        }
        return Mathf.FloorToInt(scalePerlin);
    }
    
}
