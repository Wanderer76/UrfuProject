using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UrfuProject
{
    public class Player : MonoBehaviour
    {
        public float speed = 2;
        private CharacterController characterController;

        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            //var forward = transform.TransformDirection(Vector3.forward);
            var verticalSpeed = Input.GetAxis("Vertical");
            var horizontalSpeed = Input.GetAxis("Horizontal");
            var movement = new Vector3(horizontalSpeed, 0, verticalSpeed);
            characterController.SimpleMove(speed * movement);
        }
    }
}