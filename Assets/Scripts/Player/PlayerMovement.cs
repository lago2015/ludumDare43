using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float defaultSpeed;
    public float speed = 2.0f;      //speed to travel 
    private Vector3 curPosition;
    private bool isDead;

    private void Awake()
    {
        defaultSpeed = speed;
    }

    public void PlayerStatus(bool isPlayerDead)
    {
        if (isPlayerDead)
        {
            speed = 0;
        }
        else
        {
            speed = defaultSpeed;
        }
    }
    
    void Update()
    {
        
        //player going down
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            curPosition = transform.position;
            curPosition.y -= speed * Time.deltaTime;
            transform.position = curPosition;
        }
        //player going up
        else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            curPosition = transform.position;
            curPosition.y += speed * Time.deltaTime;
            transform.position = curPosition;
        }

    }
}
