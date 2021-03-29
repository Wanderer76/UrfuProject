using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MathQuest : MonoBehaviour
{

    public List<GameObject> boxes;

    public List<GameObject> boxColliders;

    private List<GameObject> positions = new List<GameObject>();

    public BoxCollider2D platform;

    private void Awake()
    {
        boxColliders = boxes;
        SortMasses(boxes);
    }

    private void SortXCoordinates(List<GameObject> sorted)
    {
        sorted.Sort((first, second) =>
        {
            var firstX = first.GetComponent<Transform>().position.x;
            var secondX = second.GetComponent<Transform>().position.x;
            if (firstX > secondX)
                return -1;
            else
                return 1;
        });
    }

    private void SortMasses(List<GameObject> ls)
    {
        ls.Sort((first, second) =>
        {
            var firstMass = first.GetComponent<Rigidbody2D>().mass;
            var secondMass = second.GetComponent<Rigidbody2D>().mass;
            if (firstMass > secondMass)
                return -1;
            else
                return 1;
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var i in boxColliders)
        {
            if (collision.gameObject == i)
            {
                Debug.Log("Trigger enter");
                positions.Add(i);
            }
        }
        SortXCoordinates(positions);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (var i in boxColliders)
        {
            if (collision.gameObject == i)
            {
                Debug.Log("Trigger exit");
                positions.Remove(i);
            }
        }
        SortXCoordinates(positions);
    }

    private void FixedUpdate()
    {

        if (positions.Count != boxes.Count)
            return;

        bool isEqual = true;
        var index = 0;
        foreach (var i in positions)
        {
            if (i != boxes[index])
            {
                isEqual = false;
                Debug.Log("No");
                break;
            }
            index++;
        }
        if (isEqual)
            Debug.Log("Yes");
    }
}
