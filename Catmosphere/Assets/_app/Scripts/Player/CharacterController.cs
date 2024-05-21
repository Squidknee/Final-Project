using UnityEngine;

namespace _app.Scripts.Player
{
    public class CharacterController : MonoBehaviour
    {
        [Header("Movement Variables")] 
        public float movementSpeed;
        public Vector3 jumpForce;
        public bool crouching;
        
        public Transform orientation;
        private float horizontalInput;
        private float verticalInput;
        public Vector3 moveDirection;
        
        [Header("Player Components")] 
        public Rigidbody rb;
        public Camera playerCamera;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.freezeRotation = true;
        }
        
        public void Update()
        {
            HandleInput();
        }
        private void HandleInput()
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

        public void FixedUpdate()
        {
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            Vector3 forwardMovement = orientation.forward * verticalInput;
            Vector3 rightMovement = orientation.right * horizontalInput;

            // Combine the forward and right movement vectors
            Vector3 movement = (forwardMovement + rightMovement).normalized * movementSpeed;

            // Apply the movement to the rigidbody
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        }
    }
}