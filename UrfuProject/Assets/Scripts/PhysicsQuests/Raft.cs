using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UrfuProject
{
    public class Raft : MonoBehaviour
    {
        public int mass = 50; //kg
        public int density = 1000; //kg/m^3
        //private const int WaterDensity = 1027;

        private const int G = 10;
        private float ArchimedForce;

        private void Awake()
        {
            ArchimedForce = mass * density * G;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Entered");
        }

        private void Update()
        {

        }

        public void LaunchRaft()
        {

        }
    }
}