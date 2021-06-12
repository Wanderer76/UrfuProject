using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransportedItem : Arm
{
    [Header("Физические данные")]
    public int mass = 10;//kg
    public int density = 1000; //kg/m^3
    private const int G = 10;
    private float ArchimedForce;

    //public GameObject player;
    //public Image armIndicator;
    //public Transform arm;
    //public KeyCode takeObjectKey = KeyCode.E;
    //public float interactDistance = 2f;
    //private float distanceToPlayer;
    //
    //private Rigidbody itemRigidbody;
    //private Transform playerTransform;


    private void Awake()
    {
        ArchimedForce = mass * density * G;
       // itemRigidbody = GetComponent<Rigidbody>();
    }

    //private void OnMouseOver()
    //{
    //    distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
    //    if (distanceToPlayer < interactDistance)
    //    {
    //        if (transform.parent == null)
    //            armIndicator.enabled = true;
    //
    //        if (Input.GetKeyDown(takeObjectKey))
    //        {
    //            transform.position = arm.position;
    //            transform.rotation = arm.rotation;
    //            transform.SetParent(arm);
    //            itemRigidbody.isKinematic = true;
    //        }
    //    }
    //    else
    //        armIndicator.enabled = false;
    //}
    //
    //private void OnMouseExit()
    //{
    //    armIndicator.enabled = false;
    //
    //}
    //
    //private void FixedUpdate()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        itemRigidbody.isKinematic = false;
    //        transform.parent = null;
    //    }
    //}
}
