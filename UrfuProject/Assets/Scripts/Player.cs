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
            MakeMove();
        }

        private void MakeMove()
        {
            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
            var verticalSpeed = Input.GetAxis("Vertical");
            var horizontalSpeed = Input.GetAxis("Horizontal");
            var movement = new Vector3(horizontalSpeed, 0, verticalSpeed);
            characterController.SimpleMove(speed * movement);
        }
    }
}