using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollision : MonoBehaviour {

    public PlayerHealthBullets playerBullet;
    private HUDManager hudScript;
    private AudioController audioScript;
    private void Awake()
    {
        hudScript = FindObjectOfType<HUDManager>();
        audioScript = FindObjectOfType<AudioController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            audioScript.SacrificeObtained(transform.position);
            playerBullet.AddBullets();
            hudScript.IncrementScoreText(5);
            hudScript.IncrementCheckPointText();
            hudScript.AdjustBulletText();
            Destroy(gameObject);
        }
    }
}
