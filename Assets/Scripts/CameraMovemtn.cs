using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovemtn : MonoBehaviour
{
    public float moveSpeed = 10f; 
    public float scrollSpeed = 500f; 
   
    void Update()
    {

        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        Vector3 movement = new Vector3(horizontal, vertical,0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
