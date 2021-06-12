using UnityEngine;
using UnityEngine.UI;

public class Arm : MonoBehaviour
{
    public GameObject player;
    public Image armIndicator;
    public Transform arm;

    public KeyCode takeObjectKey = KeyCode.E;
    public float interactDistance = 2f;
    private float distanceToPlayer;
    private new Rigidbody rigidbody;
    private Transform playerTransform;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerTransform = player.GetComponent<Transform>();
    }

    private void OnMouseOver()
    {
        distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        if (distanceToPlayer < interactDistance)
        {
            if (transform.parent == null)
                armIndicator.enabled = true;

            if (Input.GetKeyDown(takeObjectKey))
            {
                transform.position = arm.position;
                transform.rotation = arm.rotation;
                transform.SetParent(arm);
                rigidbody.isKinematic = true;
            }
        }
        else
            armIndicator.enabled = false;
    }

    private void OnMouseExit()
    {
        armIndicator.enabled = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rigidbody.isKinematic = false;
            transform.parent = null;
        }
    }
}
