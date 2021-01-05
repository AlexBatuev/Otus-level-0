using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;

    public Text text;
    public ParticleSystem ps;

    private void Start()
    {
        text.text = $"Health: {health}";
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("EnemyBullet"))
            return;

        health--;
        text.text = $"Health: {health}";
        ps.Play();

        if (health > 0)
            return;
        
        SceneManager.LoadScene("SampleScene");
    }
}
