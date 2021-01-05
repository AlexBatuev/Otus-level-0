using System.Collections;
using UnityEngine;

public class EnemyTeleport : MonoBehaviour
{
    public float range = 10f;
    public float minDelay = 1f;
    public float maxDelay = 2f;

    internal void Start()
    {
        StartCoroutine(methodName: "Teleport");
    }

    private IEnumerator Teleport()
    {
        transform.position = Random.insideUnitSphere * range;

        var delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);
        StartCoroutine(nameof(Teleport));
    }
}
