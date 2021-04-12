using System.Collections.Generic;
using UnityEngine;

namespace UrfuProject
{
    public class WeightQuest : MonoBehaviour
    {

        public GameObject winPanel;
        public GameObject actionElements;
        public List<GameObject> boxes;

        private List<GameObject> boxColliders;

        private List<GameObject> positions;

        public BoxCollider2D platform;

        private void Awake()
        {
            positions = new List<GameObject>();

            foreach (var i in boxes)
            {
                i.GetComponent<Rigidbody2D>().mass = Random.Range(2, 10);
            }

            boxColliders = boxes;
            SortMasses(boxes);
        }

        private void SortXCoordinates(List<GameObject> sorted)
        {
            sorted.Sort((first, second) =>
            {
                var firstX = first.GetComponent<Transform>().position.x;
                var secondX = second.GetComponent<Transform>().position.x;
                return firstX > secondX ? -1 : 1;
            });
        }

        private void SortMasses(List<GameObject> ls)
        {
            ls.Sort((first, second) =>
            {
                var firstMass = first.GetComponent<Rigidbody2D>().mass;
                var secondMass = second.GetComponent<Rigidbody2D>().mass;
                return firstMass > secondMass ? -1 : 1;
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
            CheckForWinning();
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

        private void CheckForWinning()
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
                    break;
                }
                index++;
            }

            if (!isEqual)
                Debug.Log("No");
            else
            {
                Debug.Log("Yes");
                winPanel.SetActive(true);
                actionElements.SetActive(false);
            }
        }
    }
}
