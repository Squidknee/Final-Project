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
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerJump();
            }
        }
        private void PlayerJump()
        {
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
    }
}