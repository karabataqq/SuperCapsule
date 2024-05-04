using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rgb;
    public float moveSpeed = 6f;
    public float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    

    void Start()
    {
        rgb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rgb.velocity = new Vector3(horizontalInput * moveSpeed, rgb.velocity.y, verticalInput * moveSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

    }
    void Jump()
    {
        rgb.velocity = new Vector3(rgb.velocity.x, jumpForce, rgb.velocity.z);
        jumpSound.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    bool IsGrounded()
        {
         return Physics.CheckSphere(groundCheck.position, .1f, ground);
        }
    
}
