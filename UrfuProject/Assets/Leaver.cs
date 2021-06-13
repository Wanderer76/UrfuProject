using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UrfuProject
{
    public class Leaver : MonoBehaviour
    {
        public GameObject player;
        public Image armIndicator;
        public Transform arm;

        public KeyCode takeObjectKey = KeyCode.E;
        public float interactDistance = 2f;
        private float distanceToPlayer;
        private Transform playerTransform;

        private void Start()
        {
            playerTransform = player.GetComponent<Transform>();
        }

        private void OnMouseOver()
        {
            distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
            if (distanceToPlayer < interactDistance)
            {
                armIndicator.enabled = true;

                if (Input.GetKeyDown(takeObjectKey))
                {
                    RaftQuest.OnLaunchRaft?.Invoke();
                }
            }
            else
                armIndicator.enabled = false;
        }

        private void OnMouseExit()
        {
            armIndicator.enabled = false;
        }

    }
}