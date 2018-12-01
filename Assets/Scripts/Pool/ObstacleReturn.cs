using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleReturn : MonoBehaviour {

    private ObjectPoolManager poolScript;
    public string blockCellName = "blockPool";
    public string bulletName = "bulletPool";
    public string colliderName = "colliderPool";
    public string explosionName = "explosionPool";

    private void Awake()
    {
        poolScript = FindObjectOfType<ObjectPoolManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Obstacle"))
        {
            poolScript.PutBackObject(blockCellName, col.gameObject);
        }
        else if(col.CompareTag("PillarDodged"))
        {
            poolScript.PutBackObject(colliderName, col.gameObject);
        }
        else if(col.name.Contains("Explosion"))
        {
            poolScript.PutBackObject(explosionName, col.gameObject);
        }
        else if(col.CompareTag("PickUp"))
        {
            Destroy(col.gameObject);
        }

    }
}
