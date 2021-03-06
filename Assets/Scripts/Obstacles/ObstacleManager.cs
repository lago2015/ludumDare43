﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

    //Components

    //Static instance of obstacle manager which allows it to be accessed by any other script.
    public static ObstacleManager instance = null;
    private ObjectPoolManager poolManager;
    private string obstaclePoolName = "blockPool";
    private string bloodinatorName = "bloodinatorPool";
    //private string pillarDodgePoolName = "colliderPool";
    public GameObject[] pickupArray;
    public GameObject[] spawnPoints;
    public GameObject bloodinatorSpawnPoint;
    private PlayerCollision playerCollisionScript;
    private ObstacleBlock obstacleController;
    private GameObject curObstacle;
    private GameObject curCollider;
    public bool fastMode;
    //color generation variables
    private SpeedManager speedScript;
    private int randomIndex;
    private int curColorPlacement;
    
    private int curSecondaryColorPlace;

    public float minSpawnCooldown = 3;
    public float maxSpawnCooldown = 6;
    private float spawnCooldown;
    private float pillarSpawnCooldown;
    //pick up variables
    private bool pickUpAvailable;
    private float pickUpRate;
    private int pickUpIndex;
    public int pickUpMinRate = 10;
    public int pickUpMaxRate = 20;
    //color nums
    private int blueNum=4;
    private int redNum=2;
    
    private GameObject curPoint;
    System.Random _random;
    private bool isObstacle;

    public bool TurnOnFastMode(bool isFast)
    {
        return fastMode = isFast;
    }

    private void Awake()
    {
        speedScript = GetComponent<SpeedManager>();
        poolManager = GetComponent<ObjectPoolManager>();
        GetPlayer();
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        _random = new System.Random();
        RandomizeSpawnPoints();
    }

    //Shuffles spawnpoints in array
    void RandomizeSpawnPoints()
    {

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            randomIndex = i + (int)(_random.NextDouble() * (spawnPoints.Length - i));
            curPoint = spawnPoints[randomIndex];
            spawnPoints[randomIndex] = spawnPoints[i];
            spawnPoints[i] = curPoint;
        }
    }

    public void GetPlayer()
    {
        if (playerCollisionScript == null)
            playerCollisionScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
    }

    

    public void NewGameObstacles()
    {
        StopAllCoroutines();
        SpawnObstacles();
        SpawnPickup();
    }
    
    public void SpawnObstacles()
    {
        //randomize what obstacle to spawn
        randomIndex = Random.Range(0, 10);
        if(randomIndex<8)
        {
            //spawn pillar of color
            for (int i = 1; i <= spawnPoints.Length; i++)
            {
                //get current obstacle
                curObstacle = poolManager.FindObject(obstaclePoolName);
                obstacleController = curObstacle.GetComponent<ObstacleBlock>();
                if (curObstacle)
                {
                    if (i <= redNum)
                    {

                        //place obstacle at spawn point
                        curObstacle.transform.position = spawnPoints[i - 1].transform.position;
                        //swap color on obstacle
                        obstacleController.SwapInColor(0);
                        //set obstacle active
                        curObstacle.SetActive(true);
                    }
                    else if (i <= redNum + blueNum)
                    {
                        //place obstacle at spawn point
                        curObstacle.transform.position = spawnPoints[i - 1].transform.position;
                        //swap color on obstacle
                        obstacleController.SwapInColor(1);
                        //set obstacle active
                        curObstacle.SetActive(true);
                    }
                }
            }
            
        }
        else
        {
            curObstacle = poolManager.FindObject(bloodinatorName);
            curObstacle.GetComponent<SinWaveMovement>().xSpeed = speedScript.GetSpeed();
            curObstacle.transform.position = bloodinatorSpawnPoint.transform.position;
            curObstacle.SetActive(true);
            
        }

        //randomize cooldown to vary up distance between pillars
        spawnCooldown = Random.Range(minSpawnCooldown, maxSpawnCooldown);
        //shuffle the spawn points for next iteration for a pillar spawn
        RandomizeSpawnPoints();
        
        
        if (pickUpAvailable)
        {
            StartCoroutine(WaitToSpawnNextPickup());
        }
        StartCoroutine(WaitForNextPillar());
    }

    public void SpawnPickup()
    {
        if (pickupArray.Length > 0)
        {
            pickUpRate = Random.Range(pickUpMinRate, pickUpMaxRate);
            pickUpIndex = 0;
            StartCoroutine(CountdownToNextPickUp());
        }
    }

    IEnumerator CountdownToNextPickUp()
    {
        yield return new WaitForSeconds(pickUpRate);
        pickUpAvailable = true;
    }

    IEnumerator WaitToSpawnNextPickup()
    {
        yield return new WaitForSeconds(spawnCooldown / 2);

        Instantiate(pickupArray[pickUpIndex],
                    spawnPoints[Random.Range(0, spawnPoints.Length - 1)].transform.position,
                    Quaternion.identity);
        pickUpAvailable = false;
        SpawnPickup();
    }

    IEnumerator WaitForNextPillar()
    {
        yield return new WaitForSeconds(spawnCooldown);
        

        SpawnObstacles();
    }

    public void StopEnums()
    {
        StopAllCoroutines();

    }

}
