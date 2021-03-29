using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MathQuest : MonoBehaviour
{
    [Range(0f,10f)]
    private const float DistanseBetweenColleders = 1f;
    
    [SerializeField]
    private const float YOffset= -3f;

    public GameObject[] boxes;
    private List<DragObject> positions = new List<DragObject>();
    public BoxCollider2D platform;

    private void Awake()
    {
    }

    private static void SortMasses(GameObject[] sorted)
    {
        for (var i = 0; i < sorted.Length; i++)
        {
            var rigidbody1 = sorted[i].GetComponent<Rigidbody2D>();
            for (var j = 1; j < sorted.Length; j++)
            {
                var rigidbody2 = sorted[j].GetComponent<Rigidbody2D>();
                if (rigidbody1.mass < rigidbody2.mass)
                {
                    var temp = rigidbody1.mass;
                    rigidbody1.mass = rigidbody2.mass;
                    rigidbody1.mass = temp;
                }
            }
        }
    }

    private void Update()
    {
        var pos = new HashSet<DragObject>();

        for (int i = 0; i < boxes.Length; i++)
        {
            var box = boxes[i].GetComponent<DragObject>();
            if (platform.Distance(box.GetComponent<BoxCollider2D>()).distance < DistanseBetweenColleders
                && box.transform.position.y > YOffset)
                pos.Add(box);
        }
        Debug.Log($"Count - {pos.Count}");
        if (pos.Count == boxes.Length)
            Debug.Log("OK");
        else
            Debug.Log("No");
    }
}
