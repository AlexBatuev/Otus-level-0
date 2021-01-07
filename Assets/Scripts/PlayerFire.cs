using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform sourceTransform;
    public float bulletSpeed = 5f;
    public float bulletLifeTime = 5f;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.tag = "PlayerBullet";
            
            bullet.transform.position = sourceTransform.position;
            
            bullet.GetComponent<Rigidbody>().AddForce(sourceTransform.forward * bulletSpeed, ForceMode.Impulse);
        
            Destroy(bullet, bulletLifeTime);        
        }
    }
}
