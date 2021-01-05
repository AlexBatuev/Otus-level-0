using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSpeed = 10f;

    public Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed;
        transform.Rotate(-mouseY, mouseX, 0);
    }
    
    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Jump");
        var z = Input.GetAxis("Vertical");

        var move = transform.right * x + transform.up * y + transform.forward * z;
        rb.velocity = move * speed * Time.deltaTime;
    }
}
