using System.Collections;
using UnityEngine;

public class EnemyTeleport : MonoBehaviour
{
    public float maxTeleportRange = 10f;
    public float minTeleportDelay = 1f;
    public float maxTeleportDelay = 2f;

    internal void Start()
    {
        StartCoroutine(methodName: nameof(Teleport));
    }

    private IEnumerator Teleport()
    {
        transform.position = Random.insideUnitSphere * maxTeleportRange;

        var delay = Random.Range(minTeleportDelay, maxTeleportDelay);
        yield return new WaitForSeconds(delay);
        StartCoroutine(nameof(Teleport));
    }
}
