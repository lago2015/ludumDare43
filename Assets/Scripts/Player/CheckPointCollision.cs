using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollision : MonoBehaviour {

    public PlayerHealthBullets playerBullet;
    private HUDManager hudScript;

    private void Awake()
    {
        hudScript = FindObjectOfType<HUDManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            playerBullet.ReplenishBullets();
            hudScript.IncrementScoreText(5);
            hudScript.IncrementCheckPointText();
            Destroy(gameObject);
        }
    }
}
