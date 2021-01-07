﻿using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject textBackground;
    public Transform sourceTransform;
    public float bulletSpeed = 5f;
    public float bulletLifeTime = 5f;

    private bool _notStarted = true;

    private void Start()
    {
        textBackground.transform.localScale = new Vector3(0.2f, 0.1f, 0.1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_notStarted)
            {
                GetComponent<PlayerMove>().enabled = true;
                GetComponent<PlayerHealth>().enabled = true;
                GetComponent<EnemySpawner>().enabled = true;
                _notStarted = false;
                textBackground.transform.localScale = new Vector3(0.1f, 0.1f, 0.05f);
                return;
            }
            
            var bullet = Instantiate(bulletPrefab);
            bullet.tag = "PlayerBullet";
            
            bullet.transform.position = sourceTransform.position;
            
            bullet.GetComponent<Rigidbody>().AddForce(sourceTransform.forward * bulletSpeed, ForceMode.Impulse);
        
            Destroy(bullet, bulletLifeTime);        
        }
    }
}
