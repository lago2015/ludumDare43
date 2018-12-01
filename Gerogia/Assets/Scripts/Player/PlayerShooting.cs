using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    private BulletMovement curBulletScript;
    public ObjectPool poolScript;
    private GameObject curBullet;
    public GameObject bulletSpawnPoint;
    public PlayerHealthBullets healthScipt;
    private int curBullets;

    private void Awake()
    {
        healthScipt.ReplenishBullets();
    }

    private void Update()
    {
        //input for shooting
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(healthScipt.IsThereBulletsLeft())
            {
                //gets bullet from pool
                curBullet = poolScript.GetObject();
                if (curBullet)
                {
                    //places bullet in world
                    poolScript.PlaceBullet(curBullet, bulletSpawnPoint.transform.position);
                    curBulletScript = curBullet.GetComponent<BulletMovement>();
                    curBulletScript.SetPool(poolScript);
                    curBullet.SetActive(true);
                    curBulletScript.ResetCoroutine();
                    healthScipt.DecrementBullets();
                }
            }
        }
    }
}
