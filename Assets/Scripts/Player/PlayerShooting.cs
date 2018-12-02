using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {


    private HUDManager hudScript;
    private BulletMovement curBulletScript;
    public ObjectPoolManager poolScript;
    private GameObject curBullet;
    public GameObject bulletSpawnPoint;
    public PlayerHealthBullets healthScipt;
    private int curBullets;
    private bool isDead;

    public bool PlayerStatus(bool isPlayerDead)
    {
        if(!isPlayerDead)
        {
            healthScipt.ReplenishBullets();
            hudScript.AdjustBulletText();
        }
        
        return isDead = isPlayerDead;
    }

    private void Awake()
    {
        hudScript = FindObjectOfType<HUDManager>();
        healthScipt.ReplenishBullets();
        hudScript.AdjustBulletText();
    }

    private void Update()
    {
        //input for shooting
        if(Input.GetKeyDown(KeyCode.Space)&&!isDead)
        {
            if(healthScipt.IsThereBulletsLeft())
            {
                //gets bullet from pool
                curBullet = poolScript.FindObject("bulletPool");
                if (curBullet)
                {

                    //places bullet in world
                    curBullet.transform.position = bulletSpawnPoint.transform.position;
                    curBulletScript = curBullet.GetComponent<BulletMovement>();
                    curBulletScript.SetPool(poolScript);
                    curBullet.SetActive(true);
                    curBulletScript.ResetCoroutine();
                    healthScipt.DecrementBullets();
                    hudScript.AdjustBulletText();
                }
            }
        }
    }
}
