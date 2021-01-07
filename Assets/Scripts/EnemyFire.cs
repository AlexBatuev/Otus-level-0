using System.Collections;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform sourceTransform;
    public Transform targetTransform;
    public float bulletSpeed = 5f;
    public float bulletLifeTime = 5f;
    public float minFireDelay = 1f;
    public float maxFireDelay = 2f;
    public float maxFireRange = 5f;

    private void Start()
    {
        StartCoroutine(nameof(Fire));
    }
    
    private IEnumerator Fire()
    {
        var distance = Vector3.Distance(targetTransform.position, sourceTransform.position);
        if (distance < maxFireRange)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.tag = "EnemyBullet";

            bullet.transform.position = sourceTransform.position;

            var target = targetTransform.position - transform.position;
            bullet.GetComponent<Rigidbody>().AddForce(target * bulletSpeed, ForceMode.Impulse);

            Destroy(bullet, bulletLifeTime);
        }

        var delay = Random.Range(minFireDelay, maxFireDelay);
        yield return new WaitForSeconds(delay);
        StartCoroutine(nameof(Fire));
    }
}
