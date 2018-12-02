using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObjectTimer : MonoBehaviour {
    public float duration;
    public string poolName="explosionPool";
    private ObjectPoolManager poolScript;

    private void Awake()
    {
        poolScript = FindObjectOfType<ObjectPoolManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(WaitToReturnToPool());
    }

    IEnumerator WaitToReturnToPool()
    {
        yield return new WaitForSeconds(duration);
        poolScript.PutBackObject(poolName, gameObject);
    }
}
