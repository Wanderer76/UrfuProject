using UnityEngine;

namespace UrfuProject
{
    public class Player : MonoBehaviour
    {
        public float speed = 2;
        private CharacterController characterController;

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            MakeMove();
        }

        private void MakeMove()
        {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            var movement = transform.right * x + transform.forward * z;
            characterController.Move(speed * movement * Time.deltaTime);
        }
    }
}