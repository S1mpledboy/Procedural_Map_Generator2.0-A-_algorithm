using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityHandler : MonoBehaviour
{
    private void OnMouseDown()
    {
        MouseHandler.SetStartEndNode((int)transform.position.x , (int)transform.position.y);
        print("x: "+(int)transform.position.x +"Y: "+ (int)transform.position.y);
    }


}
