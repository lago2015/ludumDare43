using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public float speed = -1;
    public float cuttOffPoint = -23.5f;
    public GameObject spawnpoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(Time.deltaTime * speed, 0.0f));
        if (transform.position.x < cuttOffPoint)
        {
            transform.position = spawnpoint.transform.position;
        }
;	}
}
