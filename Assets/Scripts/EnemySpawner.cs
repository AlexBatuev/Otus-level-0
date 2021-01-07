using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject cubeEnemyPrefab;
    public GameObject prismEnemyPrefab;
    public Transform playerTransform;
    public float maxSpawnRange = 10f;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 1f;

    private void Start()
    {
        StartCoroutine(nameof(SpawnEnemy));
    }

    private IEnumerator SpawnEnemy()
    {
        var prefab = Random.Range(0, 2) == 1 ? cubeEnemyPrefab : prismEnemyPrefab;
        
        var enemy = Instantiate(prefab);
        enemy.transform.position = Random.insideUnitSphere * maxSpawnRange;
        
        var fire = enemy.GetComponent<EnemyFire>();
        fire.targetTransform = playerTransform;

        var delay = Random.Range(minSpawnDelay, maxSpawnDelay);
        yield return new WaitForSeconds(delay);
        StartCoroutine(nameof(SpawnEnemy));
    }
}
