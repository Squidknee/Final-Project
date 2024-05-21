using UnityEngine;

namespace _app.Scripts.Player
{
    public class PlayerCam : MonoBehaviour
    {
        public float sensX;
        public float sensY;

        public Transform orientation;

        private float xRotation;
        private float yRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; 
        }

        private void Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;
            
            //make sure player can't look up or down 90 degrees
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            
            //rotate camera and player orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        }
    }
}