using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public GameObject player;
    public float interactDistance = 2f;
    public Transform arm;
    public KeyCode key = KeyCode.E;
    private float distance;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    private void OnMouseOver()
    {
        distance = Vector3.Distance(player.GetComponent<Transform>().position, transform.position);

        if (distance < interactDistance)
        {
            if (Input.GetKeyDown(key))
            {
                transform.position = arm.position;
                transform.rotation = arm.rotation;
                transform.SetParent(arm);
                rigidbody.isKinematic = true;
            }
        }
    }

    private void OnMouseExit()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rigidbody.isKinematic = false;
            transform.parent = null;
        }
    }

}
