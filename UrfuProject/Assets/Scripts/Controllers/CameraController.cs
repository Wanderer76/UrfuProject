using UnityEngine;

namespace UrfuProject
{
    public class CameraController : MonoBehaviour
    {
        public GameObject parent;

        public float sensitive = 100;
        private float xRotation = 0;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * sensitive * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * sensitive * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            parent.transform.Rotate(Vector3.up * mouseX);
        }
    }
}