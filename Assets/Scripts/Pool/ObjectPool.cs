using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    private SpeedManager obstacleSpeedScript;
    private float curSpeed;
    public GameObject prefab;
    //public int size;
    public ObstacleManager obstacleManager;
    List<GameObject> objectList;
    List<GameObject> activeList;
    private ObstacleBlock curObstacleController;
    private MoveObject curMovableObstacle;

    public int PoolSize()
    {
        return activeList.Count;
    }

    // Use this for initialization
    void Awake()
    {
        obstacleSpeedScript = FindObjectOfType<SpeedManager>();
        if (obstacleSpeedScript)
        {
            curSpeed = obstacleSpeedScript.GetSpeed();
        }
    }

    public void InitializeList(GameObject obj,int size)
    {
        // Create new Game objext list
        objectList = new List<GameObject>();
        activeList = new List<GameObject>();
        prefab = obj;
        // Spawn in Game Objects to pool and add to the object list
        for (int i = 0; i < size; i++)
        {
            GameObject gameObj = Instantiate(obj, transform.position, Quaternion.identity) as GameObject;
            
            gameObj.transform.SetParent(gameObject.transform);
            gameObj.transform.parent = gameObject.transform;
            curObstacleController = gameObj.GetComponent<ObstacleBlock>();
            if (curObstacleController)
            {
                curObstacleController.AdjustSpeed(curSpeed);
            }

            gameObj.SetActive(false);

            objectList.Add(gameObj);
        }

    }

    public GameObject GetObject()
    {


        // Check if there are any Game Objects in list
        if (objectList.Count > 0)
        {
            // go to first object in list and remove it
            GameObject gameObj = objectList[0];
            objectList.RemoveAt(0);
            activeList.Add(gameObj);
            //getting the right obstacle movement script
            curObstacleController = gameObj.GetComponent<ObstacleBlock>();
            if (curObstacleController)
            {
                curObstacleController.AdjustSpeed(curSpeed);
            }
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
        if (obstacleSpeedScript)
        {
            curSpeed = obstacleSpeedScript.GetSpeed();
        }
        int activeSize = activeList.Count;
        GameObject curObject;
        for (int i = 0; i < activeSize; i++)
        {
            curObject = activeList[i].gameObject;

            curObstacleController = curObject.GetComponent<ObstacleBlock>();
            if (curObstacleController)
            {
                curObstacleController.AdjustSpeed(curSpeed);
            }
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
        activeList.Remove(removeObstacle);
        // Retun object back to the pool and reset its properties
        objectList.Add(removeObstacle);
        removeObstacle.transform.SetParent(gameObject.transform);
        removeObstacle.transform.position = transform.position;
        removeObstacle.SetActive(false);
    }



    public void PlaceObject(GameObject gameObj)
    {
        // Add object back to list and remove it back to pools location
        objectList.Add(gameObj);
        gameObj.transform.position = transform.position;

    }
}
