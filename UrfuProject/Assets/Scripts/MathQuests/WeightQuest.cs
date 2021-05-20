using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace UrfuProject
{
    public class WeightQuest : MonoBehaviour
    {

        public GameObject winPanel;
        public List<GameObject> boxes;

        private List<GameObject> boxesPositions;
        public Collider platform;

        private void Awake()
        {
            boxesPositions = new List<GameObject>();

            foreach (var i in boxes)
            {
                i.GetComponent<Rigidbody>().mass = Random.Range(2, 10);
            }

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
                var firstMass = first.GetComponent<Rigidbody>().mass;
                var secondMass = second.GetComponent<Rigidbody>().mass;
                return firstMass > secondMass ? -1 : 1;
            });
        }

        private void OnTriggerEnter(Collider collision)
        {
            foreach (var i in boxes.Where(i => collision.gameObject == i))
            {
                Debug.Log("Trigger enter");
                boxesPositions.Add(i);
            }

            SortXCoordinates(boxesPositions);
            CheckForWinning();
        }

        private void OnTriggerExit(Collider collision)
        {
            foreach (var i in boxes)
            {
                if (collision.gameObject == i)
                {
                    Debug.Log("Trigger exit");
                    boxesPositions.Remove(i);
                }
            }
            SortXCoordinates(boxesPositions);
        }

        


        private void CheckForWinning()
        {
            if (boxesPositions.Count != boxes.Count)
                return;

            bool isEqual = true;
            var index = 0;
            foreach (var i in boxesPositions)
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
                //actionElements.SetActive(false);
            }
        }
    }
}
