using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrfuProject
{
    public class CameraScript : MonoBehaviour
    {


        public GameObject parent;

        public float _rotationSpeedHor = 5.0f;
        public float _rotationSpeedVer = 5.0f;

        public float maxVert = 45.0f;
        public float minVert = -45.0f;
        private float _rotationX = 0;


        private void Update()
        {

            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeedVer;
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * _rotationSpeedHor;
            float _rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
}