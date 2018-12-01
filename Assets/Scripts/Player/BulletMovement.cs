using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public bool ShouldMove = true;
    public float travelTimeRocket = 3;
    private Vector3 curPosition;
    private ObjectPool myPool;

    public void SetPool(ObjectPool curPool) { myPool = curPool; }
    public void ResetCoroutine()
    {
        StopAllCoroutines();
        StartCoroutine(LaunchTime());
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

        BlowUp(false);
    }

    public void BlowUp(bool damage)
    {
        //spawn explosion

        myPool.ReturnCurObstacle(gameObject);
    }
}
