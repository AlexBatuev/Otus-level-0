using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform sourceTransform;
    public Transform targetTransform;
    public float bulletSpeed = 5f;
    public float lifeTime = 5f;
    public float minDelay = 1f;
    public float maxDelay = 2f;
    public float fireRange = 5f;

    void Start()
    {
        StartCoroutine("Fire");
    }
    
    private IEnumerator Fire()
    {
        var distance = Vector3.Distance(targetTransform.position, sourceTransform.position);
        if (distance < fireRange)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.tag = "EnemyBullet";

            bullet.transform.position = sourceTransform.position;
            bullet.transform.rotation = bullet.transform.rotation;

            var target = targetTransform.position - transform.position;
            bullet.GetComponent<Rigidbody>().AddForce(target * bulletSpeed, ForceMode.Impulse);

            Destroy(bullet, lifeTime);
        }

        var delay = Random.Range(minDelay, maxDelay);
        yield return new WaitForSeconds(delay);
        StartCoroutine("Fire");
    }
}
