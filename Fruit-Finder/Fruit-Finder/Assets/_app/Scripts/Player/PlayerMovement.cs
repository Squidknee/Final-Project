using System;
using _app.Scripts.Managers;
using UnityEngine;

namespace _app.Scripts.Player
{

    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")] 
        public float moveSpeed;

        public Vector3 jumpForce;

        public Transform orientation;
        
        public bool isGrounded = true;
        
        private float horizontalInput;
        private float verticalInput;

        private Vector3 moveDirection;

        private Rigidbody rb;
        

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
        }

        private void MyInput()
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                PlayerJump();
            }
        }
        private void PlayerJump()
        {
            isGrounded = false;
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }

        private void Update()
        {
            MyInput();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            // Check if the object collided with has the tag "Ground"
            if (collision.collider.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }
        
    }
}