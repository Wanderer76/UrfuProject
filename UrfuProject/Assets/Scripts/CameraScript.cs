using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrfuProject
{
    public class CameraScript : MonoBehaviour
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
        private void FixedUpdate()
        {
            /* RaycastHit hit;

             if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
             {
                 if (hit.collider.GetComponent<DragObject>())
                 {

                         Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                         Debug.Log("Did Hit");

                 }
             }
             else
             {
                 Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
                 Debug.Log("Did not Hit");
             }*/
        }
    }
}