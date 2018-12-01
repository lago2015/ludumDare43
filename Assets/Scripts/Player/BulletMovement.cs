using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    private GameObject explosion;
    public float moveSpeed = 5.0f;
    public bool ShouldMove = true;
    public float travelTimeRocket = 3;
    private Vector3 curPosition;
    private ObjectPoolManager bulletPool;
    public string bulletPoolName;
    public string explosionPoolName;
    public void SetPool(ObjectPoolManager curPool) { bulletPool = curPool; }
    public void ResetCoroutine()
    {
        //StopAllCoroutines();
        //StartCoroutine(LaunchTime());
    }
    
    void FixedUpdate()
    {
        if (ShouldMove)
        {
            curPosition = transform.position;
            curPosition.x += moveSpeed * Time.deltaTime;
            curPosition.z = 0;
            transform.position = curPosition;
        }
    }

    IEnumerator LaunchTime()
    {
        yield return new WaitForSeconds(travelTimeRocket);

        BlowUp(transform.position);
    }

    public void BlowUp(Vector3 curPosition)
    {
        explosion = bulletPool.FindObject(explosionPoolName);
        explosion.transform.position = curPosition;
        explosion.SetActive(true);
        //spawn explosion
        bulletPool.PutBackObject(bulletPoolName, gameObject);
        
    }
}
