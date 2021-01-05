using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleport : MonoBehaviour
{
    public float range = 10f;
    public float minDelay = 1f;
    public float maxDelay = 2f;
    
    void Start()
    {
        StartCoroutine("Teleport");
    }

    private IEnumerator Teleport()
    {
        transform.position = Random.insideUnitSphere * range;

        var delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);
        StartCoroutine("Teleport");
    }
}
