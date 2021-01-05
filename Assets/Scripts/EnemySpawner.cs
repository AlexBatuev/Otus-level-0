using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject cubeEnemyPrefab;
    public GameObject prismEnemyPrefab;
    public Transform playerTransform;
    public float range = 10f;
    public float minDelay = 1f;
    public float maxDelay = 1f;

    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        GameObject prefab;

        if (Random.Range(0, 2) == 1)
            prefab = cubeEnemyPrefab;
        else
            prefab = prismEnemyPrefab;
        
        var enemy = Instantiate(prefab);
        enemy.transform.position = Random.insideUnitSphere * range;
        var fire = enemy.GetComponent<EnemyFire>();
        fire.targetTransform = playerTransform;

        var delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);
        StartCoroutine("SpawnEnemy");
    }
}
