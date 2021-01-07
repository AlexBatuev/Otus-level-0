using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public ParticleSystem particlePrefab;
    public int health = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("PlayerBullet"))
            return;
        
        if (--health > 0)
            return;

        Instantiate(particlePrefab, transform.position, Quaternion.identity);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
