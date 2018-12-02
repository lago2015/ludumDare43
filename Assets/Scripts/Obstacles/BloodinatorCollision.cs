using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodinatorCollision : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Bullet"))
        {
            col.gameObject.GetComponent<BulletMovement>().BlowUp(transform.position);
        }
    }
}