using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;

    public Text text;
    public ParticleSystem ps;
    
    void Start()
    {
        text.text = $"Health: {health}";
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "EnemyBullet")
            return;

        health--;
        text.text = $"Health: {health}";
        ps.Play();

        if (health > 0)
            return;
        
        // Destroy(other.gameObject);
        // Destroy(gameObject);
        
        SceneManager.LoadScene("SampleScene");
    }
}
