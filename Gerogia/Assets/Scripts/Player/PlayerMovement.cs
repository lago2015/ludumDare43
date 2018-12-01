using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 2.0f;      //speed to travel 
    private Vector3 curPosition;       

    
    void Update()
    {
        //player going down
        if (Input.GetKey(KeyCode.S))
        {
            curPosition = transform.position;
            curPosition.y -= speed * Time.deltaTime;
            transform.position = curPosition;
        }
        //player going up
        else if(Input.GetKey(KeyCode.W))
        {
            curPosition = transform.position;
            curPosition.y += speed * Time.deltaTime;
            transform.position = curPosition;
        }

    }
}
