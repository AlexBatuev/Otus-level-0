using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public ParticleSystem particlePrefab;
    public int health = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "PlayerBullet")
            return;
        
        if (--health > 0)
            return;
        
        Instantiate(particlePrefab, transform.position, transform.rotation);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
