using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSource;
    public float bulletSpeed = 5f;
    public float lifeTime = 5f;

    private bool notStarted = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (notStarted)
            {
                GetComponent<PlayerMove>().enabled = true;
                GetComponent<PlayerHealth>().enabled = true;
                GetComponent<EnemySpawner>().enabled = true;
                notStarted = false;
                return;
            }
            
            var bullet = Instantiate(bulletPrefab);
            bullet.tag = "PlayerBullet";
            
            bullet.transform.position = bulletSource.position;
            bullet.transform.rotation = bullet.transform.rotation;
            
            bullet.GetComponent<Rigidbody>().AddForce(bulletSource.forward * bulletSpeed, ForceMode.Impulse);
        
            Destroy(bullet, lifeTime);        
        }
    }
}
