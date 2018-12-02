﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBlock : MonoBehaviour {

    public string PoolName;
    private ObjectPoolManager obstaclePoolScript;
    private SpriteRenderer spriteComp;
    private int curHealth;
    public float obstacleSpeed = 2;
    public string currentColor_text;
    private Vector3 position;
    private void Awake()
    {
        obstaclePoolScript = GameObject.FindGameObjectWithTag("ObstaclePool").GetComponent<ObjectPoolManager>();
        spriteComp = GetComponent<SpriteRenderer>();
        curHealth = 2;
    }

    private void FixedUpdate()
    {
        position = transform.position;
        position.x -= obstacleSpeed * Time.deltaTime;
        transform.position = position;
    }

    public void SwapInColor(int colorIndex)
    {
        
        switch (colorIndex)
        {
            //red
            case 0:
                if(spriteComp)
                {
                    currentColor_text = "Red";
                    spriteComp.color = Color.red;
                    curHealth = 1;
                }
                break;
            case 1:
                if (spriteComp)
                {
                    currentColor_text = "Blue";
                    spriteComp.color = Color.blue;
                    curHealth = 2;
                }

                break;
        }
        
    }

    public void AdjustSpeed(float newSpeed)
    {
        obstacleSpeed = newSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Bullet"))
        {
            col.gameObject.GetComponent<BulletMovement>().BlowUp(transform.position);
            curHealth--;
            if(curHealth<=0)
            {
                obstaclePoolScript.PutBackObject(PoolName,gameObject);
                
            }
        }
    }
}