﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBlock : MonoBehaviour {

    public string PoolName;
    private ObjectPoolManager obstaclePoolScript;
    private HUDManager hudScript;
    private SpriteRenderer spriteComp;
    private SpeedManager speedScript;
    private int curHealth;
    private int curScoreValue;
    public float obstacleSpeed = 2;
    public string currentColor_text;
    private Vector3 position;
    public bool isObstacle;

    private void Awake()
    {
        speedScript = FindObjectOfType<SpeedManager>();
        obstacleSpeed = speedScript.GetSpeed();
        hudScript = FindObjectOfType<HUDManager>();
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
                    curScoreValue = 2;
                    curHealth = 1;
                }
                break;
            case 1:
                if (spriteComp)
                {
                    currentColor_text = "Blue";
                    spriteComp.color = Color.blue;
                    curScoreValue = 1;
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
        if(col.CompareTag("Bullet") && isObstacle)
        {
            col.gameObject.GetComponent<BulletMovement>().BlowUp(transform.position);
            curHealth--;
            if(curHealth<=0)
            {
                obstaclePoolScript.PutBackObject(PoolName,gameObject);
                hudScript.IncrementScoreText(curScoreValue);
            }
        }
    }
}
