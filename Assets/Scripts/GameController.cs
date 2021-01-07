using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject textBackground;

    private bool _spaceAllowed;
    
    private void Start()
    {
        textBackground.transform.localScale = new Vector3(0.2f, 0.1f, 0.1f);
        
        Invoke(nameof(AllowSpace), 1f);
    }

    private void Update()
    {
        if (_spaceAllowed && Input.GetKeyDown(KeyCode.Space))
        {
            textBackground.transform.localScale = new Vector3(0.1f, 0.1f, 0.05f);

            GetComponent<PlayerMove>().enabled = true;
            GetComponent<PlayerFire>().enabled = true;
            GetComponent<PlayerHealth>().enabled = true;
            GetComponent<EnemySpawner>().enabled = true;
            GetComponent<GameController>().enabled = false;
        }
    }

    private void AllowSpace ()
    {
        _spaceAllowed = true;
    }
}
