using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLooper : MonoBehaviour {

    public float distanceOffset;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == ("Respawn"))
        {
            //float widthOfBGObject = ((BoxCollider2D)collider).size.x;
            Vector3 position = collider.transform.position;
            position.x += distanceOffset;
            collider.transform.position = position;
        }
    }
}
