using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    //private SpeedManager obstacleSpeedScript;
    private float curSpeed;
    public GameObject prefab;
    public int size;
    //public ObstacleManager obstacleManager;
    List<GameObject> objectList;
    List<GameObject> activeList;
    //private ObstacleController curObstacleController;
    
    // Use this for initialization
    void Awake()
    {
        
        // Initializes the List of Game Objects
        InitializeList();
    }

    void InitializeList()
    {
        // Create new Game objext list
        objectList = new List<GameObject>();
        activeList = new List<GameObject>();
        // Spawn in Game Objects to pool and add to the object list
        for (int i = 0; i < size; i++)
        {
            GameObject gameObj = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;

            gameObj.transform.parent = gameObject.transform;
            
            gameObj.SetActive(false);

            objectList.Add(gameObj);
        }

    }

    public GameObject GetObject()
    {

        //curSpeed = obstacleSpeedScript.GetSpeed();
        // Check if there are any Game Objects in list
        if (objectList.Count > 0)
        {
            // go to first object in list and remove it
            GameObject gameObj = objectList[0];
            objectList.RemoveAt(0);
            activeList.Add(gameObj);
            //getting the right obstacle movement script
            //curObstacleController = gameObj.GetComponent<ObstacleController>();
            //if (curObstacleController)
            //{
            //    curObstacleController.AdjustSpeed(curSpeed);
            //}
            // Return Game Object to specifc manager
            return gameObj;
        }
        else
        {
            // If there is no object currently in list, spawn a new object in to increase the list
            GameObject gameObj = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
            activeList.Add(gameObj);
            // Return the spawned in object to specifc manager
            return gameObj;
        }
    }

    public void AdjustActiveObstacles()
    {
        //if (obstacleSpeedScript)
        //{
        //    curSpeed = obstacleSpeedScript.GetSpeed();
        //}
        int activeSize = activeList.Count;
        GameObject curObject;
        for (int i = 0; i < activeSize; i++)
        {
            curObject = activeList[i].gameObject;

            //curObstacleController = curObject.GetComponent<ObstacleController>();
            //if (curObstacleController)
            //{
            //    curObstacleController.AdjustSpeed(curSpeed);
            //}
            
        }
    }

    public void ReturnAllObjects()
    {
        int activeSize = activeList.Count;
        for (int i = 0; i < activeSize; i++)
        {
            GameObject curObject = activeList[0];
            activeList.RemoveAt(0);
            objectList.Add(curObject);
            curObject.SetActive(false);
        }
    }

    public void ReturnCurObstacle(GameObject removeObstacle)
    {
        GameObject curObject = activeList[0];
        activeList.RemoveAt(0);
        objectList.Add(curObject);
        curObject.SetActive(false);
    }
    //called for block generation
    public void PlaceObject(GameObject gameObj)
    {
        // Add object back to list and remove it back to pools location
        objectList.Add(gameObj);
        gameObj.transform.position = transform.position;

    }
    //called from player shooting script
    public void PlaceBullet(GameObject curBullet,Vector3 curPosition)
    {
        // Add object back to list and remove it back to pools location
        objectList.Add(curBullet);
        curBullet.transform.position = curPosition;

    }
}
