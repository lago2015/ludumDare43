using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    //this script is use to move background elements in game
    private float defaultSpeed;
    public float obstacleSpeed = 2;
    Vector3 position;
    public bool isObstacle;
    private ObjectPoolManager poolScript;
    public string poolName = "colliderPool";
    private Vector3 startPosition;
    private void Awake()
    {
        startPosition = transform.position;
        poolScript = FindObjectOfType<ObjectPoolManager>();
        defaultSpeed = obstacleSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        position = transform.position;
        position.x -= obstacleSpeed * Time.deltaTime;
        transform.position = position;
    }
    public void AdjustSpeed(float newSpeed)
    {
        if (newSpeed == 0)
        {
            transform.position = startPosition;
            obstacleSpeed = newSpeed;
        }
        else
        {
            obstacleSpeed = defaultSpeed;
        }

    }

    public void ReturnObjectToPool()
    {
        poolScript.PutBackObject(poolName, gameObject);
    }

}
