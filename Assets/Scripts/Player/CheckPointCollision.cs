using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollision : MonoBehaviour {

    public PlayerHealthBullets playerBullet;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            playerBullet.ReplenishBullets();
            Destroy(gameObject);
        }
    }
}
