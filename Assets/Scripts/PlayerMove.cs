using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSpeed = 10f;

    public Rigidbody rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSpeed;
        transform.Rotate(-mouseY, mouseX, 0);
    }

    private void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Jump");
        var z = Input.GetAxis("Vertical");

        var t = transform;
        var move = t.right * x + t.up * y + t.forward * z;
        rb.velocity = move * (speed * Time.deltaTime);
    }
}
